namespace DDoSAttack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNumBrowsers = new System.Windows.Forms.TextBox();
            this.tbTargetURL = new System.Windows.Forms.TextBox();
            this.btnStartDDoSAttack = new System.Windows.Forms.Button();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbInvalid = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attack with";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Browsers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Target URL:";
            // 
            // tbNumBrowsers
            // 
            this.tbNumBrowsers.Location = new System.Drawing.Point(118, 46);
            this.tbNumBrowsers.Name = "tbNumBrowsers";
            this.tbNumBrowsers.Size = new System.Drawing.Size(150, 31);
            this.tbNumBrowsers.TabIndex = 3;
            // 
            // tbTargetURL
            // 
            this.tbTargetURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTargetURL.Location = new System.Drawing.Point(118, 101);
            this.tbTargetURL.Name = "tbTargetURL";
            this.tbTargetURL.Size = new System.Drawing.Size(511, 31);
            this.tbTargetURL.TabIndex = 4;
            // 
            // btnStartDDoSAttack
            // 
            this.btnStartDDoSAttack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartDDoSAttack.Location = new System.Drawing.Point(3, 3);
            this.btnStartDDoSAttack.Name = "btnStartDDoSAttack";
            this.btnStartDDoSAttack.Size = new System.Drawing.Size(611, 34);
            this.btnStartDDoSAttack.TabIndex = 5;
            this.btnStartDDoSAttack.Text = "Start DDoS Attack";
            this.btnStartDDoSAttack.UseVisualStyleBackColor = true;
            this.btnStartDDoSAttack.Click += new System.EventHandler(this.btnStartDDoSAttack_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAll.Location = new System.Drawing.Point(3, 43);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(611, 34);
            this.btnCloseAll.TabIndex = 6;
            this.btnCloseAll.Text = "Close All";
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnStartDDoSAttack, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCloseAll, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 198);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(617, 80);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lbInvalid
            // 
            this.lbInvalid.AutoSize = true;
            this.lbInvalid.Location = new System.Drawing.Point(12, 154);
            this.lbInvalid.Name = "lbInvalid";
            this.lbInvalid.Size = new System.Drawing.Size(0, 25);
            this.lbInvalid.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 290);
            this.Controls.Add(this.lbInvalid);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tbTargetURL);
            this.Controls.Add(this.tbNumBrowsers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(663, 346);
            this.Name = "Form1";
            this.Text = "MultiProcess DDoS Attack";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbNumBrowsers;
        private TextBox tbTargetURL;
        private Button btnStartDDoSAttack;
        private Button btnCloseAll;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lbInvalid;
    }
}