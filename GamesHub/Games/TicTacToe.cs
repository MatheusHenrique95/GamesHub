using GamesHub.Entities;
using GamesHub.Helpers;
using GamesHub.Util;

namespace GamesHub.Games;
public class TicTacToe {
    public Player player1 { get; set; }
    public Player player2 { get; set; }
    public TicTacToe(Player player1, Player player2) {
        this.player1 = player1;
        this.player2 = player2;
    }
    List<Player> ImportedPlayers = LayoutHub.players;
    private string mark = " ";
    private int option = 0;
    private string[,] position = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
    public void Layout() {
        Console.WriteLine("\n\n\n\n");

        Console.Write($"                    |       |       \n" +
                      $"                {position[2, 0]}   |   {position[2, 1]}   |   {position[2, 2]}   \n" +
                      $"             _______|_______|_______\n" +
                      $"                    |       |       \n" +
                      $"                {position[1, 0]}   |   {position[1, 1]}   |   {position[1, 2]}   \n" +
                      $"             _______|_______|_______\n" +
                      $"                    |       |       \n" +
                      $"                {position[0, 0]}   |   {position[0, 1]}   |   {position[0, 2]}   \n" +
                      $"                    |       |       \n");
    }
    public void PlayTicTacToe(Player player1, Player player2) {
        Player player11 = ImportedPlayers.Find(x => x.Nickname == player1.Nickname);
        Player player22 = ImportedPlayers.Find(x => x.Nickname == player2.Nickname);
        for (int count = 1; count <= 9; count++) {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Layout();
            if (count % 2 != 0) {
                Console.WriteLine("\n\n\n");
                Console.WriteLine($"              It's {player1.Nickname} turn, choose a spot:");
                Console.Write("              ");
                option = int.Parse(Console.ReadLine());
                mark = "X";

            } else {
                Console.WriteLine("\n\n\n");
                Console.WriteLine($"              It's {player2.Nickname} turn, choose a spot:");
                Console.Write("              ");
                option = int.Parse(Console.ReadLine());
                mark = "O";

            }
            switch (option) {
                case 1:
                    if (position[0, 0] != "X" && position[0, 0] != "O") {
                        position[0, 0] = mark;
                    } else {
                        Warnings.Wrong();
                        Console.WriteLine("             [Invalid option]");
                        Thread.Sleep(1500);
                        count--;
                    }
                    break;
                case 2:
                    if (position[0, 1] != "X" && position[0, 1] != "O") {
                        position[0, 1] = mark;
                    } else {
                        Warnings.Wrong();
                        Console.WriteLine("             [Invalid option]");
                        Thread.Sleep(1500);
                        count--;
                    }
                    break;
                case 3:
                    if (position[0, 2] != "X" && position[0, 2] != "O") {
                        position[0, 2] = mark;
                    } else {
                        Warnings.Wrong();
                        Console.WriteLine("             [Invalid option]");
                        Thread.Sleep(1500);
                        count--;
                    }
                    break;
                case 4:
                    if (position[1, 0] != "X" && position[1, 0] != "O") {
                        position[1, 0] = mark;
                    } else {
                        Warnings.Wrong();
                        Console.WriteLine("             [Invalid option]");
                        Thread.Sleep(1500);
                        count--;
                    }
                    break;
                case 5:
                    if (position[1, 1] != "X" && position[1, 1] != "O") {
                        position[1, 1] = mark;
                    } else {
                        Warnings.Wrong();
                        Console.WriteLine("             [Invalid option]");
                        Thread.Sleep(1500);
                        count--;
                    }
                    break;
                case 6:
                    if (position[1, 2] != "X" && position[1, 2] != "O") {
                        position[1, 2] = mark;
                    } else {
                        Warnings.Wrong();
                        Console.WriteLine("             [Invalid option]");
                        Thread.Sleep(1500);
                        count--;
                    }
                    break;
                case 7:
                    if (position[2, 0] != "X" && position[2, 0] != "O") {
                        position[2, 0] = mark;
                    } else {
                        Warnings.Wrong();
                        Console.WriteLine("             [Invalid option]");
                        Thread.Sleep(1500);
                        count--;
                    }
                    break;
                case 8:
                    if (position[2, 1] != "X" && position[2, 1] != "O") {
                        position[2, 1] = mark;
                    } else {
                        Warnings.Wrong();
                        Console.WriteLine("             [Invalid option]");
                        Thread.Sleep(1500);
                        count--;
                    }
                    break;
                case 9:
                    if (position[2, 2] != "X" && position[2, 2] != "O") {
                        position[2, 2] = mark;
                    } else {
                        Warnings.Wrong();
                        Console.WriteLine("             [Invalid option]");
                        Thread.Sleep(1500);
                        count--;
                    }
                    break;
                default:
                    Warnings.Wrong();
                    Console.WriteLine("             [Invalid option]");
                    Thread.Sleep(2000);
                    count--;
                    break;
            }
            if (VictoryTicTacToe() && count % 2 != 0) {
                Warnings.Success();
                Console.WriteLine($"\t\t\t {player1.Nickname} Won, {player2.Nickname} was samashed!");
                player11.WinTicTacToe();
                Thread.Sleep(2000);
                return;
            }else if (VictoryTicTacToe() && count % 2 == 0) {
                Warnings.Success();
                Console.WriteLine($"\t\t\t {player2.Nickname} Won, {player1.Nickname} was samashed!");
                player22.WinTicTacToe();
                Thread.Sleep(2000);
                return;
            }
        }
        if (VictoryTicTacToe() == false) {
            Console.Clear();
            Layout();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("             Draw :/");
            player11.TieTicTacToe();
            player22.TieTicTacToe();
            Thread.Sleep(3000);
        }
    }
    private bool VictoryTicTacToe() {
        if (position[0, 0] == position[1, 1] && position[0, 0] == position[2, 2] ||
            position[0, 0] == position[0, 1] && position[0, 0] == position[0, 2] ||
            position[0, 0] == position[1, 0] && position[0, 0] == position[2, 0] ||
            position[0, 1] == position[1, 1] && position[0, 1] == position[2, 1] ||
            position[0, 2] == position[1, 2] && position[0, 2] == position[2, 2] ||
            position[1, 0] == position[1, 1] && position[1, 0] == position[1, 2] ||
            position[2, 0] == position[1, 1] && position[2, 0] == position[0, 2] ||
            position[2, 0] == position[2, 1] && position[2, 0] == position[2, 2]) {
            return true;
        } else return false;
    }
}