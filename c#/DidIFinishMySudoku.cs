//https://www.codewars.com/kata/53db96041f1a7d32dc0004d2
using System.Collections.Generic;

public class Sudoku
{
  public static string DoneOrNot(int[][] board)
  {
    var failureMessage = "Try again!";
    var successMessage = "Finished!";
    
    //horzontal checks
    foreach (var row in board)
    {
      var numbersInRow = new HashSet<int>();
      foreach (var number in row)
      {
        numbersInRow.Add(number);
      }
      
      if (SetDoesNotContainAllDigitsFromOneToNine(numbersInRow))
      {
        return failureMessage;
      }
    }
    
    //vertical checks
    for (var x = 0; x < board[0].Length; x++)
    {
      var numbersInColumn = new HashSet<int>();
      for (var y = 0; y < board.Length; y++)
      {
        numbersInColumn.Add(board[y][x]);
      }
      
      if (SetDoesNotContainAllDigitsFromOneToNine(numbersInColumn))
      {
        return failureMessage;
      }
    }
    
    //square checks
    var corners = new [] { new [] {0, 0}, new [] {0, 3}, new [] {0, 6},
                           new [] {3, 0}, new [] {3, 3}, new [] {3, 6},
                           new [] {6, 0}, new [] {6, 3}, new [] {6, 6}};
    foreach (var startCorner in corners)
    {
      var numbersInSquare = new HashSet<int>();
      for (var y = startCorner[0]; y < startCorner[0] + 3; y++)
      {
        for (var x = startCorner[1]; x < startCorner[1] + 3; x++)
        {
          numbersInSquare.Add(board[y][x]);
        }
      }
      
      if (SetDoesNotContainAllDigitsFromOneToNine(numbersInSquare))
      {
        return failureMessage;
      }
    }
    
    return successMessage;
  }
  
  private static bool SetDoesNotContainAllDigitsFromOneToNine(HashSet<int> set)
  {
      var digitsOneToNine = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
      
      foreach (var number in digitsOneToNine)
      {
        if (!set.Contains(number))
        {
          return true;
        }
      }
      
      return false;
  }
  
}
