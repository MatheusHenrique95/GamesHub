using GamesHub.Entities;
using GamesHub.Games;
using GamesHub.Util;
using System.Text.Json;

namespace GamesHub;
public class Program {
    public static void Main(string[] args) {
        LayoutHub.ReadPlayers();
        LayoutHub.Mainscreen();
    }
}