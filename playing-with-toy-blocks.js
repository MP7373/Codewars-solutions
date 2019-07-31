//https://www.codewars.com/kata/5cab471da732b30018968071
function buildSquare(blocks) {
  let layer = 1

  let fours = 0
  let threes = 0
  let twos = 0
  let ones = 0

  blocks.forEach(block => {
    switch (block) {
      case 4: fours++
        break
      case 3: threes++
        break
      case 2: twos++
        break
      case 1: ones++
    }
  })

  while (fours > 0) {
    fours--
    layer++
    if (layer === 5) return true
  }

  while (threes > 0 && ones > 0) {
    threes--
    ones--
    layer++
    if (layer === 5) return true
  }

  while (twos > 1) {
    twos -= 2
    layer++
    if (layer === 5) return true
  }

  while (twos > 0 && ones > 1) {
    twos--
    ones -= 2
    layer++
    if (layer === 5) return true
  }

  while (ones > 3) {
    ones -= 4
    layer++
    if (layer === 5) return true
  }

  return false
}
