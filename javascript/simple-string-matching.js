//https://www.codewars.com/kata/simple-string-matching/javascript
const solve = (a, b) => {
  const aSplit = a.split('*');
  if (aSplit.length === 2) {
    return aSplit[0] ===  b.substring(0, aSplit[0].length)
    && aSplit[1] === b.substring(b.length - aSplit[1].length, b.length)
    && aSplit[0].length + aSplit[1].length <= b.length;
  }
  return a === b;
}
