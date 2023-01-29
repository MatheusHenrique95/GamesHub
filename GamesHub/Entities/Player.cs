
namespace GamesHub.Entities {
    public class Player {
        public string Nickname { get; private set; }
        public string Password { get; private set; }
        public int TicTacToePoints { get; private set; }
        public int NavalBattlePoints { get; private set; }
        public int ChessPoints { get; private set; }
        public int Points { get; private set; }

        public Player(string nickname, string password) {
            Nickname = nickname;
            Password = password;
        }
        public int SumPoints() {
            return Points = TicTacToePoints + ChessPoints + NavalBattlePoints;
        }
        public int WinTicTacToe() {
            return TicTacToePoints += 3;
        }
        public int TieTicTacToe() {
            return TicTacToePoints++;
        }
        public int WinNavalBattle() {
            return NavalBattlePoints +=3;
        }
        public int TieNavalBattle() {
            return NavalBattlePoints++;
        }
        public int WinChess() {
            return ChessPoints +=3;
        }
        public int TieChess() {
            return ChessPoints ++;
        }

    }
}
