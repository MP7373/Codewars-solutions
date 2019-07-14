//https://www.codewars.com/kata/57d7536d950d8474f6000a06
using System.Collections.Generic;

public class Dinglemouse 
{
  public static int[] FindWrongWayCow(char[][] field) 
  {
    var cowsEncountered = 0;
    var cowDirectionTable = new Dictionary<string, int>()
    {
      ["East"] = 0,
      ["South"] = 0,
      ["West"] = 0,
      ["North"] = 0
    };
    var firstCowCordninates = new [] { 0, 0 };
    var lastCordninates = new [] { 0, 0 };
    var differntdirectionCowAlreadyEncountered = false;
    var cowDirection = "";
    var lastCowDirection = cowDirection;
    
    for (var x = 0; x < field[0].Length; x++)
    {
      for (var y = 0; y < field.Length; y++)
      {
        if (field[y][x] == 'c')
        {
          cowsEncountered++;
          
          if (cowsEncountered == 1)
          {
            firstCowCordninates = new [] { x, y };
            lastCowDirection = GetCowDirection(x, y, field);
          }
          
          cowDirection = GetCowDirection(x, y, field);
          cowDirectionTable[cowDirection]++;
          
          if (cowDirection != lastCowDirection)
          {
            differntdirectionCowAlreadyEncountered = true;
          }
          
          if (differntdirectionCowAlreadyEncountered && cowsEncountered >= 3)
          {
            if (cowDirectionTable[cowDirection] == 1)
            {
              return new [] { x, y };
            }
            
            return lastCowDirection != cowDirection ? lastCordninates : firstCowCordninates;
          }
          
          lastCowDirection = cowDirection;
          
          lastCordninates[1] = y;
          lastCordninates[0] = x;
        }
      }
    }
    
    return null;
  }
  
  private static string GetCowDirection(int x, int y, char[][] field)
  {
    if (x + 2 < field[0].Length && field[y][x + 1] == 'o' && field[y][x + 2] == 'w')
    {
      return "East";
    }
    
    if (y + 2 < field.Length && field[y + 1][x] == 'o' && field[y + 2][x] == 'w')
    {
      return "South";
    }
    
    if (x - 2 >= 0 && field[y][x - 1] == 'o' && field[y][x - 2] == 'w')
    {
      return "West";
    }
    
    if (y - 2 >= 0 && field[y - 1][x] == 'o' && field[y - 2][x] == 'w')
    {
      return "North";
    }
    
    return null;
  }
}
