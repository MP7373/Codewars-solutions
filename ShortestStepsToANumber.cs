//https://www.codewars.com/kata/5cd4aec6abc7260028dcd942
namespace Solution
{
  public static class Kata
  {
    public static int ShortestStepsToNum(int num)
    {
      var steps = 0;
      
      while (num > 1)
      {
        num = num % 2 == 0 ? num / 2 : num - 1;
        steps++;
      }
      
      return steps;
    }
  }
}
