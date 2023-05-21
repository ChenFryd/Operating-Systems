using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace Hackathon
{
    public partial class UserControl2 : UserControl
    {
        private PictureBox pictureBox;
        public UserControl2()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void AddCar(Car car)
        {
            if (IsDisposed)
            {
                return; // Exit the method if the control is disposed
            }
            pictureBox = new PictureBox();
            pictureBox.Location = new Point(100, 100);
            //pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Image image = car.getImage();
            // Calculate the new size while maintaining the aspect ratio
            int desiredWidth = 200; // Set the desired width of the image
            int desiredHeight = (int)((float)desiredWidth / image.Width * image.Height);

            // Resize the image
            Image resizedImage = new Bitmap(image, desiredWidth, desiredHeight);

            // Set the resized image in the PictureBox
            pictureBox.Image = resizedImage;

            // Set the SizeMode property to adjust the image display
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust the size mode as required
                                                                   // Add the PictureBox to the user control
            if (IsDisposed)
            {
                return; // Exit the method if the control is disposed
            }

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    if (!IsDisposed)
                        Controls.Add(pictureBox);
                });
            }
            else
            {
                Controls.Add(pictureBox);
            }

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
