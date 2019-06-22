//https://www.codewars.com/kata/5765870e190b1472ec0022a2
using System;

public class Finder {
    
    public static bool PathFinder(string stringMaze) {
        var maze = stringMaze.Split('\n');
        var visited = new bool[maze.Length, maze[0].Length];
        
        return Search(maze, visited, 0, 0);
    }
    
    private static bool Search(string[] maze, bool[,] visited, int x, int y)
    {
      visited[y, x] = true; 
      return (y == maze.Length - 1 && x == maze[0].Length - 1) ||
        ((y - 1 >= 0 && !visited[y - 1, x] && maze[y - 1][x] != 'W' && Search(maze, visited, x, y - 1))) ||
        ((x + 1 < maze[0].Length && !visited[y, x + 1] && maze[y][x + 1] != 'W' && Search(maze, visited, x + 1, y))) ||
        ((y + 1 < maze.Length && !visited[y + 1, x] && maze[y + 1][x] != 'W' && Search(maze, visited, x, y + 1))) ||
        ((x - 1 >= 0 && !visited[y, x - 1] && maze[y][x - 1] != 'W' && Search(maze, visited, x - 1, y)));
    }
}
