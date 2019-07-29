//https://www.codewars.com/kata/541af676b589989aed0009e7
using System;
public static class Kata
{
   public static int CountCombinations(int money, int[] coins)
   {
     Array.Sort(coins);
     var combinations = 0;
     RecursivelyCountCombinations(money, coins, coins.Length - 1, 0, ref combinations);
     return combinations;
   }
   
   private static void RecursivelyCountCombinations(int money, int[] coins, int index, int sum, ref int combinations)
   {
     if (index == 0)
     {
       if (money - sum > 0 && (money - sum) % coins[index] == 0)
       {
         combinations++;
       }
       return;
     }

     while (sum < money)
     {
       RecursivelyCountCombinations(money, coins, index - 1, sum, ref combinations);
       sum += coins[index];
     }
     
     if (sum == money)
     {
       combinations++;
     }
   }
}
