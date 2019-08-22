//https://www.codewars.com/kata/52761ee4cffbc69732000738
const goodVsEvil = (good, evil) =>
  good.split(' ').reduce((acc, cur, i) => acc + parseInt(cur, 10) * [1, 2, 3, 3, 4, 10][i], 0) >
  evil.split(' ').reduce((acc, cur, i) => acc + parseInt(cur, 10) * [1, 2, 2, 2, 3, 5, 10][i], 0) ?
    'Battle Result: Good triumphs over Evil' :
    good.split(' ').reduce((acc, cur, i) => acc + parseInt(cur, 10) * [1, 2, 3, 3, 4, 10][i], 0) <
    evil.split(' ').reduce((acc, cur, i) => acc + parseInt(cur, 10) * [1, 2, 2, 2, 3, 5, 10][i], 0) ?
      'Battle Result: Evil eradicates all trace of Good' :
      'Battle Result: No victor on this battle field'
