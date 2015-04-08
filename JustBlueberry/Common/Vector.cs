namespace JustBlueberry.Common
{
    public class Vector
    {
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

        public int DeltaR { get; set; }

        public int DeltaC { get; set; }

        public static Vector operator +(Vector vect, Vector otherVect)
        {
            return new Vector(vect.DeltaR + otherVect.DeltaR, vect.DeltaC + otherVect.DeltaC);
        }

        public static Vector operator -(Vector vect, Vector otherVect)
        {
            return new Vector(vect.DeltaR - otherVect.DeltaR, vect.DeltaC - otherVect.DeltaC);
        }
    }
}
