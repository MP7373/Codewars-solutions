//https://www.codewars.com/kata/537e18b6147aa838f600001b
using System;
using System.Text;
using System.Collections.Generic;

namespace Solution 
{
  public class Kata
  {
    public static string Justify(string str, int len)
    {
      if (str == null)
      {
        return "";
      }
      
      var sb = new StringBuilder();
      var words = str.Split(" ");
      var currentLinesWords = new List<string>();
      var sumOfLengthsOfCurrentLinesWords = 0;
      
      foreach (var word in words)
      {
        if (sumOfLengthsOfCurrentLinesWords + word.Length + currentLinesWords.Count > len)
        {
          sb.Append(CreateLine(ref currentLinesWords, ref sumOfLengthsOfCurrentLinesWords, len))
            .Append("\n");;
        }
        
        currentLinesWords.Add(word);
        sumOfLengthsOfCurrentLinesWords += word.Length;
      }
  
      foreach (var word in currentLinesWords)
      {
        sb.Append($"{word} ");
      }

      return sb.ToString().Trim(); ;
    }
    
    private static string CreateLine(ref List<string> words, ref int lengthSum, int lineLength)
    {
      var numberOfSpaces = lineLength - lengthSum;
      
      var slots = (words.Count - 1) > 0 ? (words.Count - 1) : 1;
      var spacesBewtweenEachWord = numberOfSpaces / slots;
      var extraSpaces = numberOfSpaces % slots;
      
      var smallerSpace = new string(' ', spacesBewtweenEachWord);
      var largerSpace = $"{smallerSpace} ";
      
      var sb = new StringBuilder();
      foreach (var word in words)
      {
        var wordAndSpace = extraSpaces > 0 ? $"{word}{largerSpace}" : $"{word}{smallerSpace}";
        sb.Append(wordAndSpace);
        extraSpaces--;
      }
      
      words = new List<string>();
      lengthSum = 0;
      
      return sb.ToString().Trim();
    }
  }
}
