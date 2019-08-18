//https://www.codewars.com/kata/5878520d52628a092f0002d0
const stringTransformer = str => str.split(/\s/)
  .map(c => [...c].map(ch => /[a-z]/.test(ch) ? ch.toUpperCase() : ch.toLowerCase()).join(''))
  .reverse()
  .join(' ')
