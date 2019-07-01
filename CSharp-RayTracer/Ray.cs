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

        public Colour CalculateIntersection(Scene s){
            int idOfCloset = -1;
            float t,tLast = -1;

            for (int i = 0; i < s.shapes.Count; i++){
                if (s.shapes[i].Intersection(this,out t)){
                    if (t < tLast || tLast == -1){
                        tLast = t;
                        idOfCloset = i;
                    } 
                } 
            }

            if (idOfCloset != -1) {
                return s.shapes[idOfCloset].material.CalculateColour(this);
            }
            return new Colour();
        }
    }
}