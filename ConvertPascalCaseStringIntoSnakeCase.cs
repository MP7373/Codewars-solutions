//https://www.codewars.com/kata/529b418d533b76924600085d
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata 
{
  public static string ToUnderscore(int str) => str.ToString();

  public static string ToUnderscore(string str) =>
    String.Join("_", new Regex("[A-Z]+[a-z0-9]*").Matches(str).Select(s => s.ToString().ToLower()));
}
