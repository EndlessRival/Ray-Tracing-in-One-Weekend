using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingInOneWeekend
{
    class Dielectric : Material
    {
        public float ref_idx;
        public Dielectric(float _idx) { this.ref_idx = _idx; }
        public bool scatter(Ray r, HitRecord rec, ref Vector3 attattenuation, ref Ray scattered)
        {
            attattenuation = new Vector3(1, 1, 1);
            Vector3 outward_normal = new Vector3();
            float ni_over_nt;
            Vector3 attenuation = new Vector3(1, 1, 1);
            double reflect_prob;
            float cosine;
            if (Vector3.dot(r.direction(), rec.normal) > 0 )
            {
                outward_normal = -rec.normal;
                ni_over_nt = ref_idx;
                cosine = ref_idx * Vector3.dot(r.direction(), rec.normal) / r.direction().length();
            }
            else
            {
                outward_normal = rec.normal;
                ni_over_nt = 1.0f / ref_idx;
                cosine = -Vector3.dot(r.direction(), rec.normal) / r.direction().length();
            }
            Vector3 refracted = null;
            if (Vector3.refract(r.direction(), outward_normal, ni_over_nt, ref refracted))
            {
                //scattered = new Ray(rec.p, refracted);
                reflect_prob = schlick(cosine, ref_idx);
            }
            else
            {
                //scattered = new Ray(rec.p, Vector3.reflect(r.direction(), rec.normal));
                //return false;
                reflect_prob = 1.0;
            }
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            if (rdm.NextDouble() < (double)reflect_prob)
            {
                scattered = new Ray(rec.p, Vector3.reflect(r.direction(), rec.normal));
            }
            else
            {
                scattered = new Ray(rec.p, refracted);
            }
            return true;
        }

        public static float schlick(float cosine, float ref_idx)
        {
            float r0 = (1 - ref_idx) / (1 + ref_idx);
            r0 = r0 * r0;
            return (float)(r0 + (1 - r0) * Math.Pow((1 - cosine), 5));
        }
    }
}
