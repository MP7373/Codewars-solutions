//https://www.codewars.com/kata/57b06f90e298a7b53d000a86
using System.Collections.Generic;
using System;

public class Kata
{
    public static long QueueTime(int[] customers, int n)
    {
        if (customers.Length == 0) return 0;

        var queue = new int[n];
        var timeTicks = 0;
        var customerIndex = 0;

        var fillIndex = 0;
        while (fillIndex < n && customerIndex < customers.Length)
        {
            queue[fillIndex++] = customers[customerIndex++];
        }

        var allZero = false;
        while (!allZero)
        {
            allZero = true;
            for (var i = 0; i < n; i++)
            {
                if (queue[i] == 1)
                {
                    if (customerIndex < customers.Length)
                    {
                        queue[i] = customers[customerIndex++];
                        allZero = false;
                    }
                    else
                    {
                        queue[i] = 0;
                    }
                }
                else if (queue[i] > 1)
                {
                    allZero = false;
                    queue[i]--;
                }
            }

            timeTicks++;
        }

        return timeTicks;
    }
}
