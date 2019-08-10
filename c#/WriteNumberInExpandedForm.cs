//https://www.codewars.com/kata/5842df8ccbd22792a4000245
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata 
{
    public static string ExpandedForm(long num) =>
      Regex.Replace(String.Join(" + ", num.ToString().ToCharArray().Select((c, i) =>
      (Math.Pow(10, (num.ToString().Length - i - 1)) * Char.GetNumericValue(c)).ToString())), "( 0 +\\W)|(\\W+\\W0)", "");
}
