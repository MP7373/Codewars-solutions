//https://www.codewars.com/kata/51e056fe544cf36c410000fb
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class TopWords
{
  public static List<string> Top3(string s)
  {
    var matches = new Regex(@"[A-Za-z]+('*[A-Za-z]*)*").Matches(s)
      .Select(match => match.Value.ToLower())
      .GroupBy(
        key => key,
        word => word,
        (key, words) => new
        {
          Key = key,
          Count = words.Count()
        })
      .ToArray();
    
    Array.Sort(matches, (a, b) => b.Count - a.Count);

    var top3 = new List<string>();
    for (var i = 0; i < 3 && i < matches.Length; i++)
    {
      top3.Add(matches[i].Key);
    }

    return top3;
  }
}
