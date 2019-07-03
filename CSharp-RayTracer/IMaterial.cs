using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public interface IMaterial
    {
        Colour CalculateColour(Ray ray, Scene scene, Vector3 hitLoc, IShape shape);
    }
}