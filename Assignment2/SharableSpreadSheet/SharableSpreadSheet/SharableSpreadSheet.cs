using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Threading;
class SharableSpreadSheet
{
    private int _rows;
    private int _cols;
    private string[][] _strMatrix;

    //readers
    private Mutex[] _rowReadMutexLock;
    private Mutex[] _colReadMutexLock;
    private int[] _rowReadIntCounter;
    private int[] _colReadIntCounter;

    //writers
    private Mutex[] _rowWriteMutexLock;
    private Mutex[] _colWriteMutexLock;

    //Amount of users
    private int _amountUsers;

    //Table lock
    private SemaphoreSlim _semaphoreUsers;
    private Mutex _mutexLockTable;

    //rows and cols exchanging locks
    private Mutex _rowExchangingLock;
    private Mutex _colExchangingLock;
    
    
    public SharableSpreadSheet(int nRows, int nCols, int nUsers=-1)
    {
        // nUsers used for setConcurrentSearchLimit, -1 mean no limit.
        // construct a nRows*nCols spreadsheet
        this._rows = nRows;
        this._cols = nCols;
        this._amountUsers = nUsers;
        this._rowReadMutexLock = new Mutex[nRows];
        this._colReadMutexLock = new Mutex[nCols];
        this._rowWriteMutexLock = new Mutex[nRows];
        this._colWriteMutexLock = new Mutex[nCols];
        this._strMatrix = new string[_rows][];
        for (int r = 0; r < nRows; r++)
        {
            _rowReadMutexLock[r] = new Mutex();
            _rowWriteMutexLock[r] = new Mutex();
            this._strMatrix[r] = new string[nCols];
            for (int c = 0; c < nCols; c++)
            {
                _strMatrix[r][c] = "";
            }   
        }

        for (int c = 0; c < nCols; c++)
        {
            _colReadMutexLock[c] = new Mutex();
            _colWriteMutexLock[c] = new Mutex();
        }
            

        //initate table locks
        this._semaphoreUsers = new SemaphoreSlim(nUsers, nUsers);
        this._mutexLockTable = new Mutex();

        //initiate readers
        this._rowReadIntCounter = new int[nRows];
        this._colReadIntCounter = new int[nCols];

        //initiate exchanging locks
        this._rowExchangingLock = new Mutex();
        this._colExchangingLock = new Mutex();

    }
    public String getCell(int row, int col)
    {
        //check if the parameters are valid
        if (row < 0 || row >= this._rows || col < 0 || col >= this._cols)
            throw new ArgumentException("invalid argument");

        //need to check if the table is not locked. if not, increment the amount of users in the semaphoreUsers
        this._mutexLockTable.WaitOne();
        this._semaphoreUsers.Wait();
        this._mutexLockTable.ReleaseMutex();

        //increment the readers counter
        //intervened so they incremented together
        _rowReadMutexLock[row].WaitOne();
        _colReadMutexLock[col].WaitOne();

        //if there is at least one user that is reading from that row, lock the write lock
        if (++_rowReadIntCounter[row] == 1)
            this._rowWriteMutexLock[row].WaitOne();
        

        //if there is at least one user that is reading from that col, lock the write lock
        if (++_colReadIntCounter[col] == 1)
            this._colWriteMutexLock[col].WaitOne();
        _colReadMutexLock[col].ReleaseMutex();
        _rowReadMutexLock[row].ReleaseMutex();

        //get the cell
        String str = this._strMatrix[row][col];

        //decrement the readers counter. if it is 0, release the write lock
        _rowReadMutexLock[row].WaitOne();
        _colReadMutexLock[col].WaitOne();

        //if there is at least one user that is reading from that row, lock the write lock
        if (--_rowReadIntCounter[row] == 0)
            this._rowWriteMutexLock[row].ReleaseMutex();


        //if there is at least one user that is reading from that col, lock the write lock
        if (--_colReadIntCounter[col] == 0)
            this._colWriteMutexLock[col].ReleaseMutex();
        _colReadMutexLock[col].ReleaseMutex();
        _rowReadMutexLock[row].ReleaseMutex();

        //one user finished
        this._semaphoreUsers.Release();

        return str;
    }
    public void setCell(int row, int col, String str)
    {
        if (row < 0 || row >= this._rows || col < 0 || col >= this._cols || str == null)
            throw new ArgumentException("invalid argument");

        //need to check if the table is not locked. if not, increment the amount of users in the semaphoreUsers
        this._mutexLockTable.WaitOne();
        this._semaphoreUsers.Wait();
        this._mutexLockTable.ReleaseMutex();

        //get locks
        this._rowWriteMutexLock[row].WaitOne();
        this._colWriteMutexLock[col].WaitOne();

        //set the cell
        this._strMatrix[row][col] = str;

        //release locks
        this._rowWriteMutexLock[row].ReleaseMutex();
        this._colWriteMutexLock[col].ReleaseMutex();

        //one user finished
        this._semaphoreUsers.Release();
    }
    public Tuple<int,int> searchString(String str)
    {
        int row, col;
        // return first cell indexes that contains the string (search from first row to the last row)
        return searchInRange(0, _cols, 0, _rows, str);
    }
    public void exchangeRows(int row1, int row2)
    {
        // exchange the content of row1 and row2
        if (row1 < 0 || row2 < 0 || row1 >= this._rows || row2 >= this._rows)
            throw new ArgumentException("invalid argument");

        if (row1 == row2)
            return;

        this._mutexLockTable.WaitOne();
        this._semaphoreUsers.Wait();
        this._mutexLockTable.ReleaseMutex();

        _colExchangingLock.WaitOne();
        _rowWriteMutexLock[row1].WaitOne();
        _rowWriteMutexLock[row2].WaitOne();

        //swap
        for (var i = 0; i < this._cols; i++)
            (this._strMatrix[row1][i], this._strMatrix[row2][i]) = (this._strMatrix[row2][i], this._strMatrix[row1][i]);

        _rowWriteMutexLock[row2].ReleaseMutex();
        _rowWriteMutexLock[row1].ReleaseMutex();
        _colExchangingLock.ReleaseMutex();
        _semaphoreUsers.Release();

    }
    public void exchangeCols(int col1, int col2)
    {
        // exchange the content of col1 and col2
        if (col1 < 0 || col2 < 0 || col1 >= this._cols || col2 >= this._cols)
            throw new ArgumentException("invalid argument");
        if (col1 == col2)
            return;
        this._mutexLockTable.WaitOne();
        this._semaphoreUsers.Wait();
        this._mutexLockTable.ReleaseMutex();
        _rowExchangingLock.WaitOne();
        _colWriteMutexLock[col1].WaitOne();
        _colWriteMutexLock[col2].WaitOne();
        //swap
        for (var r = 0; r < this._rows; r++)
            (this._strMatrix[r][col1], this._strMatrix[r][col2]) = (this._strMatrix[r][col2], this._strMatrix[r][col1]);

        
        _colWriteMutexLock[col2].ReleaseMutex();
        _colWriteMutexLock[col1].ReleaseMutex();
        _rowExchangingLock.ReleaseMutex();
        _semaphoreUsers.Release();

    }
    public int searchInRow(int row, string str)
    {
        int col = -1;
        if (row < 0 || row >= this._rows || str == null)
            throw new ArgumentException("invalid argument");

        // perform search in specific row
        this._mutexLockTable.WaitOne();
        this._semaphoreUsers.Wait();
        this._mutexLockTable.ReleaseMutex();
        
        //so that the cols won't be swapped
        this._colExchangingLock.WaitOne();

        _rowReadMutexLock[row].WaitOne();
        if (++_rowReadIntCounter[row] == 1)
            this._rowWriteMutexLock[row].WaitOne();
        _rowReadMutexLock[row].ReleaseMutex();

        for (var c = 0; c < this._cols; c++)
        {
            if (!str.Equals(_strMatrix[row][c])) continue;
            col = c;
            break;
        }   
        _rowReadMutexLock[row].WaitOne();
        if (--_rowReadIntCounter[row] == 0)
            this._rowWriteMutexLock[row].ReleaseMutex();
        _rowReadMutexLock[row].ReleaseMutex();

        _colExchangingLock.ReleaseMutex();
        _semaphoreUsers.Release();
        
        return col;
    }
    public int searchInCol(int col, String str)
    {
        if (col < 0 || col >= this._cols || str == null)
            throw new ArgumentException("invalid parameter");

        int row;
        // perform search in specific row
        this._mutexLockTable.WaitOne();
        this._semaphoreUsers.Wait();
        this._mutexLockTable.ReleaseMutex();

        //so that the cols won't be swapped
        this._rowExchangingLock.WaitOne();

        _colReadMutexLock[col].WaitOne();
        if (++_colReadIntCounter[col] == 1)
            this._colWriteMutexLock[col].WaitOne();
        _colReadMutexLock[col].ReleaseMutex();

        for (var r = 0; r < this._rows; r++)
        {
            if (!str.Equals(_strMatrix[r][col])) continue;
            row = r;
            break;
        }
        _colReadMutexLock[col].WaitOne();
        if (--_colReadIntCounter[col] == 0)
            this._colWriteMutexLock[col].ReleaseMutex();
        _colReadMutexLock[col].ReleaseMutex();

        _rowExchangingLock.ReleaseMutex();
        _semaphoreUsers.Release();

        return col;
    }
    public Tuple<int, int> searchInRange(int col1, int col2, int row1, int row2, String str)
    {
        // perform search within spesific range: [row1:row2,col1:col2] 
        return search(col1, col2, row1, row2, str, true, true)[0];
    }

