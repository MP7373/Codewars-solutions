const findAnotherWall = 'Find another wall.';

const findMorePeople =
'Not enough people to pass it around, find more people.';

Test.assertEquals(
  takeOneDownAndPassItAround(1),
  findMorePeople,
  'Test: Not enough people\n'
);

for (let i = 98; i >= 0; i--) {
  Test.assertEquals(
    takeOneDownAndPassItAround(2),
    i,
    `Test: ${i} bottles of beer on the wall\n`,
  );
}

Test.assertEquals(
  takeOneDownAndPassItAround(2),
  findAnotherWall,
  'Test: Bottles of beer doesn\'t go below 0\n'
);

Test.assertEquals(
  takeOneDownAndPassItAround(2),
  findAnotherWall,
  'Test: Bottles of beer doesn\'t go below 0 again\n'
);
  
Test.assertEquals(
  takeOneDownAndPassItAround(1),
  findMorePeople,
  'Test: Not enough people after no bottles left on wall\n'
);
