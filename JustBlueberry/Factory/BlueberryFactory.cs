namespace JustBlueberry.Factory
{
    using System.Collections.Generic;

    using JustBlueberry.Blueberries;
    using JustBlueberry.Particles;
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Common;
    using System.Reflection;

    public class BlueberryFactory
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

        public static IMatter CreateHydrogen(Vector translationVector)
        {
            return new Hydroberry(new List<IHadron>() 
                                  { 
                                      new Proton(GlobalConstants.NervousBlueberryProtonStartPosition + translationVector),
                                      new BlueElectron(GlobalConstants.NervousBlueberryBlueElectronStartPosition + translationVector)
                                  }
                                 );
        }

        public static Stack<IMatter> ListAvailableBlueberries()
        {
            BlueberryFactory factory = new BlueberryFactory();

            Stack<IMatter> availableBlueberries = new Stack<IMatter>();

            var methods = typeof(BlueberryFactory).GetMethods();

            foreach (var method in methods)
            {
                if (method.Name.Contains("Create"))
                    availableBlueberries.Push(method.Invoke(factory, new object[] { GlobalConstants.DefaultBlueberryPosistionOnScreen }) as IMatter);
            }

            return availableBlueberries;
        }
    }
}
