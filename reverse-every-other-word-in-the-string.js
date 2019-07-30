//https://www.codewars.com/kata/58d76854024c72c3e20000de
const reverse = str => str.split(' ').map((s, i) => i % 2 == 1 ? [...s].reverse().join('') : s).join(' ').trim()
