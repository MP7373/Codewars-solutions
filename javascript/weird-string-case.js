//https://www.codewars.com/kata/52b757663a95b11b3d00062d
const toWeirdCase = string => string.split(' ')
  .map(s => [...s]
    .map((c, i) => i % 2 == 0 ? c.toUpperCase() : c.toLowerCase())
    .join(''))
  .join(' ')
