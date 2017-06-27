using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RayTracingInOneWeekend
{
    class Chapter
    {
        static public Bitmap ch1(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            float r, g, b;
            int ir, ig, ib;
            for(int j = 0; j < height; ++j)
                for(int i = 0; i < width; ++i)
                {
                    r = (float)i / (float)width;
                    g = (float)j / (float)height;
                    b = 0.2f;
                    ir = (int)(r * 255.99);
                    ig = (int)(g * 255.99);
                    ib = (int)(b * 255.99);
                    bmp.SetPixel(i, height-j-1, Color.FromArgb(ir, ig, ib));    // winForm's orginal is left-top, so y-axis should be (height-j-1)
                }

            return bmp;
        }

        static public Bitmap ch2(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            float r, g, b;
            int ir, ig, ib;
            for (int j = 0; j < height; ++j)
                for (int i = 0; i < width; ++i)
                {
                    Vector3 col = new Vector3((float)i / (float)width, (float)j / (float)height, 0.2f);
                    ir = (int)(col.r() * 255.99);
                    ig = (int)(col.g() * 255.99);
                    ib = (int)(col.b() * 255.99);
                    bmp.SetPixel(i, height - j - 1, Color.FromArgb(ir, ig, ib));
                }

            return bmp;
        }
    }
}
