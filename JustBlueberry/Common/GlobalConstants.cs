namespace JustBlueberry.Common
{
    using System;

    public class GlobalConstants
    {
        // Engine Constants
        public const int DefaultEngineFramesPerSecond = 10;
        public static int OneSecondInMilliseconds = 1000;

        // Console Constants
        public const int DefaultConsoleBufferHeight = 47;
        public const int DefaultConsoleBufferWidth = 82;
        public const int DefaultConsoleWindowHeight = DefaultConsoleBufferHeight;
        public const int DefaultConsoleWindowWidth = DefaultConsoleBufferWidth;
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

        public const int DefaultWorldRows = DefaultConsoleBufferHeight - 2;
        public const int DefaultWorldCols = DefaultConsoleBufferWidth - 2;
        public static readonly Vector DefaultBlueberryPosistionOnScreen = new Vector(7, 29);
        public static string StartScreenText =
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██████░░░░░░░░░░░░░██░░░░░░░░░░░\n" +
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░██░██░████░████░░░░░░░░░░\n" +
                "░░░░░░█████░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░██░██░██░██░░░░██░░░░░░░░░░░\n" +
                "░░░░░░██░░██░░░░░░░██░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░██░██░██░░░██░░██░░░░░░░░░░░\n" +
                "░░░░░░██░░██░░░░░░░██░░░░░░░░░░░░░░░░░░░░░██░░░░░██████░█████░████░░██░░░░░░░░░░░\n" +
                "░░░░░░██░░██░░░░░░░██░░░░░░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "░░░░░░██████████░░░██░░░░░██░░░██░██████░░██░░░░░░░░█████░░░███░███░██░░░██░░░░░░\n" +
                "░░░░░░████████████░██░░░░░██░░░██░██░░░█░░████████░░█░░██░░██░░██░░░██░░░██░░░░░░\n" +
                "░░░░░░██░░░░░░░░░█░██░░░░░██░░░██░██░░░█░░██░░░░░█░░█░░░█░░██░░██░░░██░░░██░░░░░░\n" +
                "░░░░░░██░░░░░░░░░█░██░░░░░██░░░██░██████░░██░░░░░█░░█████░░██░░██░░░███░░██░░░░░░\n" +
                "░░░░░░██░░░░░░░░░█░██░░░░░██░░███░██░░░░░░██░░░░░█░░█░░░░░░██░░██░░░░░░████░░░░░░\n" +
                "░░░░░░████████████░██████░██░██░█░██████░░████████░░█████░░██░░██░░░░░░░░██░░░░░░\n" +
                "░░░░░░███████████░░██████░░███░░█░██████░░████████░░█████░░██░░██░░░███████░░░░░░\n" +
                "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
                "                                    *****                                        \n" +
                "                                  *       *                                      \n" +
                "                                 *         *                                     \n" +
                "                                *           *                                    \n" +
                "              * *****          *             *           ***** *                 \n" +
                "             *        **      *               *      **          *               \n" +
                "             *            **  *               *  **              *               \n" +
                "             **              **                **               **                \n" +
                "              @@@@@             **           **               ***                \n" +
                "             @@@@@@@               **     **                 ***                 \n" +
                "             @@@@@@@               #####**             @@@@@***                  \n" +
                "              @@@@@*             #########**          @@@@@@@                    \n" +
                "                  ***          #############**        @@@@@@@                    \n" +
                "                   ****       ############### **     **@@@@@                     \n" +
                "                     ****    #################  ** ****                          \n" +
                "                       ****  #################   ****                            \n" +
                "                        *****#################******                             \n" +
                "                         ***** ##############*****  **                           \n" +
                "                       **   *****#########*****      **                          \n" +
                "                     **       *****######*****         **                        \n" +
                "                   **            *****#*****            **                       \n" +
                "                  **                *****                 **                     \n" +
                "                 **             ***********                **                    \n" +
                "                *            ******      ******             *                    \n" +
                "                *        ******              * *****         *                   \n" +
                "                *    *****    *              *      *****    *                   \n" +
                "                 *****         *            *          *****                     \n" +
                "                                *       @@@*                                     \n" +
                "                                 *     @@@@@                                     \n" +
                "                                  *     @@@                                      \n" +
                "                                    ****                                         \n";
        public const int StartScreenShowDuration = 5000;

        // Operator constants
        public const int FramesCycleDuration = 120;

        // Helpers constants
        public const int DefaultBlueberryInfoWidth = 30;
    }
}
