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
using Application = System.Windows.Forms.Application;
using Image = System.Drawing.Image;

namespace Hackathon
{


    public partial class UserControl2 : UserControl
    {
        private PictureBox pictureBox;

        public event EventHandler ExitButtonClicked;
        public UserControl2()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void AddCar(Car car, String direction)
        {
            if (IsDisposed)
            {
                return; // Exit the method if the control is disposed
            }
            PictureBox pictureBox = new PictureBox();
            car.setPictureBox(pictureBox);
            Image image = car.getImage();
            // Calculate the new size while maintaining the aspect ratio
            int desiredWidth = 50; // Set the desired width of the image
            int desiredHeight = (int)((float)desiredWidth / image.Width * image.Height);

            // Resize the image
            Image resizedImage = new Bitmap(image, desiredWidth, desiredHeight);

            // Set the resized image in the PictureBox
            pictureBox.Image = resizedImage;

            // Set the SizeMode property to adjust the image display
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust the size mode as required

            pictureBox.Size = pictureBox.Image.Size;

            switch (direction)
            {
                case "NorthToSouth":
                    pictureBox.Location = new Point(300, 200);
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    pictureBox.Image = new Bitmap(pictureBox.Image, desiredHeight, desiredWidth);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = pictureBox.Image.Size;
                    break;
                case "NorthToEast":
                    pictureBox.Location = new Point(330, 200);
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = pictureBox.Image.Size;
                    break;
                case "SouthToNorth":
                    pictureBox.Location = new Point(465, 360);
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    pictureBox.Image = new Bitmap(pictureBox.Image, desiredHeight, desiredWidth);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = pictureBox.Image.Size;
                    break;
                case "SouthToWest":
                    pictureBox.Location = new Point(400, 360);
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = pictureBox.Image.Size;
                    break;
                case "EastToWest":
                    pictureBox.Location = new Point(500, 244);
                    break;
                case "WestToEast":
                    pictureBox.Location = new Point(200, 320);
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = pictureBox.Image.Size;
                    break;
                case "WestToNorth":
                    pictureBox.Location = new Point(200, 300);
                    pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Size = pictureBox.Image.Size;
                    break;
                
                case "EastToSouth":
                    pictureBox.Location = new Point(500, 280);
                    break;
                
            }
            pictureBox.BringToFront();

            if (IsDisposed)
            {
                return; // Exit the method if the control is disposed
            }

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    if (!IsDisposed)
                    {
                        Controls.Add(pictureBox);
                        pictureBox.BringToFront();
                    }

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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
