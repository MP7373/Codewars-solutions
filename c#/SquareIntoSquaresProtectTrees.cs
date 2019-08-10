//https://www.codewars.com/kata/54eb33e5bc1a25440d000891
using System;
using System.Linq;
using System.Collections.Generic;

public class Decompose {

  public string decompose(long n) {
    var total = n * n;
    var index = 0;
    var squares = new long[100];
    var backtracking = false;
    
    while (total != 0)
    {
      var root = index == 0 ? LargestRoot(total) : (long) Math.Sqrt(total);
      if (!backtracking)
      {
        if (index == 0 || squares[index - 1] > root)
        {
          squares[index] = root;
          total -= root * root;
        }
        else
        {
          if (index == 0) return null;
          squares[index] = 0;
          total += squares[index - 1] * squares[index - 1];
          index--;
          backtracking = true;
          continue;
        }
      }
      else//already exists so must be backtracking
      {
        if (squares[index] >= 1)
        {
          squares[index]--;
          total -= squares[index] * squares[index];
        }
        else
        {
          if (index == 0) return null;
          squares[index] = 0;
          total += squares[index - 1] * squares[index - 1];
          index--;
          backtracking = true;
          continue;
        }
      }
      
      index++;
      backtracking = false;
    }
    
    return String.Join(' ', squares.Where(d => d != 0).Reverse().ToArray());
  }
  
  private long LargestRoot(long n)
  {
    if (n == 1) return 1;
    return (long) Math.Ceiling(Math.Sqrt(n)) - 1;
  }
}
