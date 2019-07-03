using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class MaterialSolidShaded:IMaterial
    {
        private Colour colour;

        public MaterialSolidShaded(Colour _colour)
        {
            colour = _colour;
        }

        public Colour CalculateColour(Ray ray, Scene scene, Vector3 hitLoc, IShape shape){
            return colour;
        }
    }
}