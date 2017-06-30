using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingInOneWeekend
{
    struct HitRecord
    {
        public float t;
        public Vector3 p;
        public Vector3 normal;
        public Material mat;
    }

    interface Hitable
    {
        bool hit(Ray r, float t_min, float t_max, ref HitRecord rec);
    }
}
