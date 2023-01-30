
using GamesHub.Entities;
using GamesHub.Util;

namespace GamesHub.Games;
    public class NavalBattle {
    public Player player1 { get; set; }
    public Player player2 { get; set; }

    public NavalBattle(Player player1, Player player2) {
        this.player1 = player1;
        this.player2 = player2;
    }
    List<Player> ImportedPlayers = LayoutHub.players;
    private string[,] position = new string[11,10];
    public void Layout(Player player) {
        Console.WriteLine("   A|B|C|D|E|F|G|H|I|J|");
        for(int i = 1; i<= 10; i++) {
            Console.Write($"{i:D2}|");
            for(int j = 0 ; j < 10; j++) {
                Console.Write(position[i,j] = "  ");
            }
            Console.WriteLine();
        }
    }
}

