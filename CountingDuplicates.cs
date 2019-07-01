//https://www.codewars.com/kata/54bf1c2cd5b56cc47f0007a1
using System;
using System.Collections.Generic;

public class Kata
{
  public static int DuplicateCount(string str)
  {
    var usedCharacters = new Dictionary<char, int>();
    var numberOfDuplicates = 0;
    
    foreach (var character in str)
    {
      var lowerCaseCharacter = Char.ToLower(character);
      
      if (usedCharacters.ContainsKey(lowerCaseCharacter))
      {
        if (usedCharacters[lowerCaseCharacter] == 1)
        {
          numberOfDuplicates++;
        }
        
        usedCharacters[lowerCaseCharacter]++;
      }
      else
      {
        usedCharacters[lowerCaseCharacter] = 1;
      }
    }
    
    return numberOfDuplicates;
  }
}
