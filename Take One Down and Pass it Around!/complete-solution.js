let numberOfBeers = 99;
const takeOneDownAndPassItAround = function(numberOfPeopleNearYou) {
  if (numberOfPeopleNearYou < 2) {
    return 'Not enough people to pass it around, find more people.';
  }
  
  if (numberOfBeers < 1) {
    return 'Find another wall.';
  }
  return --numberOfBeers;
};
