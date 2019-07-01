namespace CSharp_RayTracer
{
    public class MaterialFlatShaded:IMaterial
    {
        private Colour c;

        public MaterialFlatShaded(Colour _c)
        {
            c = _c;
        }
        public Colour CalculateColour(Ray ray){
            return c;
        }
    }
}