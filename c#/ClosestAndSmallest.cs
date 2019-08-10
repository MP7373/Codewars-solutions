//https://www.codewars.com/kata/5868b2de442e3fb2bb000119
using System;
using System.Linq;

public class ClosestWeight
{
  public static int[][] Closest(string strng) 
  {
      if (strng == "")
      {
        return new int[][]{};
      }
      
      var weights = strng.Split(' ').Select((n, i) => new int[]
      {
          (int) n.Select(c => Char.GetNumericValue(c)).Sum(),
          i,
          Int32.Parse(n)
      }).ToArray();
      Array.Sort(weights, (a, b) => a[0] - b[0] != 0 ? a[0] - b[0] : a[1] - b[1]);
      
      var closest = Math.Abs(weights[0][0] - weights[1][0]);
      var closestTwo = new int[][] { weights[0], weights[1] };
      var last = 1;

      for (var i = 2; i < weights.Length; i++)
      {
        var difference = Math.Abs(weights[last][0] - weights[i][0]);
        if (difference < closest)
        {
          closest = difference;
          closestTwo = new int[][] { weights[last], weights[i] };
        }
        
        last = i;
      }
      
      return closestTwo;
  }
}
