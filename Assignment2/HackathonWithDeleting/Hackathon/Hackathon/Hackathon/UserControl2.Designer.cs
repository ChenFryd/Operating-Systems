namespace Hackathon
{
    partial class UserControl2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            pictureBox1 = new PictureBox();
            exit_btn = new Button();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(420, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(357, 451);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.Coral;
            this.exit_btn.Location = new System.Drawing.Point(297, 525);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(155, 55);
            this.exit_btn.TabIndex = 1;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Location = new Point(92, 141);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(161, 90);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tw Cen MT Condensed Extra Bold", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(264, 14);
            label1.Name = "label1";
            label1.Size = new Size(184, 44);
            label1.TabIndex = 3;
            label1.Text = "Intersection";
            // 
            // UserControl2
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveBorder;
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(exit_btn);
            Controls.Add(pictureBox1);
            Name = "UserControl2";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button exit_btn;
        private PictureBox pictureBox2;
        private Label label1;
    }
}
