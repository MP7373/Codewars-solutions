//https://www.codewars.com/kata/586c0909c1923fdb89002031
using System.Collections.Generic;

namespace CodeWars
{
  public class Connect4
  {
    private List<List<int>> _grid = new List<List<int>>
    {
      new List<int> { 0, 0, 0, 0, 0, 0 },
      new List<int> { 0, 0, 0, 0, 0, 0 },
      new List<int> { 0, 0, 0, 0, 0, 0 },
      new List<int> { 0, 0, 0, 0, 0, 0 },
      new List<int> { 0, 0, 0, 0, 0, 0 },
      new List<int> { 0, 0, 0, 0, 0, 0 },
      new List<int> { 0, 0, 0, 0, 0, 0 }
    };
    private int _playerToPlay = 1;
    private bool _gameFinished = false;
    
    public string play(int col)
    {
      if (_gameFinished)
      {
        return "Game has finished!";
      }
      
      var slotsUsedInColumn = 0;
      while (slotsUsedInColumn < 6 && _grid[col][slotsUsedInColumn] != 0)
      {
        slotsUsedInColumn++;
      }

      if (slotsUsedInColumn >= 6)
      {
        return "Column full!";
      }
      
      _grid[col][slotsUsedInColumn] = _playerToPlay;
      
      if (CheckForWinner(_playerToPlay))
      {
        _gameFinished = true;
        return $"Player {_playerToPlay} wins!";
      }
      
      var playerThatPlayedThisTurn = _playerToPlay;
      _playerToPlay = _playerToPlay == 1 ? 2 : 1;
      return $"Player {playerThatPlayedThisTurn} has a turn";
    }
    
    private bool CheckForWinner(int player)
    {
      // horizontal checks
      for (var x = 0; x < 4; x++)
      {
        for (var y = 0; y < 6; y++)
        {
          var fourMatch = true;
          for (var i = x; i < x + 4; i++)
          {
            if (_grid[i][y] != player)
            {
              fourMatch = false;
            }
          }
          
          if (fourMatch)
          {
            return true;
          }
        }
      }

      // vertical checks
      for (var x = 0; x < 7; x++)
      {
        for (var y = 0; y < 3; y++)
        {
          var fourMatch = true;
          for (var i = y; i < y + 4; i++)
          {
            if (_grid[x][i] != player)
            {
              fourMatch = false;
            }
          }
          
          if (fourMatch)
          {
            return true;
          }
        }
      }
      
      // bottom left to top right diagonal checks
      for (var x = 0; x < 4; x++)
      {
        for (var y = 0; y < 3; y++)
        {
          var fourMatch = true;
          for (var i = 0; i < 4; i++)
          {
            if (_grid[x + i][y + i] != player)
            {
              fourMatch = false;
            }
          }
          
          if (fourMatch)
          {
            return true;
          }
        }
      }
      
      // top left to bottom right diagonal checks
      for (var x = 0; x < 4; x++)
      {
        for (var y = 5; y >= 3; y--)
        {
          var fourMatch = true;
          for (var i = 0; i < 4; i++)
          {
            if (_grid[x + i][y - i] != player)
            {
              fourMatch = false;
            }
          }
          
          if (fourMatch)
          {
            return true;
          }
        }
      }
      
      return false;
    }
  }
}
