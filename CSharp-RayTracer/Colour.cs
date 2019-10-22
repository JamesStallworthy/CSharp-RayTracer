using System;

namespace CSharp_RayTracer
{
    public class Colour
    {
        public int r;
        public int g;
        public int b;

        public Colour()
        {
            r = 0;
            g = 0;
            b = 0;
        }

        public Colour(int _r, int _g, int _b)
        {
            r = Math.Clamp(_r, 0, 255);
            g = Math.Clamp(_g, 0, 255);
            b = Math.Clamp(_b, 0, 255);
        }

        public static Colour operator +(Colour x1, Colour x2) => new Colour(x1.r+x2.r, x1.g+x2.g, x1.b+x2.b);

        public static Colour operator *(Colour x1, float x2) => new Colour((int)(x1.r*x2), (int)(x1.g*x2), (int)(x1.b*x2));

        public static Colour operator *(Colour x1, Colour x2) => new Colour((int)(x1.r*x2.r), (int)(x1.g*x2.g), (int)(x1.b*x2.b));
    }
}