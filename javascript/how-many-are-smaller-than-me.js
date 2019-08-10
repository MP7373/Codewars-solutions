//https://www.codewars.com/kata/how-many-are-smaller-than-me/
function smaller(arr) {
  let newArr = [];
  for (let i = 0; i < arr.length; i++) {
    let smallerThanCurrent = 0;
    for (let j = i; j < arr.length; j++)
      if (arr[i] > arr[j])
        smallerThanCurrent++;
    newArr.push(smallerThanCurrent);
  }
  return newArr;
}
