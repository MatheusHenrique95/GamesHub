using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GamesHub.Entities {
    public class Player {
        public string Nickname { get; private set; }
        public string Password { get; private set; }
        public int Points { get; private set; }

        public Player(string nickname, string password) {
            Nickname = nickname;
            Password = password;
        }

        public void Win() {
            Points += 3;
        }
        public void Draw() {
            Points += 1;
        }
    }
}
