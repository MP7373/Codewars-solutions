//https://www.codewars.com/kata/587136ba2eefcb92a9000027
namespace CodeWars
{
    class SnakesLadders
    {
        private int _playerToPlay = 1;
        private int _player1Position = 0;
        private int _player2Position = 0;
        private bool _gameOver = false;
        private int[] _gameBoard;
        
        public SnakesLadders()
        {
          _gameBoard = new int[101];
          for (var i = 1; i <= 100; i++)
          {
            _gameBoard[i] = i;
          }
          
          _gameBoard[2] = 38;
          _gameBoard[7] = 14;
          _gameBoard[8] = 31;
          _gameBoard[15] = 26;
          _gameBoard[16] = 6;
          _gameBoard[21] = 42;
          _gameBoard[28] = 84;
          _gameBoard[36] = 44;
          _gameBoard[46] = 25;
          _gameBoard[49] = 11;
          _gameBoard[51] = 67;
          _gameBoard[8] = 31;
          _gameBoard[62] = 19;
          _gameBoard[64] = 60;
          _gameBoard[71] = 91;
          _gameBoard[74] = 53;
          _gameBoard[78] = 98;
          _gameBoard[87] = 94;
          _gameBoard[89] = 68;
          _gameBoard[92] = 88;
          _gameBoard[95] = 75;
          _gameBoard[99] = 80;
        }
        
        public string play (int die1, int die2)
        {
          if (_gameOver) return "Game over!";
          
          if (_playerToPlay == 1)
          {            
            var position = _player1Position + die1 + die2;
            if (position > 100)
            {
              position = 100 - (position - 100);
            }
            _player1Position = _gameBoard[position];
            
            if (die1 != die2)
            {
              _playerToPlay = 2;
            }
            
            if (_player1Position == 100)
            {
              _gameOver = true;
              return "Player 1 Wins!";
            }
            else
            {
              return $"Player 1 is on square {_player1Position}";
            }
          }
          else
          {
            var position = _player2Position + die1 + die2;
            if (position > 100)
            {
              position = 100 - (position - 100);
            }
            _player2Position = _gameBoard[position];
            
            if (die1 != die2)
            {
              _playerToPlay = 1;
            }
            
            if (_player2Position == 100)
            {
              _gameOver = true;
              return "Player 2 Wins!";
            }
            else
            {
              return $"Player 2 is on square {_player2Position}";
            }
          }
        }
    }
}
