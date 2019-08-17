//https://www.codewars.com/kata/59fa8e2646d8433ee200003f
using System;

class Kata
{
  public static int[] SortByBit(int[] array)
  {    
    Array.Sort(array, (a, b) =>
    {
      var aBits = GetBitsFromNumber(a);
      var bBits = GetBitsFromNumber(b);
      
      return aBits != bBits ? aBits - bBits : a - b;
    });

    return array;
  }
  
  private static int GetBitsFromNumber(int number)
  {
    var bits = 0;
    
    while (number > 0)
    {
      if (number % 2 != 0)
      {
        bits++;
      }
      
      number = number >> 1;
    }
    
    return bits;
  }
}
