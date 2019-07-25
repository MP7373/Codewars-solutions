//https://www.codewars.com/kata/545cedaa9943f7fe7b000048
function isPangram(string) {
  const containsLetterToZ = (s, letter) => 
    letter > 'z' ? true : 
      (s.includes(letter) || s.includes(letter.toUpperCase())) &&
      containsLetterToZ(s, String.fromCharCode(letter.charCodeAt(0) + 1))
  return containsLetterToZ(string, 'a')
}
