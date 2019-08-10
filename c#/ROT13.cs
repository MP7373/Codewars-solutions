//https://www.codewars.com/kata/52223df9e8f98c7aa7000062
using System;
using System.Linq;

public class Kata
{
  public static string Rot13(string input) => String.Join("",
    input.Select(c => c >= 'A' && c <= 'M' ? (char) (c + 13) :
      c >= 'N' && c <= 'Z' ? (char) ((c + 13) % 91 + 65) :
      c >= 'a' && c <= 'm' ? (char) (c + 13) :
      c >= 'n' && c <= 'z' ? (char) ((c + 13) % 91 + 65) :
      c));
}
