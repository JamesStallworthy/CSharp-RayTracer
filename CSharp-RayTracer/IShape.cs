namespace CSharp_RayTracer
{
    public interface IShape
    {
        bool Intersection(Ray ray);
    }
}