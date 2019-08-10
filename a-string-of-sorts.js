// https://www.codewars.com/kata/536c6b8749aa8b3c2600029a
function sortString (string, ordering) {
  const charSortValueMap = {};
  [...ordering].forEach((c, i) => {
    if (charSortValueMap[c] === undefined) {
      charSortValueMap[c] = i
    }
  })

  let newStr = ''
  let endOfStr = '';
  [...string].forEach(c => {
    if (charSortValueMap[c] === undefined) {
      endOfStr += c
    } else {
      newStr += c
    }
  })

  if (endOfStr == string) return string
  return [...newStr].sort((a, b) => charSortValueMap[a] - charSortValueMap[b]).join('') + endOfStr
}
