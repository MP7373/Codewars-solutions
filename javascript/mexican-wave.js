//https://www.codewars.com/kata/58f5c63f1e26ecda7e000029
const wave = s => [...s]
  .map((c, i) => s.slice(0, i) + c.toUpperCase() + s.slice(i + 1))
  .filter(c => c != s)
