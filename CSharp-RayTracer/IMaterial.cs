namespace CSharp_RayTracer
{
    public interface IMaterial
    {
        Colour CalculateColour(Ray ray);
    }
}