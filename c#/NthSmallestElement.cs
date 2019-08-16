//https://www.codewars.com/kata/5a512f6a80eba857280000fc
class Kata
{
  public static int NthSmallest(int[] arr, int pos)
  {
    return QuickSelect(arr, 0, arr.Length, pos);
  }
  
  private static int QuickSelect(int[] arr, int start, int end, int pos)
  {
    var pivotIndex = start;
    
    var movingEnd = end;
    var i = start + 1;
    while (i < movingEnd)
    {
      if (arr[i] < arr[pivotIndex])
      {
        var temp = arr[pivotIndex];
        arr[pivotIndex] = arr[i];
        arr[i] = temp;
        pivotIndex = i++;
      }
      else
      {
        var temp = arr[i];
        arr[i] = arr[movingEnd - 1];
        arr[--movingEnd] = temp;
      }
    }
    
    if (pivotIndex == pos - 1)
    {
      return arr[pivotIndex];
    }
    
    if (pivotIndex < pos - 1)
    {
      return QuickSelect(arr, pivotIndex + 1, end, pos);
    }

    return QuickSelect(arr, start, pivotIndex, pos);
  }
}
