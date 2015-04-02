namespace JustBlueberry.Factory
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries;
    using JustBlueberry.Particles;
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Common;

    public static class BlueberryFactory
    {
        public static IMatter CreateDarkBlueberry(Vector translationVector)
        {
            return new DarkBlueberry(
                                    new List<IHadron>()
                                    {
                                        new Proton(new Point(3, 7) + translationVector),
                                        new Proton(new Point(6, 12) + translationVector),
                                        new Proton(new Point(2, 5) + translationVector),
                                        new Proton(new Point(7, 14) + translationVector),
                                        new WhiteElectron(new Point(0, 7) + translationVector),
                                        new BlackElectron(new Point(2, 0) + translationVector)
                                    }
                                 );
        }

        public static IMatter CreateNervousBlueberry(Vector translationVector)
        {
            return new NervousBlueberry(new List<IHadron>() 
                                        {
                                            new Proton(new Point(9, 11) + translationVector),
                                            new RedElectron(new Point(10, 15) + translationVector),
                                            new BlueElectron(new Point(9, 12) + translationVector),
                                            new GreenElectron(new Point(9, 11) + translationVector)
                                        }
                                      );
        }
    }
}
