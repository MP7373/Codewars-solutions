//https://www.codewars.com/kata/59094c5d579da9aceb000037
function increasingNumber(x, n) {
    for (let i = 1; i <= n; i++) {
        while (x % i !== 0) x++
    }
    return x
}
