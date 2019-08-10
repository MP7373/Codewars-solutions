//https://www.codewars.com/kata/546e2562b03326a88e000020
using System;

public class Kata
{
  public static int SquareDigits(int n)
  {
    var nStr = n.ToString();
    int charNum;
    var finalStr = "";
    for (int i = 0; i < nStr.Length; i++)
    {
      charNum = (int)Char.GetNumericValue(nStr[i]);
      finalStr += (charNum * charNum).ToString();
    }
    return Int32.Parse(finalStr);
  }
}
