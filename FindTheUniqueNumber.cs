//https://www.codewars.com/kata/585d7d5adb20cf33cb000235
using System.Collections.Generic;
using System.Linq;
using System;

public class Kata
{
  public static int GetUnique(IEnumerable<int> numbers) =>
    numbers.GroupBy(n => n).Where(g => g.Count() == 1).Select(g => g.Key).First();
}
