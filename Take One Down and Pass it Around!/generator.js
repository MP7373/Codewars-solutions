const countDown = (() => {
  const generator = (function*() {
    for (let i = 5; i > 0; i--) {
      yield i;
    }
    return 'you drank the last one!';
  })();
  return n => {
    if (n > 1) {
      let iteration = generator.next();
      return iteration.value ? iteration.value : 'none left';
    }
    return 'get more people';
  };
})();
