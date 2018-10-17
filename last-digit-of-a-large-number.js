//https://www.codewars.com/kata/last-digit-of-a-large-number/
const lastDigit = (str1, str2) => {
  const str1LastDigit = parseInt(str1.charAt(str1.length - 1));
  let period;
  if ([0, 1, 5, 6].includes(str1LastDigit)) {
    period = 1;
  } else if ([2, 3, 7, 8].includes(str1LastDigit)) {
    period = 4;
  } else {
    period = 2;
  }
  let sequence = [];
  for (let i = 1; i <= period; i++) {
    const powered = str1LastDigit ** i;
    const poweredString = powered.toString();
    const lastChar = poweredString.slice(-1);
    const lastInt = parseInt(lastChar);
    sequence.push(lastInt);
    //sequence.push(parseInt((str1LastDigit ** i).toString().slice(-1)));
  }
  const result = sequence[(parseInt(str2) % period) - 1];
  return result;
};

lastDigit("9", "7");
