namespace WinFormsApp1
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.northToSouthRate_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.northToEastRate_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.westToEastRate_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.westToNorthRate_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.southToWestRate_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.eastToWest_tb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.eastToSouthRate_tb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.consumerRate_btn = new System.Windows.Forms.TextBox();
            this.start_btn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.southToNorthRate_tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producer north to south line rate:\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // northToSouthRate_tb
            // 
            this.northToSouthRate_tb.Location = new System.Drawing.Point(402, 96);
            this.northToSouthRate_tb.Name = "northToSouthRate_tb";
            this.northToSouthRate_tb.Size = new System.Drawing.Size(311, 31);
            this.northToSouthRate_tb.TabIndex = 1;
            this.northToSouthRate_tb.TextChanged += new System.EventHandler(this.northToSouthRate_tb_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(70, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Producer north to east line rate:\r\n";
            // 
            // northToEastRate_tb
            // 
            this.northToEastRate_tb.Location = new System.Drawing.Point(402, 140);
            this.northToEastRate_tb.Name = "northToEastRate_tb";
            this.northToEastRate_tb.Size = new System.Drawing.Size(311, 31);
            this.northToEastRate_tb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(70, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Producer west to east line rate:\r\n";
            // 
            // westToEastRate_tb
            // 
            this.westToEastRate_tb.Location = new System.Drawing.Point(402, 186);
            this.westToEastRate_tb.Name = "westToEastRate_tb";
            this.westToEastRate_tb.Size = new System.Drawing.Size(311, 31);
            this.westToEastRate_tb.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(70, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Producer west to north line rate:\r\n";
            // 
            // westToNorthRate_tb
            // 
            this.westToNorthRate_tb.Location = new System.Drawing.Point(402, 233);
            this.westToNorthRate_tb.Name = "westToNorthRate_tb";
            this.westToNorthRate_tb.Size = new System.Drawing.Size(311, 31);
            this.westToNorthRate_tb.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(70, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(291, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Producer south to west line rate:\r\n";
            // 
            // southToWestRate_tb
            // 
            this.southToWestRate_tb.Location = new System.Drawing.Point(402, 277);
            this.southToWestRate_tb.Name = "southToWestRate_tb";
            this.southToWestRate_tb.Size = new System.Drawing.Size(311, 31);
            this.southToWestRate_tb.TabIndex = 9;
            this.southToWestRate_tb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(70, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(283, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Producer east to west line rate:\r\n";
            // 
            // eastToWest_tb
            // 
            this.eastToWest_tb.Location = new System.Drawing.Point(402, 362);
            this.eastToWest_tb.Name = "eastToWest_tb";
            this.eastToWest_tb.Size = new System.Drawing.Size(311, 31);
            this.eastToWest_tb.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tw Cen MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(70, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(288, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Producer east to south line rate:\r\n";
            // 
            // eastToSouthRate_tb
            // 
            this.eastToSouthRate_tb.Location = new System.Drawing.Point(402, 404);
            this.eastToSouthRate_tb.Name = "eastToSouthRate_tb";
            this.eastToSouthRate_tb.Size = new System.Drawing.Size(311, 31);
            this.eastToSouthRate_tb.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tw Cen MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(70, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Consumer rate:\r\n";
            // 
            // consumerRate_btn
            // 
            this.consumerRate_btn.Location = new System.Drawing.Point(402, 447);
            this.consumerRate_btn.Name = "consumerRate_btn";
            this.consumerRate_btn.Size = new System.Drawing.Size(311, 31);
            this.consumerRate_btn.TabIndex = 15;
            // 
            // start_btn
            // 
            this.start_btn.BackColor = System.Drawing.Color.Coral;
            this.start_btn.Location = new System.Drawing.Point(297, 525);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(155, 55);
            this.start_btn.TabIndex = 16;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(265, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(218, 51);
            this.label9.TabIndex = 17;
            this.label9.Text = "Intersection";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tw Cen MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(70, 327);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(296, 25);
            this.label10.TabIndex = 18;
            this.label10.Text = "Producer south to north line rate:\r\n";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // southToNorthRate_tb
            // 
            this.southToNorthRate_tb.Location = new System.Drawing.Point(402, 321);
            this.southToNorthRate_tb.Name = "southToNorthRate_tb";
            this.southToNorthRate_tb.Size = new System.Drawing.Size(311, 31);
            this.southToNorthRate_tb.TabIndex = 19;
            // 
            // UserControl1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.southToNorthRate_tb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.consumerRate_btn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.eastToSouthRate_tb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.eastToWest_tb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.southToWestRate_tb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.westToNorthRate_tb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.westToEastRate_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.northToEastRate_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.northToSouthRate_tb);
            this.Controls.Add(this.label1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox northToSouthRate_tb;
        private Label label2;
        private TextBox northToEastRate_tb;
        private Label label3;
        private TextBox westToEastRate_tb;
        private Label label4;
        private TextBox westToNorthRate_tb;
        private Label label5;
        private TextBox southToWestRate_tb;
        private Label label6;
        private TextBox eastToWest_tb;
        private Label label7;
        private TextBox eastToSouthRate_tb;
        private Label label8;
        private TextBox consumerRate_btn;
        private Button start_btn;
        private Label label9;
        private Label label10;
        private TextBox southToNorthRate_tb;
    }
}
