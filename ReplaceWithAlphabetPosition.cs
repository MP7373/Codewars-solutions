//https://www.codewars.com/kata/546f922b54af40e1e90001da
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata
{
  public static string AlphabetPosition(string text) => String.Join(" ", 
      text.Where(c => new Regex("[a-zA-Z]").IsMatch(Char.ToString(c)))
          .Select(c => $"{((int) Char.ToUpper(c)) - 64}"));
}
