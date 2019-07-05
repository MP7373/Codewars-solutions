//https://www.codewars.com/kata/5287e858c6b5a9678200083c
using System;
using System.Linq;

public class Kata
{
  public static bool Narcissistic(int n)
  {
    var digits = n.ToString().Select(d => Char.GetNumericValue(d)).ToList();
    return digits.Select(d => Math.Pow(d, digits.Count)).Sum() == n;
  }
}
