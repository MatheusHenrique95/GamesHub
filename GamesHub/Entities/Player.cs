
namespace GamesHub.Entities {
    public class Player {
        public string Nickname { get; private set; }
        public string Password { get; private set; }
        public int TicTacToePoints { get; private set; }
        public int NavalBattlePoints { get; private set; }
        public int ChessPoints { get; private set; }

        public Player(string nickname, string password) {
            Nickname = nickname;
            Password = password;
            TicTacToePoints = 0;
            NavalBattlePoints = 0;
            ChessPoints = 0;
        }
        public void WinTicTacToe() {
            TicTacToePoints += 3;
        }
        public void TieTicTacToe() {
            TicTacToePoints += 1;
        }
        public int WinNavalBattle() {
            return NavalBattlePoints += 3;
        }
        public int TieNavalBattle() {
            return NavalBattlePoints += 1;
        }
        public int WinChess() {
            return ChessPoints += 3;
        }
        public int TieChess() {
            return ChessPoints += 1;
        }

    }
}
