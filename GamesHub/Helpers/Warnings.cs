
namespace GamesHub.Helpers {
    public class Warnings {
        public static void Wrong() {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void Success() {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
