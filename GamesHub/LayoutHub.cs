using GamesHub.Entities;
using GamesHub.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GamesHub;
public class LayoutHub {
    private static List<Player> players = new List<Player>();

    public static void Mainscreen() {

        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("         [1] Register a player");
        Console.WriteLine("         ---------------------");
        Console.WriteLine("         [2] Play TicTacToe");
        Console.WriteLine("         ---------------------");
        Console.WriteLine("         [3] Play Chess");
        Console.WriteLine("         ---------------------");
        Console.WriteLine("         [4] Play ---");
        Console.WriteLine("         ---------------------");
        Console.WriteLine("         [0] Shutdown");
        Console.WriteLine("         ---------------------");
        int option = int.Parse(Console.ReadLine());
        switch (option) {
            case 0:
                Shutdown();
                break;
            case 1:
                RegisterPlayer();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                Warnings.Wrong();
                Console.WriteLine("             [Invalid option]");
                Thread.Sleep(2000);
                Mainscreen();
                break;
        }
    }
    private static void Shutdown() {
        Warnings.Wrong();
        Console.WriteLine("                     =============================");
        Console.WriteLine("                     =============================");
        Console.Write("                     Shutting down");
        Thread.Sleep(700);
        Console.Write(".");
        Thread.Sleep(700);
        Console.Write(".");
        Thread.Sleep(700);
        Console.Write(".");
        Console.WriteLine();
        Console.WriteLine();
        Thread.Sleep(2000);
    }
    private static void RegisterPlayer() {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("         Insert a nickname (just numbers and letters, minimum 6 characters):");
        Console.Write("         ");
        string nick = Console.ReadLine();
        Player player1 = players.FirstOrDefault(x => x.Nickname == nick);
        if (nick.Length >= 6 && Regex.IsMatch(nick, "^[a-z A-Z 0-9]+$")) {
            if (player1 != null) {
                Warnings.Wrong();
                Console.WriteLine("                     =============================");
                Console.WriteLine("                     =============================");
                Console.WriteLine("                     Player registred, try another");
                Console.WriteLine("                     =============================");
                Console.WriteLine("                     =============================");
                Thread.Sleep(2000);
                Mainscreen();
            }
            Console.WriteLine("         Insert a password (4 characters):");
            Console.Write("         ");
            string pass = getPassword();
            if (pass.Length == 4) {
                Player player = new Player(nick, pass);
                players.Add(player);
                Warnings.Success();
                Console.WriteLine("                     =====================");
                Console.WriteLine("                     =====================");
                Console.WriteLine("                     Successfuly resgitred");
                Console.WriteLine("                     =====================");
                Console.WriteLine("                     =====================");
                Thread.Sleep(2000);
                Mainscreen();
            } else {
                Warnings.Wrong();
                Console.WriteLine("                     ===============================");
                Console.WriteLine("                     ===============================");
                Console.WriteLine("                     Exactly 4 characters, try again");
                Console.WriteLine("                     ===============================");
                Console.WriteLine("                     ===============================");
                Thread.Sleep(2000);
                Mainscreen();
            }
        } else {
            Warnings.Wrong();
            Console.WriteLine("                     =======================");
            Console.WriteLine("                     =======================");
            Console.WriteLine("                     Wrong format, try again");
            Console.WriteLine("                     =======================");
            Console.WriteLine("                     =======================");
            Thread.Sleep(2000);
            Mainscreen();
        }

    }
    public static string getPassword() {
        var pass = string.Empty;
        ConsoleKey key;
        do {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && pass.Length > 0) {
                Console.Write("\b \b");
                pass = pass[0..^1];
            } else if (!char.IsControl(keyInfo.KeyChar)) {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return pass;
    }
}

