//https://www.codewars.com/kata/is-my-friend-cheating
using System;
using System.Collections.Generic;
using System.Linq;

public class RemovedNumbers {
	public static List<long[]> removNb(long n) {
    var pairs = new List<long[]>();
    var reversePairs = new List<long[]>();
    var sum = (n * n + n) / 2;
    var right = n;
    
    for (var left = 1; left < right; left++)
    {
      while (left * right > (sum - left - right) && left < right)
      {
        right--;
      }
      
      if (left * right == (sum - left - right))
      {
        pairs.Add(new long[] { left, right });
        reversePairs.Add(new long[] { right, left });
      }
    }
    reversePairs.Reverse();
    pairs.AddRange(reversePairs);
    
		return pairs;
	}
}