    public Tuple<int, int>[] search(int col1, int col2, int row1, int row2, string str, bool caseSensitive, bool singular)
    {
        // includes col1,col2,row1,row2
        //invalid parameters
        if (col1 < 0 || col2 > this._cols || row1 < 0 || row2 > this._rows || str == null || col1 > col2 || row1 > row2)
            throw new ArgumentException("invalid argument");

        //need to check if the table is not locked. if not, increment the amount of users in the semaphoreUsers
        this._mutexLockTable.WaitOne();
        this._semaphoreUsers.Wait();
        this._mutexLockTable.ReleaseMutex();

        List<Tuple<int, int>> tuplesList = new List<Tuple<int, int>>();
        int row = -1, col = -1;

        // preventing cols and rows Exchanging
        this._rowExchangingLock.WaitOne();
        this._colExchangingLock.WaitOne();
        
        //searching
        var found = false;
        for (var r = row1; r < row2; r++)
        {
            this._rowReadMutexLock[r].WaitOne();
            if (++this._rowReadIntCounter[r] == 1)
                this._rowWriteMutexLock[r].WaitOne();
            this._rowReadMutexLock[r].ReleaseMutex();

            for (var c = col1; c < col2; c++)
            {
                if (found)
                    break;
                if (!caseSensitive && str.Equals(_strMatrix[r][c]))
                {
                    tuplesList.Add(new Tuple<int, int>(r, c));
                    if (singular)
                        found = true;
                }

                if (caseSensitive && str.ToLower().Equals(_strMatrix[r][c].ToLower()))
                {
                    tuplesList.Add(new Tuple<int, int>(r, c));
                    if (singular)
                        found = true;

                }
            }
            //lock the counter of the row
            this._rowReadMutexLock[r].WaitOne();
            //last reader release write
            if (--_rowReadIntCounter[r] == 0)
                this._rowWriteMutexLock[r].ReleaseMutex();
            this._rowReadMutexLock[r].ReleaseMutex();
        }

        //release cols and rows exchanging
        this._colExchangingLock.ReleaseMutex();
        this._rowExchangingLock.ReleaseMutex();
        this._semaphoreUsers.Release(); //release user

        //converting between list to array
        Tuple<int, int>[] tuplesArray = new Tuple<int, int>[tuplesList.Count];
        for (int i = 0; i < tuplesList.Count; i++)
            tuplesArray[i] = tuplesList[i];

        if (tuplesArray.Length == 0)
            return new[] { Tuple.Create(-1, -1) };
        return tuplesArray;
    }
    
