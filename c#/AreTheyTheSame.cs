//https://www.codewars.com/kata/550498447451fbbd7600041c
using System;
using System.Collections.Generic;

class AreTheySame
{
  public static bool comp(int[] a, int[] b)
  {    
    if (a == null || b == null || a.Length != b.Length)
    {
      return false;
    }
    
    var numbersInASquared = new Dictionary<int, int>();
    foreach (var number in a)
    {
      var numberSquared = number * number;
      
      if (!numbersInASquared.ContainsKey(numberSquared))
      {
        numbersInASquared.Add(numberSquared, 1);
      }
      else
      {
        numbersInASquared[numberSquared]++;
      }
    }

    foreach (var number in b)
    {
      if (!numbersInASquared.ContainsKey(number) || numbersInASquared[number] == 0)
      {
        return false;
      }
      
      numbersInASquared[number]--;
    }

    return true;
  }
}
