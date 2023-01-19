using GamesHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GamesHub.Games {
    public class TicTacToe {
        public string One { get; set; } = " ";
        public string Two { get; set; } = " ";
        public string Three { get; set; } = " ";
        public string Four { get; set; } = " ";
        public string Five { get; set; } = " ";
        public string Six { get; set; } = " ";
        public string Seven { get; set; } = " ";
        public string Eigth { get; set; } = " ";
        public string Nine { get; set; } = " ";

        public TicTacToe() {
        }
        public void Layout() {

            Console.Write($"       |       |       \n" +
                          $"   {One}   |   {Two}   |   {Three}   \n" +
                          $"_______|_______|_______\n" +
                          $"       |       |       \n" +
                          $"   {Four}   |   {Five}   |   {Six}   \n" +
                          $"_______|_______|_______\n" +
                          $"       |       |       \n" +
                          $"   {Seven}   |   {Eigth}   |   {Nine}   \n" +
                          $"       |       |       \n");
        }
    }
}
