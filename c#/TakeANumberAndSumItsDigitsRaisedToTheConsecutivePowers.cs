//https://www.codewars.com/kata/5626b561280a42ecc50000d1
using System;
using System.Linq;

public class SumDigPower {  
  public static long[] SumDigPow(long a, long b) => Enumerable.Range((int) a, (int) (b - a))
    .Where(n => n == $"{n}".Select((c, i) => (long) Math.Pow(Char.GetNumericValue(c), i + 1)).Sum())
    .Select(n => (long) n)
    .ToArray();
}
