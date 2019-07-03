using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public interface ILight
    {
        Vector3 getOrigin();
    }
}