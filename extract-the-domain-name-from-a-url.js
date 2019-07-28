//https://www.codewars.com/kata/514a024011ea4fb54200004b
const domainName = url => url.split('.').map(s => s.replace(/http[s]{0,1}:\/\//, '')).filter(s => !/www/.test(s))[0]
