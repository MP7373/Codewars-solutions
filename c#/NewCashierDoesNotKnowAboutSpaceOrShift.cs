//https://www.codewars.com/kata/5d23d89906f92a00267bb83d
using System.Collections.Generic;
using System;
using System.Linq;

public static class Kata
{
  public static string GetOrder(string input)
  {	
  	var arr = input.Replace("burger", "Burger ")
      .Replace("fries", "Fries ")
      .Replace("chicken", "Chicken ")
      .Replace("pizza", "Pizza ")
      .Replace("sandwich", "Sandwich ")
      .Replace("onionrings", "Onionrings ")
      .Replace("milkshake", "Milkshake ")
      .Replace("coke", "Coke ")
      .Trim()
      .Split(new [] { ' ' });
      
    var map = new Dictionary<string, int>
    {
      ["Burger"] = 1,
      ["Fries"] = 2,
      ["Chicken"] = 3,
      ["Pizza"] = 4,
      ["Sandwich"] = 5,
      ["Onionrings"] = 6,
      ["Milkshake"] = 7,
      ["Coke"] = 8,
    };
    
    Array.Sort(arr, (a, b) => map[a] == map[b] ? 0 : map[a] > map[b] ? 1 : -1);

    return String.Join(" ", arr);
  }
}
