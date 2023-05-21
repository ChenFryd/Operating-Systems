using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
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
        private const int radius = 100;  // Radius of the circular path
        private const int centerX = 200; // X-coordinate of the circle's center
        private const int centerY = 200; // Y-coordinate of the circle's center
        private double angle = 0;       // Current angle in radians

        private System.Windows.Forms.Timer timer;            // Timer to update the object's position

        public UserControl2()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void AddCar(Car car,String direction)
        {
            if (IsDisposed)
            {
                return; // Exit the method if the control is disposed
            }
            PictureBox pictureBox = new PictureBox();
            car.setPictureBox(pictureBox);
            switch (direction)
            {
                case "NorthToSouth":
                    pictureBox.Location = new Point(100, 0);
                    break;
                case "SouthToNorth":
                    pictureBox.Location = new Point(100, 500);
                    break;
                case "EastToWest":
                    pictureBox.Location = new Point(0, 100);
                    break;
                case "WestToEast":
                    pictureBox.Location = new Point(500, 100);
                    break;
                case "WestToNorth":
                    pictureBox.Location = new Point(500, 500);
                    break;
                case "NorthToEast":
                    pictureBox.Location = new Point(0, 0);
                    break;
                case "EastToSouth":
                    pictureBox.Location = new Point(0, 500);
                    break;
                case "SouthToWest":
                    pictureBox.Location = new Point(500, 0);
                    break;
            }
            //pictureBox.Location = new Point(100, 100);
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
        public void RemoveCar(Car car, String direction)
        {
            Controls.Remove(car.getPictureBox());
        }
        private void exit_btn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            parentForm.Close();
        }
    }
}
