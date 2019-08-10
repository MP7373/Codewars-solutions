//https://www.codewars.com/kata/56d67c7eecb553574900016c
const midPoint = str => str.split(' ')
  .map(s => s.length < 3 ? '' : s.length % 2 == 1 ?
   `${s[Math.floor(s.length / 2)]}` +
   midPoint(s.slice(0, Math.floor(s.length / 2))) +
   midPoint(s.slice(Math.floor(s.length / 2) + 1)) :
   `${s[s.length / 2 - 1]}${s[s.length / 2]}` +
   midPoint(s.slice(0, s.length / 2 - 1)) +
   midPoint(s.slice(s.length / 2 + 1))).join(' ')
