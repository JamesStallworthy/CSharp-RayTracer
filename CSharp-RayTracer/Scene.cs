using System;
using System.Collections.Generic;

namespace CSharp_RayTracer
{
    public class Scene
    {
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