using ScreenShoter.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShoter.Forms
{
    public partial class SelectionBox : Form
    {
        public SelectionBox()
        {
            InitializeComponent();
        }

        private void btnMakeScrFromArea_Click(object sender, EventArgs e)
        {
            this.Hide();

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, new Size(pictureBox1.Width, pictureBox1.Height));
            }

            CaptureControl.CaptFromArea(bmp);
        }
    }
}
