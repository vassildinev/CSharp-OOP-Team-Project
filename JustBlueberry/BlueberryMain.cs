namespace JustBlueberry
{
    public class BlueberryMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            BlueberryFaçade.Instance.Initialize();
            BlueberryFaçade.Instance.Start();
        }
    }
}
