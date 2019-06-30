using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class Sphere:IShape
    {
        private Vector3 origin;
        private float radius;

        public Sphere(Vector3 _origin, float _radius)
        {
            origin = _origin;
            radius = _radius;
        }

        //Source from:
        //https://medium.com/farouk-ounanes-home-on-the-internet/ray-tracer-in-c-from-scratch-e013269884b6
        public bool Intersection(Ray ray){
            Vector3 o = ray.GetOrg();
            Vector3 d = ray.GetDir();
            
            Vector3 v = o - origin;

            float b = 2.0f * Vector3.Dot(v,d);
            float c = Vector3.Dot(v,v) - radius*radius;
            float delta = b*b - 4 * c;

            if (delta < 1e-4)
                return false;

            float t1 = (-b - (float)Math.Sqrt(delta))/2;
            float t2 = (-b + (float)Math.Sqrt(delta))/2;

            var t = (t1 < t2) ? t1 : t2;
            return true;
        }
    }
}