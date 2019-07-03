using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class MaterialPhong:IMaterial
    {
        private Colour colour;
        private float ambient;

        public MaterialPhong(Colour _colour, float _ambient)
        {
            colour = _colour;
            ambient = _ambient;
        }

        //Would be best to override * operator so that colour can be multipled in one go
        private Colour CalculateAmbientColour(){
            return new Colour((int)(colour.r*ambient),(int)(colour.g*ambient),(int)(colour.b*ambient));
        }

        private Colour CalculateDiffuseColour(ILight lightSource, Vector3 hitLoc, IShape shape){
            //Might be shape.getOrigin() - hitLoc
            Vector3 normal = Vector3.Normalize(shape.getOrigin()-hitLoc);
            Vector3 light = Vector3.Normalize(hitLoc - lightSource.getOrigin());
            float diffuseCalc = Math.Max(0.0f, Vector3.Dot(light,normal));

            return new Colour((int)(colour.r*diffuseCalc), (int)(colour.g*diffuseCalc), (int)(colour.b*diffuseCalc));
        }
        
        public Colour CalculateColour(Ray r, Scene scene, Vector3 hitLoc, IShape shape){
            //Need to override the operator
            Colour amb = CalculateAmbientColour();
            Colour diff =  CalculateDiffuseColour(scene.lightSource,hitLoc,shape);

            return new Colour(amb.r+diff.r,amb.g+diff.g,amb.b+diff.b);
        }
    }
}