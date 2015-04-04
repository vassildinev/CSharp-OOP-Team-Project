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
                                        new Proton(GlobalConstants.DarkBlueberryFirstProtonStartPosition + translationVector),
                                        new Proton(GlobalConstants.DarkBlueberrySecondProtonStartPosition + translationVector),
                                        new Proton(GlobalConstants.DarkBlueberryThirdProtonStartPosition + translationVector),
                                        new Proton(GlobalConstants.DarkBlueberryFourthProtonStartPosition + translationVector),
                                        new WhiteElectron(GlobalConstants.DarkBlueberryWhiteElectronStartPosition + translationVector),
                                        new BlackElectron(GlobalConstants.DarkBlueberryBlackElectronStartPosition + translationVector)
                                    }
                                 );
        }

        public static IMatter CreateNervousBlueberry(Vector translationVector)
        {
            return new NervousBlueberry(new List<IHadron>() 
                                        {
                                            new DynamicProton( GlobalConstants.NervousBlueberryProtonStartPosition + translationVector),
                                            new RedElectron(GlobalConstants.NervousBlueberrytRedElectronStartPosition + translationVector),
                                            new BlueElectron(GlobalConstants.NervousBlueberryBlueElectronStartPosition + translationVector),
                                            new GreenElectron(GlobalConstants.NervousBlueberryGreenElectronPosition + translationVector)
                                        }
                                      );
        }

        public static Stack<IMatter> ListAvailableBlueberries()
        {
            Stack<IMatter> availableBlueberries = new Stack<IMatter>();

            availableBlueberries.Push(BlueberryFactory.CreateDarkBlueberry(new Vector()));
            availableBlueberries.Push(BlueberryFactory.CreateNervousBlueberry(new Vector()));

            return availableBlueberries;
        }
    }
}
