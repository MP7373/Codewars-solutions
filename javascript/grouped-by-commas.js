//https://www.codewars.com/kata/5274e122fc75c0943d000148
function groupByCommas(n) {
  const nString = n.toString()
  if (nString.length < 4) return nString
  
  let newString = ''
  let i = 0
  while (nString.length - 1 - i >= 0) {
    newString = nString[nString.length - 1 - i] + newString
    if (nString.length - 1 - i > 0 && i % 3 === 2) {
      newString = ',' + newString
    }
    i++
  }
  
  return newString
}
