using System;
using System.Collections.Generic;

namespace CSharp_RayTracer
{
    public class Scene
    {
        public List<IShape> shapes = new List<IShape>();

        public void AddShapeToScene(IShape s){
            shapes.Add(s);
        }
    }
}