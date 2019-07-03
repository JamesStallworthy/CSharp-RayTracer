using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public interface IShape
    {
        IMaterial material{get;set;}
        bool Intersection(Ray ray, out float t);

        Vector3 getOrigin();
    }
}