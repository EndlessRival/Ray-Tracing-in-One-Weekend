using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingInOneWeekend
{
    class Sphere : Hitable
    {
        public Vector3 center;
        public float radius;
        public Material mat = new Lambertian(new Vector3(0,0,0));

        //public Sphere() { }
        public Sphere(Vector3 cen, float r) { this.center = cen; this.radius = r; }
        public Sphere(Vector3 cen, float r, Material m) { this.center = cen; this.radius = r; mat = m; }

        public bool hit(Ray r, float t_min, float t_max, ref HitRecord rec)
        {
            Vector3 oc = r.origin() - center;
            float a = Vector3.dot(r.direction(), r.direction());
            float b = 2 * Vector3.dot(oc, r.direction());
            float c = Vector3.dot(oc, oc) - radius * radius;
            float discriminant = b * b - 4 * a * c;
            if(discriminant > 0)
            {
                double temp = (-b - Math.Sqrt(discriminant)) / (2 * a);  //  Incorrect code in the book, should divided by 2a NOT a
                if (t_min <= temp && temp <= t_max)
                {
                    rec.t = (float)temp;
                    rec.p = r.point_at_parameter((float)temp);
                    rec.normal = (rec.p - center) / radius;
                    rec.mat = this.mat;
                    return true;
                }
                temp = (-b + Math.Sqrt(discriminant)) / (2 * a);  //  Incorrect code in the book, should divided by 2a NOT a
                if (t_min <= temp && temp <= t_max)
                {
                    rec.t = (float)temp;
                    rec.p = r.point_at_parameter((float)temp);
                    rec.normal = (rec.p - center) / radius;
                    rec.mat = this.mat;
                    return true;
                }
            }
            return false;
        }

        public static Vector3 random_in_unit_sphere()
        {
            // should NOT use new Random(), if it run fast enough then all rdm use the same seed
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            Vector3 p;
            do
            {
                p = 2 * new Vector3((float)rdm.NextDouble(),
                    (float)rdm.NextDouble(),
                    (float)rdm.NextDouble()) - new Vector3(1, 1, 1);
            } while (p.squared_length() >= 1.0);
            return p;
        }
    }
}
