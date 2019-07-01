//https://www.codewars.com/kata/552c028c030765286c00007d
using System;
using System.Linq;

public class IQ
{
  public static int Test(string numbers) => (int) numbers.Split(' ')
      .Select((c, i) => new int[] { Int32.Parse(c), Int32.Parse(c) % 2, i })
      .GroupBy(
        key => key[1],
        val => new { val = val[0], i = val[2] },
        (a, b) => new
        {
          Key = a,
          Value = b.Average(x => x.i),
          Count = b.Count()
        }
      )
      .OrderBy(pairs => pairs.Count)
      .Take(1)
      .ToList()[0].Value + 1;
}
