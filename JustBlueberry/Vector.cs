using System;
namespace JustBlueberry
{
    public class Vector
    {
        public int DeltaR { get; set; }
        public int DeltaC { get; set; }

        public Vector(int deltaR, int deltaC)
        {
            this.DeltaR = deltaR;
            this.DeltaC = deltaC;
        }

        public static Point operator +(Point p, Vector speed)
        {
            return new Point(p.Row + speed.DeltaR, p.Col + speed.DeltaC);
        }

        public static Point operator -(Point p, Vector speed)
        {
            return new Point(p.Row - speed.DeltaR, p.Col - speed.DeltaC);
        }
    }
}
