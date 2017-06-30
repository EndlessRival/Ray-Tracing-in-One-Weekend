using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingInOneWeekend
{
    class Metal : Material
    {
        Vector3 albedo;
        public Metal(Vector3 _albedo) { this.albedo = _albedo; }
        public bool scatter(Ray r, HitRecord rec, ref Vector3 attattenuation, ref Ray scattered)
        {
            Vector3 reflected = Vector3.reflect(r.direction().normalized, rec.normal);
            scattered = new Ray(rec.p, reflected);
            attattenuation = albedo;
            return Vector3.dot(reflected, rec.normal) > 0;
        }
    }
}
