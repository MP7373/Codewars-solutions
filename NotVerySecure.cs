//https://www.codewars.com/kata/526dbd6c8c0eb53254000110
using System.Text.RegularExpressions;

public class Kata
{
  public static bool Alphanumeric(string str) => new Regex("^[a-zA-Z0-9]+$").IsMatch(str);
}
