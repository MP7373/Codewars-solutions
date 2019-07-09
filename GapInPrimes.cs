//https://www.codewars.com/kata/561e9c843a2ef5a40c0000a4
using System;
using System.Collections.Generic;

class GapInPrimes 
{
  public static long[] Gap(int g, long m, long n) 
  {
    var alreadyCalculatedIfPrimeTable = new Dictionary<long, bool>();
    
    for (var i = m; i + g <= n; i++)
    {
      var left = i;
      var right = i + g;
      
      bool leftIsPrime;
      if (alreadyCalculatedIfPrimeTable.ContainsKey(left))
      {
        leftIsPrime = alreadyCalculatedIfPrimeTable[left];
      }
      else
      {
        leftIsPrime = IsPrime(left);
        alreadyCalculatedIfPrimeTable[left] = leftIsPrime;
      }
      
      bool rightIsPrime;
      if (alreadyCalculatedIfPrimeTable.ContainsKey(right))
      {
        rightIsPrime = alreadyCalculatedIfPrimeTable[right];
      }
      else
      {
        rightIsPrime = IsPrime(right);
        alreadyCalculatedIfPrimeTable[right] = rightIsPrime;
      }
      
      if (leftIsPrime && rightIsPrime)
      {
        var primeBetween = false;
        
        for (var j = left + 2; j < right; j += 2)
        {
          bool prime;
          if (alreadyCalculatedIfPrimeTable.ContainsKey(j))
          {
            prime = alreadyCalculatedIfPrimeTable[j];
          }
          else
          {
            prime = IsPrime(j);
            alreadyCalculatedIfPrimeTable[j] = prime;
          }
          
          if (prime)
          {
            primeBetween = true;
            break;
          }
        }
        
        if (!primeBetween)
        {
          return new long[] { left, right };
        }
      }
    }
    
    return null;
  }
  
  private static bool IsPrime(long n)
  {
    if (n < 2 || n % 2 == 0)
    {
      return false;
    }
    
    if (n == 2)
    {
      return true;
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
