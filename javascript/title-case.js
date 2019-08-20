//https://www.codewars.com/kata/5202ef17a402dd033c000009
const titleCase = (title, minorWords) => title === '' ?
    '' :
    title.split(' ').map((word, i) => i == 0 ?
      word[0].toUpperCase() + word.slice(1).toLowerCase() :
      minorWords && minorWords.split(' ').map(word => word.toLowerCase()).includes(word.toLowerCase()) ?
        word.toLowerCase() :
        word[0].toUpperCase() + word.slice(1).toLowerCase())
    .join(' ')
