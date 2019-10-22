using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class PointLight:ILight
    {
        private Vector3 origin;
        private Colour colour = new Colour(255,255,255);

        public PointLight(Vector3 _origin)
        {
            origin = _origin;
        }

        public Vector3 GetOrigin(){
            return origin;
        }

        public Colour GetColour(){
            return colour;
        }
    }
}