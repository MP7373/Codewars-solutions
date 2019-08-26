//https://www.codewars.com/kata/57eb8fcdf670e99d9b000272
const high = s => s.split(' ')
  .reduce((acc, cur) => [...cur].reduce((a, c) => a + c.charCodeAt(0) - 96, 0) >
    [...acc].reduce((a, c) => a + c.charCodeAt(0) - 96, 0) ?
      cur :
      acc
  , '')
