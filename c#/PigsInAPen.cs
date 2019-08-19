//https://www.codewars.com/kata/58fdcc51b4f81a0b1e00003e
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
  public class Game
  {
    private List<int[]> _possibleAlmostCompleteSquares;
    
    public Game(int board)
    {
      _possibleAlmostCompleteSquares = new List<int[]>();
      
      var startOfLastRow = (board * (board + 1)) * 2 - board + 1;
      var stepsToHorizontalLineBelow = board * 2 + 1;
      
      for (var rowStart = 1; rowStart < startOfLastRow; rowStart += stepsToHorizontalLineBelow)
      {
        for (var top = rowStart; top < rowStart + board; top++)
        {
          var left = top + board;
          var right = top + board + 1;
          var bottom = top + stepsToHorizontalLineBelow;
          
          _possibleAlmostCompleteSquares.Add(new int[] { top, left, right, bottom });
          _possibleAlmostCompleteSquares.Add(new int[] { top, left, bottom, right });
          _possibleAlmostCompleteSquares.Add(new int[] { top, right, bottom, left });
          _possibleAlmostCompleteSquares.Add(new int[] { left, right, bottom, top });
        }
      }
    }
  
    public List<int> play(List<int> lines)
    {
      var linesSet = new HashSet<int>(lines);
      
      var goAgain = true;
      while (goAgain)
      {
        goAgain = false;

        foreach (var almostCompleteSquare in _possibleAlmostCompleteSquares)
        {
          if (linesSet.Contains(almostCompleteSquare[0]) &&
            linesSet.Contains(almostCompleteSquare[1]) &&
            linesSet.Contains(almostCompleteSquare[2]) &&
            !linesSet.Contains(almostCompleteSquare[3]))
          {
            linesSet.Add(almostCompleteSquare[3]);
            goAgain = true;
            break;
          }
        }
      }
      
      var listAfterMoves = linesSet.ToList();
      listAfterMoves.Sort();
      
      return listAfterMoves;
    }
  }
}
