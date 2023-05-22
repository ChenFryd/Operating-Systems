namespace Hackathon
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
            label1 = new Label();
            northToSouthRate_tb = new TextBox();
            label2 = new Label();
            northToEastRate_tb = new TextBox();
            label3 = new Label();
            westToEastRate_tb = new TextBox();
            label4 = new Label();
            westToNorthRate_tb = new TextBox();
            label5 = new Label();
            southToWestRate_tb = new TextBox();
            label6 = new Label();
            eastToWest_tb = new TextBox();
            label7 = new Label();
            eastToSouthRate_tb = new TextBox();
            label8 = new Label();
            consumerRate_btn = new TextBox();
            start_btn = new Button();
            label9 = new Label();
            label10 = new Label();
            southToNorthRate_tb = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(70, 99);
            label1.Name = "label1";
            label1.Size = new Size(252, 22);
            label1.TabIndex = 0;
            label1.Text = "Producer north to south line rate:\r\n";
            label1.Click += label1_Click;
            // 
            // northToSouthRate_tb
            // 
            northToSouthRate_tb.Location = new Point(402, 96);
            northToSouthRate_tb.Name = "northToSouthRate_tb";
            northToSouthRate_tb.Size = new Size(311, 27);
            northToSouthRate_tb.TabIndex = 1;
            northToSouthRate_tb.TextChanged += northToSouthRate_tb_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(70, 143);
            label2.Name = "label2";
            label2.Size = new Size(246, 22);
            label2.TabIndex = 2;
            label2.Text = "Producer north to east line rate:\r\n";
            // 
            // northToEastRate_tb
            // 
            northToEastRate_tb.Location = new Point(402, 140);
            northToEastRate_tb.Name = "northToEastRate_tb";
            northToEastRate_tb.Size = new Size(311, 27);
            northToEastRate_tb.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(70, 189);
            label3.Name = "label3";
            label3.Size = new Size(243, 22);
            label3.TabIndex = 4;
            label3.Text = "Producer west to east line rate:\r\n";
            // 
            // westToEastRate_tb
            // 
            westToEastRate_tb.Location = new Point(402, 186);
            westToEastRate_tb.Name = "westToEastRate_tb";
            westToEastRate_tb.Size = new Size(311, 27);
            westToEastRate_tb.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(70, 239);
            label4.Name = "label4";
            label4.Size = new Size(249, 22);
            label4.TabIndex = 6;
            label4.Text = "Producer west to north line rate:\r\n";
            // 
            // westToNorthRate_tb
            // 
            westToNorthRate_tb.Location = new Point(402, 233);
            westToNorthRate_tb.Name = "westToNorthRate_tb";
            westToNorthRate_tb.Size = new Size(311, 27);
            westToNorthRate_tb.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(70, 283);
            label5.Name = "label5";
            label5.Size = new Size(249, 22);
            label5.TabIndex = 8;
            label5.Text = "Producer south to west line rate:\r\n";
            // 
            // southToWestRate_tb
            // 
            southToWestRate_tb.Location = new Point(402, 277);
            southToWestRate_tb.Name = "southToWestRate_tb";
            southToWestRate_tb.Size = new Size(311, 27);
            southToWestRate_tb.TabIndex = 9;
            southToWestRate_tb.TextChanged += textBox1_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(70, 368);
            label6.Name = "label6";
            label6.Size = new Size(243, 22);
            label6.TabIndex = 10;
            label6.Text = "Producer east to west line rate:\r\n";
            // 
            // eastToWest_tb
            // 
            eastToWest_tb.Location = new Point(402, 362);
            eastToWest_tb.Name = "eastToWest_tb";
            eastToWest_tb.Size = new Size(311, 27);
            eastToWest_tb.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(70, 410);
            label7.Name = "label7";
            label7.Size = new Size(246, 22);
            label7.TabIndex = 12;
            label7.Text = "Producer east to south line rate:\r\n";
            // 
            // eastToSouthRate_tb
            // 
            eastToSouthRate_tb.Location = new Point(402, 404);
            eastToSouthRate_tb.Name = "eastToSouthRate_tb";
            eastToSouthRate_tb.Size = new Size(311, 27);
            eastToSouthRate_tb.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(70, 453);
            label8.Name = "label8";
            label8.Size = new Size(122, 22);
            label8.TabIndex = 14;
            label8.Text = "Consumer rate:\r\n";
            // 
            // consumerRate_btn
            // 
            consumerRate_btn.Location = new Point(402, 447);
            consumerRate_btn.Name = "consumerRate_btn";
            consumerRate_btn.Size = new Size(311, 27);
            consumerRate_btn.TabIndex = 15;
            // 
            // start_btn
            // 
            start_btn.BackColor = Color.Coral;
            start_btn.Location = new Point(308, 510);
            start_btn.Name = "start_btn";
            start_btn.Size = new Size(155, 55);
            start_btn.TabIndex = 16;
            start_btn.Text = "Start";
            start_btn.UseVisualStyleBackColor = false;
            start_btn.Click += start_btn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Tw Cen MT Condensed Extra Bold", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(265, 12);
            label9.Name = "label9";
            label9.Size = new Size(184, 44);
            label9.TabIndex = 17;
            label9.Text = "Intersection";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Tw Cen MT", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(70, 327);
            label10.Name = "label10";
            label10.Size = new Size(252, 22);
            label10.TabIndex = 18;
            label10.Text = "Producer south to north line rate:\r\n";
            label10.Click += label10_Click;
            // 
            // southToNorthRate_tb
            // 
            southToNorthRate_tb.Location = new Point(402, 321);
            southToNorthRate_tb.Name = "southToNorthRate_tb";
            southToNorthRate_tb.Size = new Size(311, 27);
            southToNorthRate_tb.TabIndex = 19;
            // 
            // UserControl1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(southToNorthRate_tb);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(start_btn);
            Controls.Add(consumerRate_btn);
            Controls.Add(label8);
            Controls.Add(eastToSouthRate_tb);
            Controls.Add(label7);
            Controls.Add(eastToWest_tb);
            Controls.Add(label6);
            Controls.Add(southToWestRate_tb);
            Controls.Add(label5);
            Controls.Add(westToNorthRate_tb);
            Controls.Add(label4);
            Controls.Add(westToEastRate_tb);
            Controls.Add(label3);
            Controls.Add(northToEastRate_tb);
            Controls.Add(label2);
            Controls.Add(northToSouthRate_tb);
            Controls.Add(label1);
            Name = "UserControl1";
            Size = new Size(800, 600);
            Load += UserControl1_Load;
            ResumeLayout(false);
            PerformLayout();
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
