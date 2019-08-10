//https://www.codewars.com/kata/training-js-number-32-methods-of-math-round-ceil-and-floor/
const roundIt = n => {
  const [l, r] = n.toString().split('.').map(e => e.length);
  return l > r ? Math.floor(n) : l < r ? Math.ceil(n) : Math.round(n);
};
