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
        public Camera(Vector3 lookfrom, Vector3 lookat, Vector3 vup, float vfov, float aspect)
        { // vfov is top to bottom in degrees  
            Vector3 u, v, w;
            float theta = (float)(vfov * Math.PI / 180);
            float half_height = (float)Math.Tan(theta / 2);
            float half_width = aspect * half_height;
            this.origin = lookfrom;
            w = (lookfrom - lookat).normalized;
            u = (Vector3.cross(vup, w)).normalized;
            v = Vector3.cross(w, u);
            this.lower_left_corner = this.origin - half_width * u - half_height * v - w;
            this.horizontal = 2 * half_width * u;
            this.vertical = 2 * half_height * v;
        }
        public Ray getRay(float u, float v)
        {
            // The code here should subtract the origin. if don't, when origin is not (0,0,0) you will get wrong result
            return new Ray(this.origin, this.lower_left_corner+u*this.horizontal+v*this.vertical - this.origin);
        }
    }
}
