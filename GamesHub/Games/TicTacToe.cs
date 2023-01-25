using GamesHub.Entities;
using GamesHub.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GamesHub.Games {

    public class TicTacToe {
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public TicTacToe(Player player1, Player player2 ) {
            this.player1 = player1;
            this.player2 = player2;
        }
        int option = 0;
        public static string[,] position = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        public void LayoutTicTacToe() {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

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
            for (int count = 1; count <= 9; count++) {
                if(count %2 != 0) {
                    Console.WriteLine($"              It's {player1.Nickname} turn, choose a spot:");
                    Console.Write("              ");
                    option = int.Parse(Console.ReadLine());
                }else {
                    Console.WriteLine($"              It's {player2.Nickname} turn, choose a spot:");
                    Console.Write("              ");
                    option = int.Parse(Console.ReadLine());
                }
            }

        }
        
        
    }
}
