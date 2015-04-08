namespace JustBlueberry.Factory
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using JustBlueberry.Blueberries;
    using JustBlueberry.Particles;
    using JustBlueberry.Particles.Contracts;
    using JustBlueberry.Blueberries.Contracts;
    using JustBlueberry.Common;

    public class BlueberryFactory
    {
        private const string MethodNameKeyword = "Create";

        // Blueberry creation methods.
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

        public static IMatter CreateHydroberry(Vector translationVector)
        {
            return new Hydroberry(new List<IHadron>() 
                                  { 
                                      new Proton(GlobalConstants.HydroberryProtonStartPosition + translationVector),
                                      new BlueElectron(GlobalConstants.HydroberryBlueElectronStartPosition + translationVector)
                                  },
                                  MeaningOfLife.SaveTheUniverse
                                 );
        }

        // Methods operating over the creation methods
        public static IEnumerable<IMatter> ListBlueberries()
        {
            BlueberryFactory factory = new BlueberryFactory();

            List<IMatter> availableBlueberries = new List<IMatter>();

            var methods = typeof(BlueberryFactory).GetMethods();

            foreach (var method in methods)
            {
                if (method.Name.Contains(MethodNameKeyword))
                    availableBlueberries.Add(method.Invoke(factory, new[] { GlobalConstants.DefaultBlueberryPosistionOnScreen }) as IMatter);
            }

            return availableBlueberries;
        }

        public static IEnumerable<IMatter> GetSortedAvailableBlueberries()
        {
            var availableBlueberries = BlueberryFactory.ListBlueberries();
            return availableBlueberries.OrderByDescending(berry => (int)berry.LifetimeGoal).ToList();
        }

        public static Stack<IMatter> GetStackedSortedAvailableBlueberries()
        {
            Stack<IMatter> stackedSortedAvailableBlueberries = new Stack<IMatter>();

            var sortedAvailableBerries = BlueberryFactory.GetSortedAvailableBlueberries();
            foreach (var berry in sortedAvailableBerries)
            {
                stackedSortedAvailableBlueberries.Push(berry);
            }
            return stackedSortedAvailableBlueberries;
        }
    }
}
