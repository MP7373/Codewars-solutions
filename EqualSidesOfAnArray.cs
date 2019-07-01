//https://www.codewars.com/kata/5679aa472b8f57fb8c000047
using System;
using System.Linq;

public class Kata
{
  public static int FindEvenIndex(int[] arr)
  {
    var rightSum = arr.Sum();
    var leftSum = 0;
    
    for (var i = 0; i < arr.Length; i++)
    {
      rightSum -= arr[i];
      
      if (rightSum == leftSum)
      {
        return i;
      }
      
      leftSum += arr[i];
    }
    
    return -1;
  }
}
