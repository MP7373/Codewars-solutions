//https://www.codewars.com/kata/5a651865fd56cb55760000e0
const arrayLeaders = n => n.reduce((acc, cur, i) => cur > n.slice(i + 1).reduce((a, c) => a + c, 0) ? [...acc, cur] : acc, [])
