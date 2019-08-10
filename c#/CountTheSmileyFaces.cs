//https://www.codewars.com/kata/583203e6eb35d7980400002a
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata
{
  public static int CountSmileys(string[] s)=>s.Count(x =>Regex.IsMatch(x,"[:;][-~]?[)D]"));
}
