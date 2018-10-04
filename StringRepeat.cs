//https://www.codewars.com/kata/57a0e5c372292dd76d000d7e
namespace Solution
{
  public static class Program
  {
    public static string repeatStr(int n, string s)
    {
      var repeatedStr = "";
      for (int i = 0; i < n; i++) {
        repeatedStr += s;
      }
      return repeatedStr;
    }
  }
}