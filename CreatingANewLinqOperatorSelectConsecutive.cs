//https://www.codewars.com/kata/59e4b634f703c4c95c000097
namespace Kata
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public static class Ext
  {
    public static IEnumerable<TResult> SelectConsecutive<TSource, TResult>(
      this IEnumerable<TSource> source,
      Func<TSource, TSource, TResult> selector)
    {
      if (source == null || selector == null)
      {
        throw new ArgumentNullException();
      }
      
      return LazyEvaluatedSelectConsecutive(source, selector);
    }
    
    private static IEnumerable<TResult> LazyEvaluatedSelectConsecutive<TSource, TResult>(
      IEnumerable<TSource> source,
      Func<TSource, TSource, TResult> selector)
    {      
      var isFirstIteration = true;
      var previousItem = default(TSource);
      
      foreach (var item in source)
      {
        if (!isFirstIteration)
        {
          yield return selector(previousItem, item);
        }
        else
        {
          isFirstIteration = false;
        }
        
        previousItem = item;
      }
    }
  }
}
