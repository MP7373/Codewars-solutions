//https://www.codewars.com/kata/54d7660d2daf68c619000d95
using System.Text;

public class Fracts {
  public static string convertFrac(long[,] lst) {
    if (1 >= lst.GetLength(1))
    {
      return "";
    }

    var gcd = lst[0, 1];
    var lcm = gcd;

    for (var i = 1; i < lst.GetLength(0); i++)
    {
      gcd = GetGreatestCommonDenominator(lcm, lst[i, 1]);
      lcm = lcm * lst[i, 1] / gcd;
    }
    
    var sb = new StringBuilder();
    for (var i = 0; i < lst.GetLength(0); i++)
    {
      var divisionDifference = lcm / lst[i, 1];
      sb.Append($"({lst[i, 0] * divisionDifference},{lst[i, 1] * divisionDifference})");
    }

    return sb.ToString();
  }
  
  private static long GetGreatestCommonDenominator(long a, long b)
  {
    if (a == b)
    {
      return a;
    }
    
    long larger;
    long smaller;
    
    if (a > b)
    {
      larger = a;
      smaller = b;
    }
    else
    {
      larger = b;
      smaller = a;
    }
    
    while (larger % smaller != 0)
    {
      larger %= smaller;

      var temp = larger;
      larger = smaller;
      smaller = temp;
    }
    
    return smaller;
  }
}
