//https://www.codewars.com/kata/57658bfa28ed87ecfa00058a
using System.Collections.Generic;
using System.Linq;
using System;

public class Finder
{
  public static int PathFinder(string mazeString)
  {
    var maze = mazeString.Split('\n');
    var visited = new bool[maze.Length, maze[0].Length];
    
    var stepsTaken = 0;
    var nextToVisit = new Queue<int[]>();
    var nextLayerNextToVisit = new Queue<int[]>();
    nextToVisit.Enqueue(new [] { 0, 0 });
    
    do
    {
      var currentTile = nextToVisit.Dequeue();
      var y = currentTile[0];
      var x = currentTile[1];
      
      if (y == maze.Length - 1 && x == maze[0].Length - 1)
      {
        return stepsTaken;
      }
      
      if (y > 0 && !visited[y - 1, x] && !(maze[y - 1][x] == 'W'))
      {
        nextLayerNextToVisit.Enqueue(new [] { y - 1, x });
        visited[y - 1, x] = true;
      }
      
      if (x + 1 < maze[0].Length && !visited[y, x + 1] && !(maze[y][x + 1] == 'W'))
      {
        nextLayerNextToVisit.Enqueue(new [] { y, x + 1 });
        visited[y, x + 1] = true;
      }
      
      if (y + 1 < maze.Length && !visited[y + 1, x] && !(maze[y + 1][x] == 'W'))
      {
        nextLayerNextToVisit.Enqueue(new [] { y + 1, x });
        visited[y + 1, x] = true;
      }
      
      if (x > 0 && !visited[y, x - 1] && !(maze[y][x - 1] == 'W'))
      {
        nextLayerNextToVisit.Enqueue(new [] { y, x - 1 });
        visited[y, x - 1] = true;
      }
      
      if (nextToVisit.Count == 0 && nextLayerNextToVisit.Count > 0)
      {
        nextToVisit = nextLayerNextToVisit;
        nextLayerNextToVisit = new Queue<int[]>();
        stepsTaken++;
      }
    }
    while (nextToVisit.Count > 0);
    
    return -1;
  }
}
