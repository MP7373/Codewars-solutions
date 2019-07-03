//codewars.com/kata/517abf86da9663f1d2000003
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Kata
{
  public static string ToCamelCase(string str) => string.Join("", Regex.Split(str, "[-_]")
    .Select((s, i) => i > 0 ? s.Substring(0, 1).ToUpper() + s.Substring(1) : s));
}
