using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowManager window = new WindowManager(500,500, "CSharp_RayTracer");
            window.testRender();

            while (true){
                if (window.EventLoop()){
                    break;
                }
            }
            Renderer test = new Renderer(new Vector3(0,0,0),500,500,80);
            test.Render();
        }
    }
}
