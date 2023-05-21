using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
{
    public class Car
    {
        public Image Picture { get; set; }
        public PictureBox pictureBox { get; set; }
        public Car() {
            this.Picture = Image.FromFile("pics/car1.png");
        }

        public void setPictureBox(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }
        public PictureBox getPictureBox()
        {
            return this.pictureBox;
        }
        public Image getImage() { 
            return this.Picture;
        }
        
    }
}
