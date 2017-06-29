using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingInOneWeekend
{
    class Camera
    {
        public Vector3 origin, lower_left_corner, horizontal, vertical;
        public Camera()
        {
            this.lower_left_corner = new Vector3(-2, -1, -1);
            this.horizontal = new Vector3(4, 0, 0);
            this.vertical = new Vector3(0, 2, 0);
            this.origin = new Vector3(0, 0, 0);
        }
        public Ray getRay(float u, float v)
        {
            // oops, the code in book here substruct this.origin, should be a typo
            return new Ray(this.origin, this.lower_left_corner+u*this.horizontal+v*this.vertical);
        }
    }
}
