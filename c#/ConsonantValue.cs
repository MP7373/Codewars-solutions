//https://www.codewars.com/kata/59c633e7dcc4053512000073
using System;
using System.Linq;

public class Kata
{
    public static int Solve(string s) => s.Split(new [] { 'a', 'e', 'i', 'o', 'u' })
          .Select(consonantSubstring => consonantSubstring.ToCharArray()
            .Select(c => ((int) c) - 96)
            .Sum())
          .Max();
}
