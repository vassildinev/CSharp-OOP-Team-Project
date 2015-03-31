using System;
namespace JustBlueberry
{
    public class Vector
    {
        public int DeltaR { get; set; }
        public int DeltaC { get; set; }

        public Vector()
        {
            this.DeltaR = 0;
            this.DeltaC = 0;
        }

        public Vector(int deltaR, int deltaC)
        {
            this.DeltaR = deltaR;
            this.DeltaC = deltaC;
        }

    }
}
