//https://www.codewars.com/kata/5262119038c0985a5b00029f
using System;

public static class Kata
{
  public static bool IsPrime(int n)
  {
    if (n == -2)
    {
      return false;
    }
    
    n = Math.Abs(n);
    
    if (n < 2)
    {
      return false;
    }
    
    if (n == 2)
    {
      return true;
    }
    
    if (n % 2 == 0)
    {
      return false;
    }
    
    var root = Math.Sqrt(n);
    
    for (var i = 3; i <= root; i += 2)
    {
      if (n % i == 0)
      {
        return false;
      }
    }
    
    return true;
  }
}
