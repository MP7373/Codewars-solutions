// IN PROGRESS

// function pathFinder (area) {
//   const grid = area.split('\n').map(s => [...s].map(s => +s))
//   const leastStepsGrid = area.split('\n').map(s => [...s].map(s => 9999999))

//   leastStepsGrid[0][0] = 0

//   const pathsToTryHeap = new NextCordinateToTryHeap(leastStepsGrid)
//   pathsToTryHeap.add([1, 0])
//   pathsToTryHeap.add([0, 1])
//   const tryGoingDirection = tryGoingDirectionFunctionMaker(grid, leastStepsGrid, pathsToTryHeap)

//   while (pathsToTryHeap.length() > 0) {
//     const [y, x] = pathsToTryHeap.get()

//     const compassDirections = ['South', 'East', 'North', 'West']
//     compassDirections.forEach(direction => tryGoingDirection(direction, y, x))
//   }

//   return leastStepsGrid[leastStepsGrid.length - 1][leastStepsGrid[0].length - 1]
// }

// function tryGoingDirectionFunctionMaker (grid, leastStepsGrid, pathsToTryHeap) {
//   const gridNorthToSouthLength = grid.length
//   const gridWestToEastLength = grid[0].length

//   const makeStepIfItImprovesPath = (y, x, nextY, nextX) => {
//     if (
//       nextY >= 0 &&
//           nextY < gridNorthToSouthLength &&
//           nextX >= 0 &&
//           nextX < gridWestToEastLength
//     ) {
//       const stepCost = Math.abs(grid[y][x] - grid[nextY][nextX])
//       const stepsAfterStep = leastStepsGrid[y][x] + stepCost

//       if (stepsAfterStep < leastStepsGrid[nextY][nextX]) {
//         leastStepsGrid[nextY][nextX] = stepsAfterStep
//         pathsToTryHeap.add([nextY, nextX])
//       }
//     }
//   }

//   return (compassDirection, y, x) => {
//     switch (compassDirection) {
//       case 'South':
//         makeStepIfItImprovesPath(y, x, y + 1, x)
//         break
//       case 'East':
//         makeStepIfItImprovesPath(y, x, y, x + 1)
//         break
//       case 'North':
//         makeStepIfItImprovesPath(y, x, y - 1, x)
//         break
//       case 'West':
//         makeStepIfItImprovesPath(y, x, y, x - 1)
//     }
//   }
// }

const area = `923
458
762`
const grid = area.split('\n').map(s => [...s].map(s => +s))
// const leastStepsGrid = area.split('\n').map(s => [...s].map(s => 9999999))

const heap = new NextCordinateToTryHeap(grid)
console.log(heap)

for (let y = 0; y < grid.length; y++) {
  for (let x = 0; x < grid[0].length; x++) {
    heap.add([y, x])
  }
}

while (heap.length() > 0) {
  const cordinates = heap.get()
  const [y, x] = cordinates
  console.log(`${cordinates} value: ${grid[y][x]}`)
}

function NextCordinateToTryHeap (grid) {
  const backingArray = []

  // TODO: debug this
  this.add = yAndX => {
    backingArray.push(yAndX)
    console.log(backingArray)

    let index = backingArray.length - 1
    let nextIndex = index % 2 === 0 ? index / 2 - 1 : (index + 1) / 2 - 1
    let [y, x] = yAndX
    if (index > 0) {
      // let [nextY, nextX] = backingArray[nextIndex]
      let nextY = backingArray[nextIndex][0]
      let nextX = backingArray[nextIndex][1]
      while (grid[y][x] < grid[nextY][nextX]) {
        const temp = backingArray[nextIndex]
        backingArray[nextIndex] = backingArray[index]
        backingArray[index] = temp

        index = nextIndex
        nextIndex = index % 2 === 0 ? index / 2 - 1 : (index + 1) / 2 - 1
        if (index === 0) {
          break
        }
        [nextY, nextX] = backingArray[nextIndex]
      }
    }
    console.log(backingArray)
  }

  this.get = () => {
    if (backingArray.length === 1) {
      return backingArray.pop()
    }

    const value = backingArray[0]

    backingArray[0] = backingArray.pop()
    let index = 0

    let gridValue = grid[backingArray[index][0]][backingArray[index][1]]
    let leftChildGridValue = grid[backingArray[index * 2 + 1][0]][backingArray[index * 2 + 1][1]]
    let rightChildGridValue = grid[backingArray[index * 2 + 2][0]][backingArray[index * 2 + 2][1]]

    let largerThanLeftChild = gridValue >= leftChildGridValue
    let largerThanRightChild = gridValue >= rightChildGridValue
    while (
      index >= 0 &&
      index < backingArray.length &&
        !(largerThanLeftChild && largerThanRightChild)
    ) {
      const leftGreaterThanRight = leftChildGridValue > rightChildGridValue
      const newIndex = index * 2 + (leftGreaterThanRight ? 1 : 2)

      const temp = backingArray[index]
      backingArray[index] = backingArray[newIndex]
      backingArray[newIndex] = temp

      index = newIndex

      gridValue = grid[backingArray[index][0]][backingArray[index][1]]
      leftChildGridValue = grid[backingArray[index * 2 + 1][0]][backingArray[index * 2 + 1][1]]
      rightChildGridValue = grid[backingArray[index * 2 + 2][0]][backingArray[index * 2 + 2][1]]
      largerThanLeftChild = gridValue >= leftChildGridValue
      largerThanRightChild = gridValue >= rightChildGridValue
    }

    return value
  }

  this.peak = () => backingArray[0]

  this.length = () => backingArray.length
}
