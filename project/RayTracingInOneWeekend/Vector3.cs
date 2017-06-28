using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingInOneWeekend
{
    class Vector3
    {
        public float[] e = new float[3];
        public Vector3(Vector3 v) { e[0] = v.e[0]; e[1] = v.e[1]; e[2] = v.e[2]; }
        public Vector3(float _x, float _y, float _z) { e[0] = _x; e[1] = _y; e[2] = _z; }

        public float x() { return e[0]; }
        public float y() { return e[1]; }
        public float z() { return e[2]; }
        public float r() { return e[0]; }
        public float g() { return e[1]; }
        public float b() { return e[2]; }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x() + rhs.x(), lhs.y() + rhs.y(), lhs.z() + rhs.z());
        }
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x() - rhs.x(), lhs.y() - rhs.y(), lhs.z() - rhs.z());
        }
        public float this[int i]{ get { return this.e[i]; } set { this.e[i] = value; } }
        public static Vector3 operator /(Vector3 lhs, float t)
        {
            return new Vector3(lhs.x() / t, lhs.y() / t, lhs.z() / t);
        }
        public static Vector3 operator *(Vector3 lhs, float t)
        {
            return new Vector3(lhs.x() * t, lhs.y() * t, lhs.z() * t);
        }
        public static Vector3 operator *(float t, Vector3 lhs)
        {
            return new Vector3(lhs.x() * t, lhs.y() * t, lhs.z() * t);
        }

        public float length()
        {
            return (float)Math.Sqrt(this.squared_length());
        }
        public float squared_length()
        {
            return e[0] * e[0] + e[1] * e[1] + e[2] * e[2];
        }
        public void Normalized()
        {
            float k = 1 / this.length();
            e[0] *= k;
            e[1] *= k;
            e[2] *= k;
        }
        public Vector3 normalized
        {
            get { Vector3 v = new Vector3(this); v.Normalized(); return v; }
        }

        public static float dot(Vector3 a, Vector3 b)
        {
            return a.x() * b.x() + a.y() * b.y() + a.z() * b.z();
        }

        public static Vector3 cross(Vector3 a, Vector3 b)
        {
            return new Vector3(a.y()*b.z() - a.z()*b.y(), a.x()*b.z()-a.z()*b.x(), a.x()*b.y()-a.y()*b.x());
        }
    }
}
