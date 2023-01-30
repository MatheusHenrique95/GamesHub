using GamesHub.Entities;
using GamesHub.Games;
using GamesHub.Helpers;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Security.Cryptography;

namespace GamesHub.Util;
public class LayoutHub
{
    public static string filename = "Players.json";
    public static List<Player> players = new List<Player>();
    public static void Mainscreen()
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine("\n\n\n");
        Console.WriteLine("         [1] Register a player");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [2] Delete a player");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [3] Login to play games");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [4] Rankings");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [0] Shutdown");
        Console.WriteLine("         ------------------------");
        int option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 0:
                Shutdown();
                break;
            case 1:
                RegisterPlayer();
                break;
            case 2:
                DeletePlayer();
                break;
            case 3:
                Login();
                break;
            case 4:
                Rankings.RankingsMenu();
                break;
            default:
                Warnings.Wrong();
                Console.WriteLine("             [Invalid option]");
                Thread.Sleep(2000);
                Mainscreen();
                break;
        }
    }
    private static void Shutdown()
    {
        string jsonstring = JsonSerializer.Serialize(players);
        File.WriteAllText(filename, jsonstring);
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
        Console.WriteLine("\n\n\n\n");
        Thread.Sleep(1500);

    }
    private static void RegisterPlayer()
    {
        Console.Clear();
        Console.WriteLine("\n\n\n");
        Console.WriteLine("         Insert a nickname (just numbers and letters, 6 characters):");
        Console.Write("         ");
        string nick = Console.ReadLine();
        Player player1 = players.FirstOrDefault(x => x.Nickname == nick);
        if (nick.Length == 6 && Regex.IsMatch(nick, "^[a-z A-Z 0-9]+$"))
        {
            if (player1 != null)
            {
                Warnings.Wrong();
                Console.WriteLine("                     =====================================");
                Console.WriteLine("                     =====================================");
                Console.WriteLine("                     Player already registred, try another");
                Console.WriteLine("                     =====================================");
                Console.WriteLine("                     =====================================");
                Thread.Sleep(2000);
                Mainscreen();
            }
            Console.WriteLine("         Insert a password (4 characters):");
            Console.Write("         ");
            string pass = GetPassword();
            if (pass.Length == 4)
            {
                Player player = new Player(nick, pass);
                players.Add(player);
                string jsonstring = JsonSerializer.Serialize(players);
                File.WriteAllText(filename, jsonstring);
                Warnings.Success();
                Console.WriteLine("                     =====================");
                Console.WriteLine("                     =====================");
                Console.WriteLine("                     Successfuly resgitred");
                Console.WriteLine("                     =====================");
                Console.WriteLine("                     =====================");
                Thread.Sleep(2000);
                Mainscreen();
            }
            else
            {
                Warnings.Wrong();
                Console.WriteLine("                     ===============================");
                Console.WriteLine("                     ===============================");
                Console.WriteLine("                     Exactly 4 characters, try again");
                Console.WriteLine("                     ===============================");
                Console.WriteLine("                     ===============================");
                Thread.Sleep(2000);
                Mainscreen();
            }
        }
        else
        {
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
    private static void DeletePlayer()
    {
        Console.Clear();
        Console.WriteLine("\n\n\n");
        Console.WriteLine("         Insert a nickname to delete:");
        Console.Write("         ");
        string nick = Console.ReadLine();
        Player player = players.FirstOrDefault(x => x.Nickname == nick);
        if (player == null)
        {
            Warnings.Wrong();
            Console.WriteLine("                     =================================");
            Console.WriteLine("                     =================================");
            Console.WriteLine("                     Player doesn't exist, try another");
            Console.WriteLine("                     =================================");
            Console.WriteLine("                     =================================");
            Thread.Sleep(2000);
            Mainscreen();
        }
        else
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine("         You really want to delete this player? (Y/N)");
            Console.Write("         ");
            string confirm = Console.ReadLine();
            if (confirm == "N" || confirm == "n")
            {
                Warnings.Success();
                Console.WriteLine("\t\t\t Ok, going back.");
                Thread.Sleep(2000);
                Mainscreen();
            }
            else if (confirm == "Y" || confirm == "y")
            {
                players.Remove(player);
                string jsonstring = JsonSerializer.Serialize(players);
                File.WriteAllText(filename, jsonstring);
                Warnings.Success();
                Console.WriteLine("                     ========================");
                Console.WriteLine("                     ========================");
                Console.WriteLine("                     Player sucefully deleted");
                Console.WriteLine("                     ========================");
                Console.WriteLine("                     ========================");
                Thread.Sleep(3000);
                Mainscreen();
            }
            else
            {
                Warnings.Wrong();
                Console.WriteLine("\t\t\t Type (Y) or (N)");
                Thread.Sleep(3000);
                Mainscreen();
            }
        }
    }
    public static string GetPassword()
    {
        var pass = string.Empty;
        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && pass.Length > 0)
            {
                Console.Write("\b \b");
                pass = pass[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return pass;
    }
    private static void Login()
    {
        Player player1 = new Player("1", "1");
        Player player2 = new Player("2", "3");
        string nick = null;
        string pass = null;
        for (int count = 1; count <= 2; count++)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine($"         Player {count} nickname:");
            Console.Write("         "); nick = Console.ReadLine();
            Player player = players.FirstOrDefault(x => x.Nickname == nick);
            if (player != null)
            {
                Console.WriteLine($"         Player {count} password:");
                Console.Write("         "); pass = GetPassword();
                int index = players.IndexOf(player);
                if (players[index].Password == pass)
                {
                    if (count == 1)
                    {
                        player1 = new Player(nick, pass);
                    }
                    else
                    {
                        player2 = new Player(nick, pass);
                    }
                    if (player1.Nickname == player2.Nickname)
                    {
                        Warnings.Wrong();
                        Console.WriteLine("             [You can't play alone, find a friend]");
                        Thread.Sleep(2000);
                        Login();
                    }
                    else
                    {
                        Warnings.Success();
                        Console.WriteLine($"         Welcome, {player.Nickname}! You the player {count}");
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Warnings.Wrong();
                    Console.WriteLine("             [Wrong password, restart the process]");
                    Thread.Sleep(2000);
                    Login();
                }
            }
            else
            {
                Warnings.Wrong();
                Console.WriteLine("             [Player doesn't existe, restart the process]");
                Thread.Sleep(2000);
                Login();
            }
        }
        LogedScreen(player1, player2);
    }
    private static void LogedScreen(Player player1, Player player2)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine("\n\n\n");
        Console.WriteLine("         [1] Play Tic Tac Toe");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [2] Play Naval Battle");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [3] Play Chess(To do)");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [0] Back to main screen");
        Console.WriteLine("         ------------------------");
        int option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 0:
                Mainscreen();
                break;
            case 1:
                TicTacToe newGameT = new TicTacToe(player1, player2);
                newGameT.PlayTicTacToe(player1, player2);
                LogedScreen(player1, player2);
                break;
            case 2:
                NavalBattle newGameN = new NavalBattle(player1, player2);
                newGameN.Layout(player1);
                break;
            case 3:
                break;
            default:
                Warnings.Wrong();
                Console.WriteLine("             [Invalid option]");
                Thread.Sleep(2000);
                Mainscreen();
                break;
        }

    }
    public static void ReadPlayers()
    {
        string jsonString = File.ReadAllText(filename);
        if (!string.IsNullOrEmpty(jsonString))
        {
            List<Player> allplayers = JsonSerializer.Deserialize<List<Player>>(jsonString);
            allplayers.ForEach(player => players.Add(player));
        }
        else
        {
            Console.WriteLine(" ");
        }
    }

}

