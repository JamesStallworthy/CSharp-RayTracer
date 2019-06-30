using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class Renderer
    {
        private Vector3 cameraLocation;
        private IShape shapes;
        private int screenWidth;
        private int screenHeight;
        private float imageAspectRatio;

        private float fov;
        public Renderer(Vector3 _cameraLocation, int _screenWidth , int _screenHeight, int _fov)
        {
            cameraLocation = _cameraLocation;
            screenWidth = _screenWidth;
            screenHeight = _screenHeight;
            fov = _fov;
            imageAspectRatio = (float)screenWidth / (float)screenHeight;

        }

        public float PixelNormalized(int val, int val2){
            return ((float)val + 0.5f)/val2;
        }
        public void Render(){
            Ray primaryRay;

            //Need to comment and figure out this code again.... (Copied from the original C++ implementation i did)
            float remappedX;//Normalised x of pixel
            float remappedY;//Normalised y of pixel
            float worldSpacex;
            float worldSpacey;
            Vector3 pCameraSpace;
            for (int x=0; x < screenWidth; x++){
                for(int y=0; y < screenHeight; y++){
                    remappedX = ((2.0f*PixelNormalized(x,screenWidth) - 1.0f)*imageAspectRatio);
                    remappedY = (1.0f -2.0f*PixelNormalized(y,screenHeight));
                    worldSpacex = remappedX * fov;
                    worldSpacey = remappedY * fov;
                    pCameraSpace = new Vector3(worldSpacex+ cameraLocation.X, worldSpacey + cameraLocation.Y,-1+cameraLocation.Z);
                    Vector3 direction = Vector3.Normalize(pCameraSpace - cameraLocation);

                    primaryRay = new Ray(cameraLocation,direction);

                    Sphere sphere = new Sphere(new Vector3(20,20,20),10);
                    if (sphere.Intersection(primaryRay)){
                        Console.WriteLine(x + " " + y);
                    }
                   
                }
            }
        }
    }
}