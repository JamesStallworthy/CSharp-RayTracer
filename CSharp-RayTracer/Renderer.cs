using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class Renderer
    {
        private Vector3 cameraLocation;
        private int screenWidth;
        private int screenHeight;
        private float imageAspectRatio;
        private Colour[,] pixelArray;
        private float fov;
        Scene s;
        public Renderer(Vector3 _cameraLocation, int _screenWidth , int _screenHeight, int _fov)
        {
            cameraLocation = _cameraLocation;
            screenWidth = _screenWidth;
            screenHeight = _screenHeight;
            fov = (float)Math.Tan((_fov * 3.14 / 180) / 2);
            imageAspectRatio = (float)screenWidth / (float)screenHeight;
            pixelArray = new Colour[_screenWidth,_screenHeight];
            s = new Scene();
        }

        public float PixelNormalized(int val, int val2){
            return ((float)val + 0.5f)/val2;
        }
        public Colour[,] Render(){
            Ray primaryRay;

            s.AddShapeToScene(new Sphere(new Vector3(5,5,50),10,new MaterialFlatShaded(new Colour(0,255,0))));
            s.AddShapeToScene(new Sphere(new Vector3(0,0,40),10,new MaterialFlatShaded(new Colour(0,0,255))));

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
                    Vector3 direction = Vector3.Normalize(cameraLocation - pCameraSpace);
                    primaryRay = new Ray(cameraLocation,direction);

                    pixelArray[x,y] = primaryRay.CalculateIntersection(s);
                }
            }
            return pixelArray;
        }
    }
}