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
        public Car() {
            this.Picture = Image.FromFile("pics/car1.png");
        }
        public Image getImage() { 
            return this.Picture;
        }
        
    }
}
