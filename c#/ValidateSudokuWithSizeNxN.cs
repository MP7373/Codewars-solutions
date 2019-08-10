//https://www.codewars.com/kata/540afbe2dc9f615d5e000425
using System;
using System.Linq;
using System.Collections.Generic;

class Sudoku
{
  private int[][] _board;
  
  public Sudoku(int[][] sudokuData)
  {
    _board = sudokuData;
  }

  public bool IsValid()
  {
    var n = _board.Length;
    var doubleRoot = Math.Sqrt(n);
    
    if (doubleRoot != Math.Floor(doubleRoot))
    {
      return false;
    }
    var root = (int) doubleRoot;
    
    var allRowsAreLengthN = _board.All(row => row.Length == n);
    if (!allRowsAreLengthN)
    {
      return false;
    }
    
    if (n == 1)
    {
      return _board[0][0] == 1;
    }
    
    var oneToN = new int[n];
    for (var i = 0; i < n; i++)
    {
      oneToN[i] = i + 1;
    }
    
    // row validation
    foreach (var row in _board)
    {
      var numbersInRow = new HashSet<int>();
      
      foreach (var number in row)
      {
        numbersInRow.Add(number);
      }
      
      var setContainsOneToN = oneToN.All(number => numbersInRow.Contains(number));
      if (!setContainsOneToN)
      {
        return false;
      }
    }
    
    // column validation
    for (var x = 0; x < n; x++)
    {
      var numbersInColumn = new HashSet<int>();
      
      for (var y = 0; y < n; y++)
      {
        numbersInColumn.Add(_board[y][x]);
      }
      
      var setContainsOneToN = oneToN.All(number => numbersInColumn.Contains(number));
      if (!setContainsOneToN)
      {
        return false;
      }
    }
    
    
    // little square validation
    for (var y = 0; y < root * 2; y += root)
    {
      for (var x = 0; x < root * 2; x += root)
      {
        var usedNumbers = new HashSet<int>();
        
        for (var littleSquareY = y; littleSquareY < y + root; littleSquareY++)
        {
          for (var littleSquareX = x; littleSquareX < x + root; littleSquareX++)
          {
            usedNumbers.Add(_board[littleSquareY][littleSquareX]);
          }
        }
        
        var setContainsOneToN = oneToN.All(number => usedNumbers.Contains(number));
        if (!setContainsOneToN)
        {
          return false;
        }
      }
    }
    
    return true;
  }
}
