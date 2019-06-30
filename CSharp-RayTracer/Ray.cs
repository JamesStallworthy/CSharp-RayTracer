using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class Ray{
        private Vector3 org;
        private Vector3 dir;
        public Ray(Vector3 _org, Vector3 _dir)
        {
            org = _org;
            dir = Vector3.Normalize(_dir);
        }

        public Vector3 GetOrg(){
            return org;
        }
        public Vector3 GetDir(){
            return dir;
        }
    }
}