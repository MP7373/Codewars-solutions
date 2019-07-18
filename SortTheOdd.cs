//https://www.codewars.com/kata/578aa45ee9fd15ff4600090d
using System;
using System.Linq;

public class Kata
{
  public static int[] SortArray(int[] array)
  {
    Func<int, bool> isOdd = (n) => n % 2 == 1;
    var odds = array.Where(isOdd).ToArray();
    
    Array.Sort(odds);
    
    var oddsIndex = 0;
    for (var i = 0; i < array.Length; i++)
    {
      if (isOdd(array[i]))
      {
        array[i] = odds[oddsIndex];
        oddsIndex++;
      }
    }
    
    return array;
  }
}
