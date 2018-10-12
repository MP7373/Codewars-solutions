//https://www.codewars.com/kata/5bb5e174528b2908930005b5
const findLast = (n, m) => {
  const circle = [];
  for (let i = 1; i <= n; i++) {
    circle.push([i, 0]);
  }
  let circleIndex = 0;
  const incrementCircleIndex = i => i < n - 1 ? i + 1 : 0;
  const decrementCircleIndex = i => i > 0 ? i - 1 : n - 1;
  while (n > 1) {
    for (let i = 0; i < m; i++) {
      circle[circleIndex][1] += 1;
      circleIndex = incrementCircleIndex(circleIndex);
    }
    let fillRestIndex = circleIndex;
    circleIndex = decrementCircleIndex(circleIndex);
    for (let i = 0; i < n - m; i++) {
      circle[fillRestIndex][1] += 2;
      fillRestIndex = incrementCircleIndex(fillRestIndex);
    }
    if (circleIndex < n - 1) {
      circle[circleIndex + 1][1] += circle[circleIndex][1];
      circle.splice(circleIndex, 1);
    } else {
      circle[0][1] += circle[circleIndex][1];
      circle.splice(circleIndex, 1);
      circleIndex = 0;
    }
    n--;
  }
  return circle[0];
};
