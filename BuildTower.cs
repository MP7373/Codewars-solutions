//https://www.codewars.com/kata/576757b1df89ecf5bd00073b
public class Kata
{
  public static string[] TowerBuilder(int nFloors)
  {
    var tower = new string[nFloors];
    var rowWidth = 1 + (nFloors - 1) * 2;
    var spacesOnEachSide = rowWidth / 2;
    var numberOfStarsInRow = 1;
    
    for (var i = 0; i < nFloors; i++)
    {
      var padding = new string(' ', spacesOnEachSide);
      tower[i] = $"{padding}{new string('*', numberOfStarsInRow)}{padding}";
      
      spacesOnEachSide--;
      numberOfStarsInRow += 2;
    }
    
    return tower;
  }
}
