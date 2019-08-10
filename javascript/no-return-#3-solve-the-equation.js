//https://www.codewars.com/kata/no-return-number-3-solve-the-equation
const nextAcc = (last, cur, acc, xIsNegative, negative, currentVal, passedEqual = false, resetCurrentVal = false) => Object.create({
  ...acc,
  lastWasNumber: false,
  last: cur,
  lastLast: acc.lastWasNumber ?
    true :
    last,
  xIsNegative: xIsNegative,
  negative: acc.lastWasNumber ?
    cur == '-' :
    cur == '-' && last != '-',
  passedEqual: passedEqual,
  currentVal: resetCurrentVal ? '' : currentVal,
  sum: !resetCurrentVal ?
    acc.sum :
    currentVal != '' ?
      negative ?
        acc.sum - (passedEqual ?
          -parseFloat(currentVal, 10) :
          parseFloat(currentVal, 10)) :
        acc.sum + (passedEqual ?
          -parseFloat(currentVal, 10) :
          parseFloat(currentVal, 10)) :
      acc.sum
})

const isNegative = (lastOperator, operatorBeforeLastOperator) => lastOperator == '-' ?
  operatorBeforeLastOperator == '-' ?
    false :
    true :
  false


const solve = expression => [...expression.replace(/\s+/g, '')]
  .reduce((acc, cur, i) => i == expression.replace(/\s+/g, '').length - 1 ?
      cur == 'x' ?
        isNegative(acc.last, acc.lastLast) ? 
          -acc.sum :
          acc.sum : 
      !acc.xIsNegative ?
        acc.sum + (isNegative(acc.last, acc.lastLast) ?
            acc.passedEqual ?
              parseFloat(acc.currentVal + cur, 10) :
              -parseFloat(acc.currentVal + cur, 10) :
            acc.passedEqual ?
              -parseFloat(acc.currentVal + cur, 10) :
              parseFloat(acc.currentVal + cur, 10)) :
        (-acc.sum + (isNegative(acc.last, acc.lastLast) ?
            acc.passedEqual ?
              -parseFloat(acc.currentVal + cur, 10) :
              parseFloat(acc.currentVal + cur, 10) :
            acc.passedEqual ?
              parseFloat(acc.currentVal + cur, 10) :
              -parseFloat(acc.currentVal + cur, 10))) :
    cur == '-' ?
      nextAcc(acc.last, cur, acc, acc.xIsNegative, acc.negative, acc.currentVal, acc.passedEqual, true) :
    cur == 'x' ?
      acc.passedEqual ?
        acc.negative ?
          nextAcc(acc.last, cur, acc, true, false, acc.currentVal, acc.passedEqual, true) :
          nextAcc(acc.last, cur, acc, false, false, acc.currentVal, acc.passedEqual, true) :
        acc.negative ?
          nextAcc(acc.last, cur, acc, false, false, acc.currentVal, acc.passedEqual, true) :
          nextAcc(acc.last, cur, acc, true, false, acc.currentVal, acc.passedEqual, true) :
    cur == '=' ?
      {
        ...acc,
        xIsNegative: acc.xIsNegative,
        negative: false,
        last: cur,
        passedEqual: true,
        currentVal: '',
        sum: acc.last != 'x' && acc.currentVal != '' ?
          acc.negative ?
            acc.sum - parseFloat(acc.currentVal, 10) :
            acc.sum + parseFloat(acc.currentVal, 10) :
          acc.sum
      } :
    cur == '+' ?
      nextAcc(acc.last, cur, acc, acc.xIsNegative, acc.negative, acc.currentVal, acc.passedEqual, true) :
    {
      ...acc,
      xIsNegative: acc.xIsNegative,
      sum: acc.sum,
      passedEqual: acc.passedEqual,
      last: acc.last,
      lastWasNumber: true,
      lastLast: acc.lastLast, 
      negative: acc.negative,
      currentVal: `${acc.currentVal}${cur}`
    }
  ,
  {
    xIsNegative: false,
    negative: false,
    passedEqual : false,
    sum: 0,
    currentVal: '',
    last: null
  })
