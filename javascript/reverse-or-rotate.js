//https://www.codewars.com/kata/56b5afb4ed1f6d5fb0000991
function revrot(str, sz) {
  if (sz <= 0 || str === '' || sz > str.length) return ''

  let revrot = ''
  let i = 0
  while (i < str.length) {
    if (i + sz < str.length) {
      let rot = []
      let sumOfCubes = 0
      let j
      for (j = 0; j < sz; j++) {
        const num = parseInt(str[i + j], 10)
        sumOfCubes += Math.pow(num, 3)
        rot.push(num)
      }

      if (sumOfCubes % 2 === 0) {
        revrot += rot.reverse().join('')
      } else {
        revrot += [...rot.slice(1, rot.length), rot[0]].join('')
      }
      i += sz
    } else {
      return revrot
    }
  }

  return revrot
}
