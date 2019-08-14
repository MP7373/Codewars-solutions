//https://www.codewars.com/kata/59d9ff9f7905dfeed50000b0
function solve(arr) {
  return arr.map(s => {
    let sum = 0;
    [...s].forEach((c, i) => {
      if (c.toUpperCase().charCodeAt(0) - 65 - i === 0)
        sum++
    })
    
    return sum
  })
}
