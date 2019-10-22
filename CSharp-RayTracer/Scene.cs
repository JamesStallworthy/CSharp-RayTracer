using System;
using System.Collections.Generic;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class Scene
    {
        public Vector3 cameraLocation;
        public ILight lightSource;
        public List<IShape> shapes = new List<IShape>();

        public void SetLightSource(ILight l){
            lightSource = l;
        }

        public void AddShapeToScene(IShape s){
            shapes.Add(s);
        }
    }
}