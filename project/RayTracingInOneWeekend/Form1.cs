using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracingInOneWeekend
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //
            this.bmp = Chapter.ch12(this.ClientRectangle.Width, this.ClientRectangle.Height);
            /*
            int i, j;
            int w = bmp.Width;
            int h = bmp.Height;

            int interval = 5;
            //每隔5个像素点画设置一个黑颜色点，生成图片。
            for (i = 0; i < w; i += interval)
            {
                for (j = 0; j < h; j += interval)
                {
                    //使用SetPixel()来设置像素点。
                    bmp.SetPixel(i, j, Color.Black);
                }
            }
            */
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            //显示图片
            graphics.DrawImage(this.bmp, new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
        }
    }
}
