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

debugPrintHeap(heap)

console.log(heap.get())

debugPrintHeap(heap)

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

  // TODO: debug this
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

    let gridValue = grid[this.backingArray[index][0]][this.backingArray[index][1]]
    let leftChildGridValue = grid[this.backingArray[index * 2 + 1][0]][this.backingArray[index * 2 + 1][1]]
    let rightChildGridValue = grid[this.backingArray[index * 2 + 2][0]][this.backingArray[index * 2 + 2][1]]

    let largerThanLeftChild = gridValue >= leftChildGridValue
    let largerThanRightChild = gridValue >= rightChildGridValue
    while (
      index >= 0 &&
      index < this.backingArray.length &&
        !(largerThanLeftChild || largerThanRightChild)
    ) {
      const leftGreaterThanRight = leftChildGridValue > rightChildGridValue
      const newIndex = index * 2 + (leftGreaterThanRight ? 1 : 2)

      const temp = this.backingArray[index]
      this.backingArray[index] = this.backingArray[newIndex]
      this.backingArray[newIndex] = temp

      index = newIndex

      gridValue = grid[this.backingArray[index][0]][this.backingArray[index][1]]
      leftChildGridValue = grid[this.backingArray[index * 2 + 1][0]][this.backingArray[index * 2 + 1][1]]
      rightChildGridValue = grid[this.backingArray[index * 2 + 2][0]][this.backingArray[index * 2 + 2][1]]
      largerThanLeftChild = gridValue >= leftChildGridValue
      largerThanRightChild = gridValue >= rightChildGridValue
    }

    return value
  }

  this.peak = () => this.backingArray[0]

  this.length = () => this.backingArray.length
}

function getParentIndex (index) {
  return index % 2 === 0 ? index / 2 - 1 : (index + 1) / 2 - 1
}

function debugPrintHeap (heap) {
  heap.backingArray.forEach(([y, x], index) => {
    console.log(`index: ${index}, parentIndex: ${getParentIndex(index)}, y: ${y} x: ${x}, value: ${grid[y][x]}`)
  })
}
