//https://www.codewars.com/kata/563f037412e5ada593000114
using System;

public class Kata
{
  public static int CalculateYears(double principal, double interest,  double tax, double desiredPrincipal)
  {
    int years = 0;
    interest = interest * (1 - tax) + 1;
    while (principal < desiredPrincipal)
    {
      principal *= interest;
      years++;
    }
    return years;
  }
}
