using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingInOneWeekend
{
    interface Material
    {
        bool scatter(Ray r, HitRecord rec, ref Vector3 attattenuation, ref Ray scattered);
    }
}
