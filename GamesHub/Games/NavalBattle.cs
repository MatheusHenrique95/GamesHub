
using GamesHub.Entities;

namespace GamesHub.Games;
    public class NavalBattle {
    public Player player1 { get; set; }
    public Player player2 { get; set; }

    public NavalBattle(Player player1, Player player2) {
        this.player1 = player1;
        this.player2 = player2;
    }

}

