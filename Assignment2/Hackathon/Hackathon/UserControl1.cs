using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void northToSouthRate_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int consumerRate = int.Parse(consumerRate_btn.Text);
            int NorthToSouthRate = int.Parse(northToSouthRate_tb.Text);
            dict.Add("NorthToSouth", NorthToSouthRate);
            int NorthToEastRate = int.Parse(northToEastRate_tb.Text);
            dict.Add("NorthToEast", NorthToEastRate);
            int WestToEastRate = int.Parse(westToEastRate_tb.Text);
            dict.Add("WestToEast", WestToEastRate);
            int WestToNorthRate = int.Parse(westToNorthRate_tb.Text);
            dict.Add("WestToNorth", WestToNorthRate);
            int SouthToNorthRate = int.Parse(southToNorthRate_tb.Text);
            dict.Add("SouthToNorth", SouthToNorthRate);
            int SouthToWestRate = int.Parse(southToWestRate_tb.Text);
            dict.Add("SouthToWest", SouthToWestRate);
            int EastToWestRate = int.Parse(eastToWest_tb.Text);
            dict.Add("EastToWest", EastToWestRate);
            int EastToSouthRate = int.Parse(eastToSouthRate_tb.Text);
            dict.Add("EastToSouth", EastToSouthRate);
            Intersection intersection = new Intersection(dict,consumerRate);
            
            Form form = this.FindForm();
            form.Controls.Clear();
            UserControl2 userControl2 = new UserControl2();
            form.Controls.Add(userControl2);
            intersection.StartSimulation();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
