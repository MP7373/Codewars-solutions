//https://www.codewars.com/kata/55c45be3b2079eccff00010f
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Kata
{
  public static string Order(string words)
  {
    var wordArray = words.Split(' ');
    if (wordArray.Length == 0)
    {
      return "";
    }
    
    var oneThroughNine = new HashSet<int>();
    for (var i = 1; i <= 9; i++)
    {
      oneThroughNine.Add(i);
    }
    
    var wordValues = new Dictionary<string, int>();
    foreach (var word in wordArray)
    {
      var numberInWord = -1;
      foreach (var character in word)
      {
        var characterAsNumber = ((int) character) - 48;
        if (oneThroughNine.Contains(characterAsNumber))
        {
          numberInWord = characterAsNumber;
          break;
        }
      }
      
      if (numberInWord == -1)
      {
        return "";
      }
      
      wordValues[word] = numberInWord;
    }
    
    var wordValuesList = wordValues.ToList();

    wordValuesList.Sort((a, b) => a.Value.CompareTo(b.Value));
    
    var sb = new StringBuilder();
    
    sb.Append(wordValuesList[0].Key);
    for (var i = 1; i < wordValuesList.Count; i++)
    {
      sb.Append($" {wordValuesList[i].Key}");
    }
    
    return sb.ToString();
  }
}
