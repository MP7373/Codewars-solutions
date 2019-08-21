//https://www.codewars.com/kata/57cebe1dc6fdc20c57000ac9
const findShort = s => s.split(' ').reduce((acc, cur) => cur.length < acc ? cur.length : acc, Number.MAX_VALUE)
