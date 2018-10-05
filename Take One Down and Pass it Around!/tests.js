const findAnotherWall = 'Find another wall.';

const findMorePeople =
'Not enough people to pass it around, find more people.';

for (let i = 98; i >= 0; i--) {
  Test.expect(takeOneDownAndPassItAround(2) === i,
  'Not the correct number of beer on the wall.');
}

Test.expect(
  takeOneDownAndPassItAround(2) === findAnotherWall,
  `Should return ${findAnotherWall}`
);

Test.expect(
  takeOneDownAndPassItAround(2) === findAnotherWall,
  `Should return ${findAnotherWall}`
);
  
Test.expect(
  takeOneDownAndPassItAround(1) === findMorePeople,
  `Should return ${findMorePeople}`
);
