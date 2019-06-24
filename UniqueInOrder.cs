//https://www.codewars.com/kata/unique-in-order
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) 
  {
    var list = new List<T>();
    var last = default(T);
    
    foreach (var item in iterable)
    {
      if (!(item.Equals(last)))
      {
        list.Add(item);
      }
      last = item;
    }
    
    return list;
  }
}
