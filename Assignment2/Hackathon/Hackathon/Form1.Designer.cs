﻿namespace Hackathon
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
            userControl11 = new UserControl1();
            SuspendLayout();
            // 
            // userControl11
            // 
            userControl11.BackColor = Color.Transparent;
            userControl11.Location = new Point(-2, 2);
            userControl11.Margin = new Padding(2);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(640, 480);
            userControl11.TabIndex = 0;
            userControl11.Load += userControl11_Load_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(800, 600);
            Controls.Add(userControl11);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private UserControl1 userControl11;
    }
}