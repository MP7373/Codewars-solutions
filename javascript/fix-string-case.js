//https://www.codewars.com/kata/5b180e9fedaa564a7000009a
const solve = s => [...s].filter(c => c.toUpperCase() === c).length > s.length / 2 ? s.toUpperCase() : s.toLowerCase()
