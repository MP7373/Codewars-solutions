//https://www.codewars.com/kata/555615a77ebc7c2c8a0000b8
public class Line
{
  public static string Tickets(int[] peopleInLine)
  {
    var fifties = 0;
    var twentyFives = 0;
    
    foreach (var bill in peopleInLine)
    {
      var owed = bill - 25;
      
      switch (bill)
      {
        case 50:
          fifties++;
          break;
        case 25:
          twentyFives++;
          break;
      }
      
      if (owed == 75 && fifties > 0)
      {
        owed = 25;
        fifties--;
      }
      
      while (owed > 0 && twentyFives > 0)
      {
        owed -= 25;
        twentyFives--;
      }
      
      if (owed > 0)
      {
        return "NO";
      }
    }
    
    return "YES";
  }
}
