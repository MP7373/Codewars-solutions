//https://www.codewars.com/kata/59ccf051dcc4050f7800008f
using System;
using System.Collections.Generic;
class Bud
{
  public static string Buddy(long start, long limit)
  {
    for (long n = start; n <= limit; n++)
    {
      var nSum = GetSumOfProperFactors(n);
      var m = nSum - 1;
      var mSum = GetSumOfProperFactors(m);
      
      if (m > n && nSum == m + 1 && mSum == n + 1)
      {
        return $"({n} {m})";
      }
    }
    
    return "Nothing";
  }
  
  private static long GetSumOfProperFactors(long n)
  {
    long root = (long) Math.Ceiling(Math.Sqrt(n));
    long sum = 1;
    
    for (var i = 2; i <= root; i++)
    {
      if (n % i == 0)
      {
        sum += i;
        
        var divisor = n / i;
        if (divisor != i)
        {
          sum += n / i;
        }
      }
    }
    
    return sum;
  }
}