    public void addRow(int row1)
    {
        //add a row after row1
        if (row1 < 0 || row1 >= this._rows)
            throw new ArgumentException("invalid argument");

        // perform search in specific row
        this._mutexLockTable.WaitOne();
        for (int user = 0; user < this._amountUsers; user++)
            this._semaphoreUsers.Wait();

        string[][] tmpStrMatrix = new string[++this._rows][];
        for (int r = 0; r < this._rows; r++)
        {
            tmpStrMatrix[r] = new string[this._cols];
            if (r < row1 + 1) //copy the old values
                _strMatrix[r].CopyTo(tmpStrMatrix[r], 0);
            if (r == row1 + 1) //the new row. need to be empty
                for (int c = 0; c < this._cols; c++)
                    tmpStrMatrix[r][c] = "";
            if (r > row1 + 1) //copy the old values after the new row
                _strMatrix[r - 1].CopyTo(tmpStrMatrix[r], 0);
        }
        this._strMatrix = tmpStrMatrix;

        //extending the int counter and the mutex array by one and initiating them 
        Array.Resize(ref this._rowReadIntCounter, this._rowReadIntCounter.Length + 1);
        Array.Resize(ref this._rowReadMutexLock, this._rowReadMutexLock.Length + 1);
        Array.Resize(ref this._rowWriteMutexLock, this._rowWriteMutexLock.Length+1);
        this._rowWriteMutexLock[^1] = new Mutex();
        this._rowReadMutexLock[^1] = new Mutex();
        
        _semaphoreUsers.Release(this._amountUsers);
        _mutexLockTable.ReleaseMutex();
    }
    public void addCol(int col1)
    {
        //add a column after col1
        if (col1 < 0 || col1 >= this._cols)
            throw new ArgumentException("invalid argument");

        this._mutexLockTable.WaitOne();
        for (int user = 0; user < this._amountUsers; user++)
            this._semaphoreUsers.Wait();

        this._cols++;
        //string[][] tmpStrMatrix = new string[this._rows][];
        for (int r = 0; r < this._rows; r++)
        {
            Array.Resize(ref _strMatrix[r],this._cols);
            Array.Copy(_strMatrix[r], col1 + 1, _strMatrix[r], col1 + 2, this._cols - col1 - 2);
            _strMatrix[r][col1 + 1] = "";
        }

        //extending the int counter and the mutex array by one and initiating them 
        Array.Resize(ref this._colReadIntCounter, this._colReadIntCounter.Length + 1);
        Array.Resize(ref this._colReadMutexLock, this._colReadMutexLock.Length + 1);
        Array.Resize(ref this._colWriteMutexLock, this._colWriteMutexLock.Length + 1);
        this._colWriteMutexLock[^1] = new Mutex();
        this._colReadMutexLock[^1] = new Mutex();

        _semaphoreUsers.Release(this._amountUsers);
        this._mutexLockTable.ReleaseMutex();
    }
    public Tuple<int, int>[] findAll(String str,bool caseSensitive)
    {
        // perform search and return all relevant cells according to caseSensitive param
        return search(0, _cols, 0, _rows, str, caseSensitive, false);
    }
    public void setAll(String oldStr, String newStr, bool caseSensitive)
    {
        // replace all oldStr cells with the newStr str according to caseSensitive param
        // includes col1,col2,row1,row2
        //invalid parameters
        if (oldStr == null || newStr == null)
            throw new ArgumentException("invalid argument");

        //need to check if the table is not locked. if not, increment the amount of users in the semaphoreUsers
        this._mutexLockTable.WaitOne();
        for (int user = 0; user < this._amountUsers; user++)
            this._semaphoreUsers.Wait();

        // preventing cols and rows Exchanging
        this._rowExchangingLock.WaitOne();
        this._colExchangingLock.WaitOne();
        

        //searching
        for (var r = 0; r < _rows; r++)
        {
            this._rowReadMutexLock[r].WaitOne();
            if (++_rowReadIntCounter[r] == 1)
                this._rowWriteMutexLock[r].WaitOne();
            this._rowReadMutexLock[r].ReleaseMutex();
            for (var c = 0; c < _cols; c++)
            {
                if ((caseSensitive && oldStr.Equals(_strMatrix[r][c])) || (caseSensitive && oldStr.ToLower().Equals(_strMatrix[r][c].ToLower())))
                    _strMatrix[r][c] = newStr;
            }
            this._rowReadMutexLock[r].WaitOne();
            //last reader release write
            if (--_rowReadIntCounter[r] == 0)
                this._rowWriteMutexLock[r].ReleaseMutex();
            this._rowReadMutexLock[r].ReleaseMutex();
        }

        //release cols and rows exchanging
        this._colExchangingLock.ReleaseMutex();
        this._rowExchangingLock.ReleaseMutex();
        
        this._semaphoreUsers.Release(_amountUsers);
        this._mutexLockTable.ReleaseMutex();
    }
    public Tuple<int, int> getSize()
    {
        // return the size of the spreadsheet in nRows, nCols
        //need to check if the table is not locked. if not, increment the amount of users in the semaphoreUsers
        this._mutexLockTable.WaitOne();
        this._semaphoreUsers.Wait();
        this._mutexLockTable.ReleaseMutex();

        //get size
        int nRows = this._rows;
        int nCols = this._cols;

        //release user
        this._semaphoreUsers.Release();
        return new Tuple<int, int>(nRows, nCols);
    }

