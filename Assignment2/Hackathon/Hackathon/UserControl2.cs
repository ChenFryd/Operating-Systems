using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hackathon
{
    public partial class UserControl2 : UserControl
    {
        private PictureBox pictureBox;
        public UserControl2()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void AddCar(Car car)
        {
            pictureBox.Location = new Point(100, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Image = car.getImage();
            Invoke((MethodInvoker)delegate
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = car.getImage(),
                Width = 100,
                Height = 100
            };

            flowLayoutPanel.Controls.Add(pictureBox);
        }
        public void RemoveCar(Car car) { 
        
        }
        private void exit_btn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            parentForm.Close();
        }
    }
}
