//https://www.codewars.com/kata/55fd2d567d94ac3bc9000064
function rowSumOddNumbers(n) {
  let numInRow = 0
  let row = 1
  let num = 1
  
  while (row < n) {
    num += 2
    numInRow++
    if (numInRow >= row) {
      numInRow = 0
      row++
    }
  }
  
  let sum = 0
  while (numInRow < row) {
    numInRow++
    sum += num
    num += 2
  }
  
  return sum
}
