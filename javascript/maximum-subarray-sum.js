//https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c
const maxSequence = function(arr) {
  if (arr.length === 0) return 0;
  
  let sum = 0;
  let largest = null;
  let lastNumIsPositive = arr[0] >= 0 ? true : false;
  let currentNumIsPositive;

  for (let i = 0; i < arr.length; i++) {
    currentNumIsPositive = arr[i] >= 0 ? true : false;

    if (currentNumIsPositive !== lastNumIsPositive) {
      if (sum > largest || largest === null) {
        largest = sum;
      }
  
      if (currentNumIsPositive && sum < 0) {
        sum = 0;
      }
    } 

    sum += arr[i];
    
    if (i + 1 === arr.length) {
      if (sum > largest) {
        largest = sum;
      }  
    }
    
    lastNumIsPositive = currentNumIsPositive;
  }

  return largest > 0 ? largest : 0;
};
