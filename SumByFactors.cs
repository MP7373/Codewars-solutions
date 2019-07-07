//https://www.codewars.com/kata/sum-by-factors/
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

public class SumOfDivided
{
	
	public static string sumOfDivided(int[] numberList)
  {
    var primes = GetPrimesUpTo(10000);
    var primesThatFactorEachNumber = new List<HashSet<int>>();
    var primeFactorSums = new Dictionary<int, int>();
    
    foreach (var number in numberList)
    {
      var primesThatFactorNumber = GetPrimesThatFactor(number, primes);
      primesThatFactorEachNumber.Add(primesThatFactorNumber);
      
      foreach (var factor in primesThatFactorNumber)
      {
        if (!primeFactorSums.ContainsKey(factor))
        {
          primeFactorSums.Add(factor, number);
        }
        else
        {
          primeFactorSums[factor] += number;
        }
      }
    }
    
    var sb = new StringBuilder();
    
    var sortedPrimeFactorSums = new SortedDictionary<int, int>(primeFactorSums);
    foreach (var primeFactorAndSum in sortedPrimeFactorSums)
    {
      sb.Append($"({primeFactorAndSum.Key} {primeFactorAndSum.Value})");
    }
    
    return sb.ToString();
  }
  
  private static HashSet<int> GetPrimesThatFactor(int n, List<int> primes)
  {
    var N = n;
    n = Math.Abs(n);
    var primesThatFactorN = new HashSet<int>();
    
    if (n <= 1)
    {
      return primesThatFactorN;
    }
    
    var primeIndex = 0;
    
    while (n != primes[primeIndex])
    {
      if (n % primes[primeIndex] == 0)
      {
        primesThatFactorN.Add(primes[primeIndex]);
        
        while (n % primes[primeIndex] == 0)
        {
          n /= primes[primeIndex];
          
          if (n <= primes[primeIndex])
          {
            return primesThatFactorN;
          }
        }
      }
      
      
      if (primeIndex + 1 >= primes.Count)
      {
        Console.WriteLine(N);
        break;
      }
      primeIndex++;
    }   
    primesThatFactorN.Add(primes[primeIndex]);
    
    return primesThatFactorN;
  }
  
  private static List<int> GetPrimesUpTo(int largestPrimeToGenerate)
  {
    var notPrimeArray = new bool[largestPrimeToGenerate + 1];
    
    notPrimeArray[0] = true;
    notPrimeArray[1] = true;
    notPrimeArray[2] = false;
    for (var i = 4; i < notPrimeArray.Length; i += 2)
    {
      notPrimeArray[i] = true;
    }
    
    var rootOfLargestPrime = Math.Sqrt(largestPrimeToGenerate);
    for (var i = 3; i <= rootOfLargestPrime + 1; i += 2)
    {
      var innerIndex = i + i;
      while (innerIndex < notPrimeArray.Length)
      {
        notPrimeArray[innerIndex] = true;
        innerIndex += i;
      }
    }
    
    var primes = new List<int>();
    for (var i = 0; i < notPrimeArray.Length; i++)
    {
      if (notPrimeArray[i] == false)
      {
        primes.Add(i);
      }
    }
    
    return primes;
  }
}
