namespace JustBlueberry.Common
{
    using System;

    public class GlobalConstants
    {
        // Engine Constants
        public const int DefaultEngineThreadSleepParameter = 500;

        // Console Constants
        public const int DefaultConsoleWindowHeight = 40;
        public const int DefaultConsoleWindowWidth = 100;
        public const int DefaultConsoleBufferHeight = 40;
        public const int DefaultConsoleBufferWidth = 100;
        public const ConsoleColor DefaultParticleRenderColor = ConsoleColor.Gray;
        public const ConsoleColor DefaultElectronRenderColor = ConsoleColor.DarkBlue;
        public const ConsoleColor DefaultProtonRenderColor = ConsoleColor.Magenta;

        // Matter Constats
        public static readonly Point DarkBlueberryFirstProtonStartPosition = new Point(3, 7);
        public static readonly Point DarkBlueberrySecondProtonStartPosition = new Point(6, 12);
        public static readonly Point DarkBlueberryThirdProtonStartPosition = new Point(2, 5);
        public static readonly Point DarkBlueberryFourthProtonStartPosition = new Point(7, 14);
        public static readonly Point DarkBlueberryWhiteElectronStartPosition = new Point(0, 7);
        public static readonly Point DarkBlueberryBlackElectronStartPosition = new Point(2, 0);
              
        public static readonly Point NervousBlueberryProtonStartPosition = new Point(9, 11);
        public static readonly Point NervousBlueberrytRedElectronStartPosition = new Point(10, 15);
        public static readonly Point NervousBlueberryBlueElectronStartPosition = new Point(9, 11);
        public static readonly Point NervousBlueberryGreenElectronPosition = new Point(9, 11);

        // Renderer constants
        public static string WelcomeScreen =  "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "░░░░░░*****░░░░░░░░**░░░░░░░░░░░░░░░░░░░░░**░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "░░░░░░**░░**░░░░░░░**░░░░░░░░░░░░░░░░░░░░░**░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "░░░░░░**░░**░░░░░░░**░░░░░░░░░░░░░░░░░░░░░**░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "░░░░░░**░░**░░░░░░░**░░░░░░░░░░░░░░░░░░░░░**░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "░░░░░░**********░░░**░░░░░**░░░**░******░░**░░░░░░░░*****░░░***░****░**░░*░░░░░░░\n" +
                "░░░░░░************░**░░░░░**░░░**░**░░░*░░********░░*░░░*░░**░░**░░░░**░░*░░░░░░░\n" +
                "░░░░░░**░░░░░░░░░*░**░░░░░**░░░**░**░░░*░░**░░░░░*░░*░░░*░░**░░**░░░░**░░*░░░░░░░\n" +
                "░░░░░░**░░░░░░░░░*░**░░░░░**░░░**░******░░**░░░░░*░░*****░░**░░**░░░░░******░░░░░\n" +
                "░░░░░░**░░░░░░░░░*░**░░░░░**░░***░**░░░░░░**░░░░░*░░*░░░░░░**░░**░░░░░░***░░░░░░░\n" +
                "░░░░░░************░******░**░**░*░******░░********░░*****░░**░░**░░░░░*░░*░░░░░░░\n" +
                "░░░░░░***********░░******░░***░░*░******░░********░░*****░░**░░**░░░░**░░*░░░░░░░\n" +
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░**░░*░░░░░░░\n" +
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░**░░*░░░░░░░\n" +
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░****░░░░░░░░\n" +
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "                                    *****                                    \n" +
                "                                    **  **                                   \n" +
                "                  *******          **    *           ******                  \n" +
                "                  *     ***        *     **        ****     *                \n" +
                "                  **      ***      *      *    *****        *                \n" +
                "                  #####     ***   **      *  **            *                 \n" +
                "                 #######      *****       ****            **                 \n" +
                "                  #####^        ***     ***             ***                  \n" +
                "                    ##**        * ######* *         ##**                     \n" +
                "                       **       *#########        #####                      \n" +
                "                        **     ############       #####                      \n" +
                "                         ***  ##############    ** ##                        \n" +
                "                           **################ **                             \n" +
                "                             ################**                              \n" +
                "                           **################  **                            \n" +
                "                         **  ################   ***                          \n" +
                "                       **     ##############      ***                        \n" +
                "                     ***       ############          **                      \n" +
                "                    **          ###########           ***                    \n" +
                "                   **            ######## *             **                   \n" +
                "                  **            ****      **              **                 \n" +
                "                 *           ******      ** ****           *                 \n" +
                "                 *       *****   *       *      ******     *                 \n" +
                "                 *   *****       *      **           *******                 \n" +
                "                 *****           *      *                                    \n" +
                "                                 *    ###                                    \n" +
                "                                 *   #####                                   \n" +
                "                                 **   ###                                    \n" +
                "                                  *****                                      \n";
    }
}
