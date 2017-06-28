using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingInOneWeekend
{
    class Ray
    {
        Vector3 A, B;
        public Ray() { }
        public Ray(Vector3 a,Vector3 b) { A = a; B = b; }
        public Vector3 origin() { return A; }
        public Vector3 direction() { return B; }
        public Vector3 point_at_parameter(float t) { return A + B*t; }
    }
}
