using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class Ray{
        private Vector3 org;
        private Vector3 dir;
        public Ray(Vector3 _org, Vector3 _dir)
        {
            org = _org;
            dir = Vector3.Normalize(_dir);
        }

        public Vector3 GetOrg(){
            return org;
        }
        public Vector3 GetDir(){
            return dir;
        }

        public Colour CalculateIntersection(Scene scene){
            int idOfCloset = -1;
            float t = -1;
            float tClosest = -1;

            //t is the magnitude of the rays vector
            for (int i = 0; i < scene.shapes.Count; i++){
                if (scene.shapes[i].Intersection(this,out t)){
                    if (t < tClosest || tClosest == -1){
                        tClosest = t;
                        idOfCloset = i;
                    }
                } 
            }
            if (idOfCloset != -1){
                Vector3 hitLoc = org + (dir * tClosest);
                return scene.shapes[idOfCloset].material.CalculateColour(this,scene,hitLoc,scene.shapes[idOfCloset]);
            }
            return new Colour();
        }
    }
}