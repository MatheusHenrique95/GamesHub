using GamesHub.Entities;
using GamesHub.Helpers;

namespace GamesHub.Util;
public class Rankings {
    public static void RankingsMenu() {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine("\n\n\n");
        Console.WriteLine("         [1] General Ranking");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [2] TicTacToe Ranking");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [3] Naval Battle Ranking");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [4] Chess Ranking");
        Console.WriteLine("         ------------------------");
        Console.WriteLine("         [0] Back to main screen");
        Console.WriteLine("         ------------------------");
        int option = int.Parse(Console.ReadLine());
        switch (option) {
            case 0:
                LayoutHub.Mainscreen();
                break;
            case 1:
                Console.Clear();
                Console.WriteLine("\n\n\n");
                GeneralRanking();
                Console.WriteLine("\n\n\n");
                Console.Write("\t\t Type anything to back: ");
                string back = Console.ReadLine();
                RankingsMenu();
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("\n\n\n");
                TicTacToeRanking();
                Console.WriteLine("\n\n\n");
                Console.Write("\t\t Type anything to back: ");
                back = Console.ReadLine();
                RankingsMenu();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("\n\n\n");
                NavalBattleRanking();
                Console.WriteLine("\n\n\n");
                Console.Write("\t\t Type anything to back: ");
                back = Console.ReadLine();
                RankingsMenu();
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("\n\n\n");
                ChessRanking();
                Console.WriteLine("\n\n\n");
                Console.Write("\t\t Type anything to back: ");
                back = Console.ReadLine();
                RankingsMenu();
                break;
            default:
                Warnings.Wrong();
                Console.WriteLine("             [Invalid option]");
                Thread.Sleep(2000);
                break;
        }
    }
    private static void GeneralRanking() {
        int count = 0;
        List<Player> GeneralRankedPlayers = LayoutHub.players.OrderByDescending(player => player.Points).ToList();
        Console.WriteLine("\t\t\tGeneral ranking");
        Console.WriteLine("\t\t Position | Nickname | Points");
        foreach (Player player in GeneralRankedPlayers) {
            count++;
            player.SumPoints();
            Console.WriteLine($"\t\t    {count:D2}°   |  { player.Nickname}  |   { player.Points}");
        }
    }
    private static void TicTacToeRanking() {
        int tcount = 0;
        List<Player> TicTacToeRankedPlayers = LayoutHub.players.OrderByDescending(player => player.TicTacToePoints).ToList();
        Console.WriteLine("\t\t\tTicTacToe ranking");
        Console.WriteLine("\t\t Position | Nickname | Points");
        foreach (Player player in TicTacToeRankedPlayers) {
            tcount++;
            player.SumPoints();
            Console.WriteLine($"\t\t    {tcount:D2}°   |  {player.Nickname}  |   {player.TicTacToePoints}");
        }
    }
    private static void NavalBattleRanking() {
        int ncount = 0;
        List<Player> NavalBattleRankedPlayers = LayoutHub.players.OrderByDescending(player => player.NavalBattlePoints).ToList();
        Console.WriteLine("\t\t\tNaval Battle ranking");
        Console.WriteLine("\t\t Position | Nickname | Points");
        foreach (Player player in NavalBattleRankedPlayers) {
            ncount++;
            player.SumPoints();
            Console.WriteLine($"\t\t    {ncount:D2}°   |  {player.Nickname}  |   {player.NavalBattlePoints}");
        }
    }
    private static void ChessRanking() {
        int ccount = 0;
        List<Player> ChessRankedPlayers = LayoutHub.players.OrderByDescending(player => player.ChessPoints).ToList();
        Console.WriteLine("\t\t\tChess ranking");
        Console.WriteLine("\t\t Position | Nickname | Points");
        foreach (Player player in ChessRankedPlayers) {
            ccount++;
            player.SumPoints();
            Console.WriteLine($"\t\t    {ccount:D2}°   |  {player.Nickname}  |   {player.ChessPoints}");
        }
    }
}
