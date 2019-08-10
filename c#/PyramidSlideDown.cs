//https://www.codewars.com/kata/551f23362ff852e2ab000037
using System.Linq;

public class PyramidSlideDown
{
  public static int LongestSlideDown(int[][] pyramid)
  { 
    var pathSums = new int[pyramid[pyramid.Length - 1].Length];
    pathSums[0] = pyramid[0][0];
    
    for (var layer = 1; layer < pyramid.Length; layer++)
    {
      var rightParent = pathSums[0];
      pathSums[0] += pyramid[layer][0];
      
      var lastIndexInLayer = pyramid[layer].Length - 1;
      
      for (var indexInLayer = 1; indexInLayer < lastIndexInLayer; indexInLayer++)
      {
        var currentValue = pyramid[layer][indexInLayer];
        var leftParent = rightParent;
        rightParent = pathSums[indexInLayer];
        
        pathSums[indexInLayer] = leftParent > rightParent ? leftParent + currentValue : rightParent + currentValue;
        
      }
      
      pathSums[lastIndexInLayer] = rightParent + pyramid[layer][lastIndexInLayer];
    }
    
    return pathSums.Max();
  }
}