    public void save(String fileName)
    {
        // save the spreadsheet to a file fileName.
        // you can decide the format you save the data. There are several options.
        if (fileName == null)
            throw new ArgumentException("invalid argument");
        _mutexLockTable.WaitOne();
        for (int user = 0; user < this._amountUsers; user++)
            this._semaphoreUsers.Wait();
        //saving the data of the table
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            for (int r = 0; r < this._rows; r++)
            {
                for (int c = 0; c < this._cols; c++)
                {
                    //"\t" will use to seperate between each col
                    sw.Write(this._strMatrix[r][c] + "\t");
                }
                //"\n" will use to seperate between each row
                sw.Write("\n");
            }
            sw.Flush();
            sw.Close();
        }

        //release the semaphore all the capacity
        _semaphoreUsers.Release(this._amountUsers);
        //release the table
        _mutexLockTable.ReleaseMutex();
    }
    public void load(String fileName)
    {
        if (fileName == null)
            throw new ArgumentException("invalid argument");

        // load the spreadsheet from fileName
        // replace the data and size of the current spreadsheet with the loaded data
        _mutexLockTable.WaitOne();
        //locking the table 
        for (int i = 0; i < this._amountUsers; i++)
            _mutexLockTable.WaitOne();

        //read once for getting the dimentions of the new table
        using (StreamReader file = new StreamReader(fileName))
        {
            int counter = 0;
            string ln;
            string[] delimiterChars = { "\t", "\n" };

            while ((ln = file.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    //without the /n and /t in the end of the row
                    string[] words = ln.Split(delimiterChars, System.StringSplitOptions.RemoveEmptyEntries);
                    this._cols = words.Length;
                }
                counter++;
            }
            this._rows = counter;
            file.Close();
        }
        //rows and cols will save the amount of rows and cols in the loaded table.

        //updating all semaphores to be in the new size of rows and cols
        _rowReadIntCounter = new int[_rows];
        _colReadIntCounter = new int[_cols];

        _rowWriteMutexLock = new Mutex[_rows];
        for (int r = 0; r < _rows; r++)
            _rowWriteMutexLock[r] = new Mutex();

        _colWriteMutexLock= new Mutex[_cols];
        for (int c = 0; c < _cols; c++)
            _colWriteMutexLock[c] = new Mutex();

        _rowReadMutexLock = new Mutex[_rows];
        for (int r = 0; r < _rowReadMutexLock.Length; r++)
            _rowReadMutexLock[r] = new Mutex();

        _colReadMutexLock = new Mutex[_cols];
        for (int c = 0; c < _colReadMutexLock.Length; c++)
            _colReadMutexLock[c] = new Mutex();

        //updating table to be of the new size from the file
        this._strMatrix = new string[_rows][];
        for (int r = 0; r < _rows; r++)
        {
            _strMatrix[r] = new string[_cols];
            for (int c = 0; c < _cols; c++)
                _strMatrix[r][c] = "";
        }


        //copy the data from the file to the table
        using (StreamReader file = new StreamReader(fileName))
        {
            int counter = 0;
            string ln;
            string[] delimiterChars = { "\t", "\n" };

            while ((ln = file.ReadLine()) != null)
            {

                // without the /n and /t in the end of the row
                string[] words = ln.Split(delimiterChars, System.StringSplitOptions.RemoveEmptyEntries);
                for (int c = 0; c < _cols; c++)
                    _strMatrix[counter][c] = words[c];
                counter++;
            }
            file.Close();
        }

        //release the semaphore all the capacity
        _semaphoreUsers.Release(this._amountUsers);
        //release the table
        _mutexLockTable.ReleaseMutex();
    }
}



