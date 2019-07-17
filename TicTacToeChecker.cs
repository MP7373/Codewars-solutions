//https://www.codewars.com/kata/525caa5c1bf619d28c000335
public class TicTacToe
{
  public int IsSolved(int[,] board)
  {
    // horizontal checks
    for (var y = 0; y < 3; y++)
    {
      if (board[y, 0] == board[y, 1] && board[y, 1] == board[y, 2] &&
        board[y, 0] != 0)
      {
        return board[y, 0];
      }
    }
    
    // vertical checks
    for (var x = 0; x < 3; x++)
    {
      if (board[0, x] == board[1, x] && board[1, x] == board[2, x] &&
        board[0, x] != 0)
      {
        return board[0, x];
      }
    }
    
    // diagonal checks
    if (board[1, 1] != 0 &&
      board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] ||
      board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2])
    {
      return board[1, 1];
    }
    
    // game not finished check
    foreach (var slot in board)
    {
      if (slot == 0)
      {
        return -1;
      }
    }
    
    return 0;
  }
}
