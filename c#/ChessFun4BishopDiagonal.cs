//https://www.codewars.com/kata/5897e394fcc4b9c310000051
namespace myjinxin
{
    using System;
    using System.Linq;
    
    public class Kata
    {
        public string[] BishopDiagonal(string bishop1, string bishop2){
          Func<char, int> letterToXCoordinate = (c) => ((int) c) - 96;
          Func<double, char> xCoordinateToLetter = (x) => (char) ((int) x + 96);
          
          var bishop1Coordinates = new [] { letterToXCoordinate(bishop1[0]), Char.GetNumericValue(bishop1[1])};
          var bishop2Coordinates = new [] { letterToXCoordinate(bishop2[0]), Char.GetNumericValue(bishop2[1])};
          
          var x1 = bishop1Coordinates[0];
          var y1 = bishop1Coordinates[1];
          
          var x2 = bishop2Coordinates[0];
          var y2 = bishop2Coordinates[1];
          
          if (x1 + y1 != x2 + y2 && x1 - y1 != x2 - y2)
          {
            var a = new [] { bishop1, bishop2 };
            var b = new [] { bishop2, bishop1 };
            return  x1 < x2  ? a : x1 > x2 ? b : y1 <= y2 ? a : b;
          }
          
          if (x1 < x2)
          {
            if (y1 < y2)
            {
              while (x1 > 1 && y1 > 1)
              {
                x1--;
                y1--;
              }
              while (x2 < 8 && y2 < 8)
              {
                x2++;
                y2++;
              }
            }
            else
            {
              while (x1 > 1 && y1 < 8)
              {
                x1--;
                y1++;
              }
              while (x2 < 8 && y2 > 1)
              {
                x2++;
                y2--;
              }
            }
          }
          else
          {
            if (y1 < y2)
            {
              while (x1 < 8 && y1 > 1)
              {
                x1++;
                y1--;
              }
              while (x2 > 1 && y2 < 8)
              {
                x2--;
                y2++;
              }
            }
            else
            {
              while (x1 < 8 && y1 < 8)
              {
                x1++;
                y1++;
              }
              while (x2 > 1 && y2 > 1)
              {
                x2--;
                y2--;
              }
            }
          }
          
          var j = new [] { $"{xCoordinateToLetter(x1)}{y1}", $"{xCoordinateToLetter(x2)}{y2}" };
          var k = new [] { $"{xCoordinateToLetter(x2)}{y2}", $"{xCoordinateToLetter(x1)}{y1}" };
          return  x1 < x2 ? j : x1 > x2 ? k : y1 <= y2 ? j : k;
        }
    }
}
