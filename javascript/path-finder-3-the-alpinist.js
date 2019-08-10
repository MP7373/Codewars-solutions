// https://www.codewars.com/kata/path-finder-number-3-the-alpinist
function pathFinder (area) {
  if (area === '0') {
    return 0
  }

  const grid = area.split('\n').map(s => [...s].map(s => +s))
  const leastStepsGrid = area.split('\n').map(s => [...s].map(s => 9999999))

  leastStepsGrid[0][0] = 0

  const pathsToTryHeap = new NextCordinateToTryHeap(leastStepsGrid)

  leastStepsGrid[1][0] = Math.abs(grid[0][0] - grid[1][0])
  pathsToTryHeap.add([1, 0])

  leastStepsGrid[0][1] = Math.abs(grid[0][0] - grid[0][1])
  pathsToTryHeap.add([0, 1])

  const tryGoingDirection = tryGoingDirectionFunctionMaker(grid, leastStepsGrid, pathsToTryHeap)

  while (pathsToTryHeap.length() > 0) {
    const [y, x] = pathsToTryHeap.get()

    if (y === leastStepsGrid.length - 1 && x === leastStepsGrid[0].length - 1) {
      return leastStepsGrid[y][x]
    }

    const compassDirections = ['South', 'East', 'North', 'West']
    compassDirections.forEach(direction => tryGoingDirection(direction, y, x))
  }

  return null
}

function tryGoingDirectionFunctionMaker (grid, leastStepsGrid, pathsToTryHeap) {
  const gridNorthToSouthLength = grid.length
  const gridWestToEastLength = grid[0].length

  const makeStepIfItImprovesPath = (y, x, nextY, nextX) => {
    if (
      nextY >= 0 &&
      nextY < gridNorthToSouthLength &&
      nextX >= 0 &&
      nextX < gridWestToEastLength
    ) {
      const stepCost = Math.abs(grid[y][x] - grid[nextY][nextX])
      const stepsAfterStep = leastStepsGrid[y][x] + stepCost

      if (stepsAfterStep < leastStepsGrid[nextY][nextX]) {
        leastStepsGrid[nextY][nextX] = stepsAfterStep
        pathsToTryHeap.add([nextY, nextX])
      }
    }
  }

  return (compassDirection, y, x) => {
    switch (compassDirection) {
      case 'South':
        makeStepIfItImprovesPath(y, x, y + 1, x)
        break
      case 'East':
        makeStepIfItImprovesPath(y, x, y, x + 1)
        break
      case 'North':
        makeStepIfItImprovesPath(y, x, y - 1, x)
        break
      case 'West':
        makeStepIfItImprovesPath(y, x, y, x - 1)
    }
  }
}

function NextCordinateToTryHeap (grid) {
  this.backingArray = []

  this.add = ([y, x]) => {
    this.backingArray.push([y, x])

    let index = this.backingArray.length - 1
    let parentIndex = getParentIndex(index)

    if (index > 0) {
      let [parentY, parentX] = this.backingArray[parentIndex]

      while (grid[y][x] < grid[parentY][parentX]) {
        const temp = this.backingArray[parentIndex]
        this.backingArray[parentIndex] = this.backingArray[index]
        this.backingArray[index] = temp

        if (parentIndex === 0) {
          break
        }

        index = parentIndex
        parentIndex = getParentIndex(index)

        parentY = this.backingArray[parentIndex][0]
        parentX = this.backingArray[parentIndex][1]
      }
    }
  }

  this.get = () => {
    if (this.backingArray.length === 0) {
      return null
    }

    if (this.backingArray.length === 1) {
      return this.backingArray.pop()
    }

    const value = this.backingArray[0]

    this.backingArray[0] = this.backingArray.pop()

    let index = 0
    let leftChildIndex = getLeftChildIndex(index)
    let rightChildIndex = getRightChildIndex(index)

    const [y, x] = this.backingArray[index]
    let gridValue = grid[y][x]

    if (leftChildIndex < this.backingArray.length) {
      let [leftChildY, leftChildX] = this.backingArray[leftChildIndex]
      let leftChildGridValue = grid[leftChildY][leftChildX]
      let largerThanLeftChild = gridValue >= leftChildGridValue

      let rightChildY
      let rightChildX
      let rightChildGridValue
      let largerThanRightChild

      if (rightChildIndex < this.backingArray.length) {
        [rightChildY, rightChildX] = this.backingArray[rightChildIndex]
        rightChildGridValue = grid[rightChildY][rightChildX]
        largerThanRightChild = gridValue >= rightChildGridValue
      }

      while (
        index >= 0 &&
        ((leftChildIndex < this.backingArray.length && largerThanLeftChild) ||
        (rightChildIndex < this.backingArray.length && largerThanRightChild))
      ) {
        const leftLessThanRight = rightChildIndex >= this.backingArray.length || leftChildGridValue <= rightChildGridValue
        const newIndex = leftLessThanRight ? leftChildIndex : rightChildIndex

        const temp = this.backingArray[index]
        this.backingArray[index] = this.backingArray[newIndex]
        this.backingArray[newIndex] = temp

        index = newIndex
        leftChildIndex = getLeftChildIndex(index)
        rightChildIndex = getRightChildIndex(index)

        const [y, x] = this.backingArray[index]
        gridValue = grid[y][x]

        if (leftChildIndex < this.backingArray.length) {
          [leftChildY, leftChildX] = this.backingArray[leftChildIndex]
          leftChildGridValue = grid[leftChildY][leftChildX]
          largerThanLeftChild = gridValue >= leftChildGridValue

          if (rightChildIndex < this.backingArray.length) {
            [rightChildY, rightChildX] = this.backingArray[rightChildIndex]
            rightChildGridValue = grid[rightChildY][rightChildX]
            largerThanRightChild = gridValue >= rightChildGridValue
          }
        }
      }
    }
    return value
  }

  this.peak = () => this.backingArray[0]

  this.length = () => this.backingArray.length
}

function getParentIndex (index) {
  return index % 2 === 0 ? index / 2 - 1 : (index + 1) / 2 - 1
}

function getLeftChildIndex (index) {
  return index * 2 + 1
}

function getRightChildIndex (index) {
  return index * 2 + 2
}
