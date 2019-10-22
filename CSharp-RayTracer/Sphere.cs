using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class Sphere:IShape
    {
        public IMaterial material{get;set;}
        private Vector3 origin;
        private float radius;

        public Sphere(Vector3 _origin, float _radius, IMaterial _material)
        {
            origin = _origin;
            radius = _radius;
            material = _material;
        }

        //Source from:
        //https://medium.com/farouk-ounanes-home-on-the-internet/ray-tracer-in-c-from-scratch-e013269884b6
        public bool Intersection(Ray ray, out float t){
            t=-1;
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

            t = (t1 < t2) ? t1 : t2;
            return true;
        }

        public Vector3 GetOrigin(){
            return origin;
        }
    }
}