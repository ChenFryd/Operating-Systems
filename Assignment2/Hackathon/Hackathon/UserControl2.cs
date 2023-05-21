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
        private FlowLayoutPanel flowLayoutPanel;
        public UserControl2()
        {
            InitializeComponent();
            // Create and configure the FlowLayoutPanel
            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.Dock = DockStyle.Fill;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void AddCar(Car car)
        {
            PictureBox pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = car.getImage(),
                Width = 100,
                Height = 100
            };

            flowLayoutPanel.Controls.Add(pictureBox);
        }
    }
}
