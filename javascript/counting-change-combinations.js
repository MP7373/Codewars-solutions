//https://www.codewars.com/kata/541af676b589989aed0009e7
const countChange = (money, coins) => {
  coins.sort()
  const combinations = { combinations: 0 }
  countCombinations(money, coins, coins.length - 1, 0, combinations)
  return combinations.combinations
}

function countCombinations(money, coins, index, sum, combinations) {
  if (index === 0) {
    if (money - sum > 0 && (money - sum) % coins[index] === 0) {
      combinations.combinations++
    }
  } else {
    while (sum < money) {
      countCombinations(money, coins, index - 1, sum, combinations)
      sum += coins[index]
    }

    if (sum === money) {
      combinations.combinations++
    }
  }
}
