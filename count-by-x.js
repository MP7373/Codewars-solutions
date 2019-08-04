//https://www.codewars.com/kata/5513795bd3fafb56c200049e
function countBy(x, n) {
  var z = [];
  const increment = x
  while (x <= increment * n) {
    z.push(x)
    x += increment
  }
  return z;
}
