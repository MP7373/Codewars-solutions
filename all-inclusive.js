const containAllRots = (strng, arr) => {
  console.log(strng);
  console.log(arr);
  const str = strng.split('');
  const allRots = []
  for (let i = 0; i < str.length; i++) {
    let rot = '';
    let strIndex = i;
    for (let j = 0; j < str.length; j++) {
      rot += str[strIndex];
      strIndex < str.length - 1 ? strIndex++ : strIndex = 0;
    }
    if (!allRots.includes(rot)) {
      allRots.push(rot);
    }
  }
  allRots.sort();
  arr.sort();
  let allRotsIndex = 0;
  let arrIndex = 0;
  while (allRotsIndex < allRots.length && arrIndex < arr.length) {
    if (allRots[allRotsIndex] < arr[arrIndex]) {
      return false;
    } else if (arr[arrIndex] < allRots[allRotsIndex]) {
      allRotsIndex--;
    }
    allRotsIndex++;
    arrIndex++;
  }
  return allRotsIndex === allRots.length;
};