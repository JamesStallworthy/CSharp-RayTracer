using System;
using System.Numerics;

namespace CSharp_RayTracer
{
    public class MaterialPhong:IMaterial
    {
        private Colour colour;
        private float ambient;

        private float spec_intensity;
        private float spec_power;

        private float diff_intensity;

        public MaterialPhong(Colour _colour, float _diff_intensity, float _ambient, float _specular_intensity, float _spec_power)
        {
            colour = _colour;
            ambient = _ambient;
            spec_intensity = _specular_intensity;
            spec_power = _spec_power;
            diff_intensity = _diff_intensity;
        }

        private Colour CalculateAmbientColour(){
            return colour*ambient;
        }

        private Colour CalculateDiffuseColour(ILight lightSource, Vector3 hitLoc, IShape shape){
            Vector3 normal = Vector3.Normalize(shape.GetOrigin()-hitLoc);
            Vector3 light = Vector3.Normalize(hitLoc - lightSource.GetOrigin());
            float diffuseCalc = Math.Max(0.0f, Vector3.Dot(light,normal));

            return colour * diffuseCalc * diff_intensity;
        }

        //With thanks to following:
        //http://ogldev.atspace.co.uk/www/tutorial19/tutorial19.html
        private Colour CalculateSpecularColour(ILight lightSource, Vector3 cameraLocation, Vector3 hitLoc, IShape shape){
            Colour specColour = new Colour(0,0,0);
            
            Vector3 i = Vector3.Normalize(lightSource.GetOrigin() - hitLoc);//LightVector
            Vector3 normal = Vector3.Normalize(shape.GetOrigin()-hitLoc);
            Vector3 v = Vector3.Normalize(hitLoc - cameraLocation);//Vector to Eye

            Vector3 r = Vector3.Normalize(Vector3.Reflect(i,normal));

            float specFactor = Vector3.Dot(v,r);

            if (specFactor > 0.0f){
                specFactor = (float)Math.Pow(specFactor , spec_power);
                specColour = lightSource.GetColour() * spec_intensity * specFactor;
            }
            
            return specColour;
        }
        
        public Colour CalculateColour(Ray r, Scene scene, Vector3 hitLoc, IShape shape){
            
            Colour amb = CalculateAmbientColour();
            Colour diff =  CalculateDiffuseColour(scene.lightSource,hitLoc,shape);
            Colour spec = CalculateSpecularColour(scene.lightSource,scene.cameraLocation,hitLoc,shape);

            return amb + diff + spec; 
        }
    }
}