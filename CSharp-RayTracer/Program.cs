using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowManager window = new WindowManager(500,500, "CSharp_RayTracer");
        
            Scene s = new Scene();
            
            s.AddShapeToScene(new Sphere(new Vector3(20,0,40),10,new MaterialPhong(new Colour(0,0,255),0.5f,0.08f,0.5f,500.0f)));
            s.AddShapeToScene(new Sphere(new Vector3(0,0,40),10,new MaterialPhong(new Colour(0,255,0),0.5f,0.08f,0.5f,50.0f)));
            s.AddShapeToScene(new Sphere(new Vector3(-20,0,41),10,new MaterialSolidShaded(new Colour(255,0,0))));

            s.SetLightSource(new PointLight(new Vector3(10,0,20)));

            Renderer renderer = new Renderer(new Vector3(0,0,0),500,500,80,s);
            window.Render(renderer.Render());

            while (true){
                if (window.EventLoop()){
                    break;
                }
            }
            
        }
    }
}
