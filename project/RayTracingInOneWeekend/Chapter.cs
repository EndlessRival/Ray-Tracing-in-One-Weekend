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
            for (int j = 0; j < height; ++j)
                for (int i = 0; i < width; ++i)
                {
                    r = (float)i / (float)width;
                    g = (float)j / (float)height;
                    b = 0.2f;
                    ir = (int)(r * 255.99);
                    ig = (int)(g * 255.99);
                    ib = (int)(b * 255.99);
                    bmp.SetPixel(i, height - j - 1, Color.FromArgb(ir, ig, ib));    // winForm's origin is top-left, so y-axis should be (height-j-1)
                }

            return bmp;
        }

        static public Bitmap ch2(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

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

        static private Vector3 ch3_color(Ray r)
        {
            float t = (r.direction().normalized.y() + 1.0f) * 0.5f;
            return new Vector3(1.0f, 1.0f, 1.0f) * (1 - t) + new Vector3(0.5f, 0.7f, 1.0f) * t;
        }
        static public Bitmap ch3(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            Vector3 lower_left_corner = new Vector3(-2, -1, -1);
            Vector3 horizontal = new Vector3(4, 0, 0);
            Vector3 vertical = new Vector3(0, 2, 0);
            Vector3 origin = new Vector3(0, 0, 0);

            float u, v;
            int ir, ig, ib;
            Vector3 col;
            for (int j = 0; j < height; ++j)
                for (int i = 0; i < width; ++i)
                {
                    u = (float)i / (float)width;
                    v = (float)j / (float)height;
                    col = ch3_color(new Ray(origin, lower_left_corner + horizontal * u + vertical * v));
                    ir = (int)(col.r() * 255.99);
                    ig = (int)(col.g() * 255.99);
                    ib = (int)(col.b() * 255.99);
                    bmp.SetPixel(i, height - j - 1, Color.FromArgb(ir, ig, ib));
                }

            return bmp;
        }

        static private bool ch4_hit_sphere(Vector3 center, float radius, Ray ray)
        {
            Vector3 oc = ray.origin() - center;
            float a = Vector3.dot(ray.direction(), ray.direction());
            float b = 2 * Vector3.dot(oc, ray.direction());
            float c = Vector3.dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            return discriminant > 0;
        }
        static private Vector3 ch4_color(Ray r)
        {
            if (ch4_hit_sphere(new Vector3(0, 0, -1), 0.5f, r))
                return new Vector3(1, 0, 0);
            float t = (r.direction().normalized.y() + 1.0f) * 0.5f;
            return new Vector3(1.0f, 1.0f, 1.0f) * (1 - t) + new Vector3(0.5f, 0.7f, 1.0f) * t;
        }
        static public Bitmap ch4(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            Vector3 lower_left_corner = new Vector3(-2, -1, -1);
            Vector3 horizontal = new Vector3(4, 0, 0);
            Vector3 vertical = new Vector3(0, 2, 0);
            Vector3 origin = new Vector3(0, 0, 0);

            float u, v;
            int ir, ig, ib;
            Vector3 col;
            for (int j = 0; j < height; ++j)
                for (int i = 0; i < width; ++i)
                {
                    u = (float)i / (float)width;
                    v = (float)j / (float)height;
                    col = ch4_color(new Ray(origin, lower_left_corner + horizontal * u + vertical * v));
                    ir = (int)(col.r() * 255.99);
                    ig = (int)(col.g() * 255.99);
                    ib = (int)(col.b() * 255.99);
                    bmp.SetPixel(i, height - j - 1, Color.FromArgb(ir, ig, ib));
                }

            return bmp;
        }

        /*
        static private float ch5_hit_sphere(Vector3 center, float radius, Ray ray)
        {
            Vector3 oc = ray.origin() - center;
            float a = Vector3.dot(ray.direction(), ray.direction());
            float b = 2 * Vector3.dot(oc, ray.direction());
            float c = Vector3.dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
                return -1.0f;
            else
                return -b - (float)Math.Sqrt(discriminant) / (2 * a);
        }
        */
        static private Vector3 ch5_color(Ray r, HitableList hitableList)
        {
            HitRecord rec = new HitRecord();
            if (hitableList.hit(r, 0.0f, float.MaxValue, ref rec))
            {
                return 0.5f * new Vector3(rec.normal.x() + 1, rec.normal.y() + 1, rec.normal.z() + 1);
            }
            else
            {
                float t = 0.5f * (r.direction().normalized.y() + 1);
                return new Vector3(1.0f, 1.0f, 1.0f) * (1 - t) + new Vector3(0.5f, 0.7f, 1.0f) * t;
            }
        }
        static public Bitmap ch5(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            Vector3 lower_left_corner = new Vector3(-2, -1, -1);
            Vector3 horizontal = new Vector3(4, 0, 0);
            Vector3 vertical = new Vector3(0, 2, 0);
            Vector3 origin = new Vector3(0, 0, 0);

            float u, v;
            int ir, ig, ib;
            Vector3 col;

            Hitable[] objList = new Hitable[2];
            objList[0] = new Sphere(new Vector3(0,0,-1), 0.5f);
            objList[1] = new Sphere(new Vector3(0,-100.5f, -1), 100);
            HitableList hitableList = new HitableList(objList);

            for (int j = 0; j < height; ++j)
                for (int i = 0; i < width; ++i)
                {
                    u = (float)i / (float)width;
                    v = (float)j / (float)height;
                    col = ch5_color(new Ray(origin, lower_left_corner + horizontal * u + vertical * v), hitableList);
                    ir = (int)(col.r() * 255.99);
                    ig = (int)(col.g() * 255.99);
                    ib = (int)(col.b() * 255.99);
                    bmp.SetPixel(i, height - j - 1, Color.FromArgb(ir, ig, ib));
                }

            return bmp;
        }
    }
}
