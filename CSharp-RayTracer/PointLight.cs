using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class PointLight:ILight
    {
        public Vector3 origin;

        public PointLight(Vector3 _origin)
        {
            origin = _origin;
        }

        public Vector3 getOrigin(){
            return origin;
        }
    }
}