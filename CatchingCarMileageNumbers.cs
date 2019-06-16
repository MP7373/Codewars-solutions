//https://www.codewars.com/kata/52c4dd683bfd3b434c000292
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

public static class Kata
{
  public static int IsInteresting(int number, List<int> awesomePhrases)
  {
    if (IsInterestingNumber(number, awesomePhrases)) return 2;
    if (IsInterestingNumber(number + 1, awesomePhrases)
      || IsInterestingNumber(number + 2, awesomePhrases)) return 1;
    return 0;
  }
  
  public static bool IsInterestingNumber(int number, List<int> awesomePhrases) =>
    IsFollowedByAllZeros(number) ||
    EveryDigitIsSame(number) ||
    DigitsAreIncrementing(number) ||
    DigitsAreDecrementing(number) ||
    IsPalindrome(number) ||
    MatchesAwesomePhrase(number, awesomePhrases);
  
  public static bool IsThreeOrMoreDigitNumber(int number) => number > 99 && number < 1000000000;
  
  public static bool IsFollowedByAllZeros(int number)
  {
    if (!IsThreeOrMoreDigitNumber(number)) return false;
    var numberAsChars = number.ToString().ToCharArray();
    for (var i = 1; i < numberAsChars.Length; i++)
      if (numberAsChars[i] != '0') return false;
    return true;
  }
  
  public static bool EveryDigitIsSame(int number)
  {
    if (!IsThreeOrMoreDigitNumber(number)) return false;
    var numberAsChars = number.ToString().ToCharArray();
    for (var i = 1; i < numberAsChars.Length; i++)
      if (numberAsChars[i] != numberAsChars[0]) return false;
    return true;
  }
  
  public static bool DigitsAreIncrementing(int number)
  {
    if (!IsThreeOrMoreDigitNumber(number)) return false;
    var lastDigit = number % 10;
    while (number / 10 >= 1)
    {
      number /= 10;
      var currentDigit = number % 10;
      if (currentDigit + 1 != lastDigit && !(lastDigit == 0 && currentDigit == 9)
        || lastDigit == 1 && currentDigit == 0)
        return false;
      lastDigit = currentDigit;
    }
    return true;
  }
  
  public static bool DigitsAreDecrementing(int number)
  {
    if (!IsThreeOrMoreDigitNumber(number)) return false;
    var lastDigit = number % 10;
    while (number / 10 >= 1)
    {
      number /= 10;
      var currentDigit = number % 10;
      if (currentDigit - 1 != lastDigit)
        return false;
      lastDigit = currentDigit;
    }
    return true;
  }
  
  public static bool IsPalindrome(int number)
  {
    if (!IsThreeOrMoreDigitNumber(number)) return false;
    var numberAsChars = number.ToString().ToCharArray();
    for (var i = 0; i < numberAsChars.Length / 2; i++)
      if (numberAsChars[i] != numberAsChars[numberAsChars.Length - 1 - i]) return false;
    return true;
  }
  
  public static bool MatchesAwesomePhrase(int number, List<int> awesomePhrases)
  {
    if (!IsThreeOrMoreDigitNumber(number)) return false;
    var result = awesomePhrases.Contains(number);
    return result;
  }
}

//test cases I used
[TestFixture]
public class Test
{
  [Test]
  public void ShouldWorkTest()
  {
    Assert.AreEqual(0, Kata.IsInteresting(3, new List<int>() { 1337, 256 }));
    Assert.AreEqual(1, Kata.IsInteresting(1336, new List<int>() { 1337, 256 }));
    Assert.AreEqual(2, Kata.IsInteresting(1337, new List<int>() { 1337, 256 }));
    Assert.AreEqual(0, Kata.IsInteresting(11208, new List<int>() { 1337, 256 }));
    //Assert.AreEqual(1, Kata.IsInteresting(11209, new List<int>() { 1337, 256 }));
    Assert.AreEqual(2, Kata.IsInteresting(11211, new List<int>() { 1337, 256 }));
  }

  [Test]
  public void IsInterestingNumberTests()
  {
    Assert.AreEqual(true, Kata.IsInterestingNumber(1337, new List<int>() { 1337, 256 }));
    Assert.AreEqual(true, Kata.IsInterestingNumber(11211, new List<int>() { 1337, 256 }));
    Assert.AreEqual(false, Kata.IsInterestingNumber(11209, new List<int>() { 1337, 256 }));
    Assert.AreEqual(false, Kata.IsInterestingNumber(11208, new List<int>() { 1337, 256 }));
  }
  
  [Test]
  public void IsThreeOrMoreDigitNumberTests()
  {
    Assert.AreEqual(true, Kata.IsThreeOrMoreDigitNumber(100));
    Assert.AreEqual(true, Kata.IsThreeOrMoreDigitNumber(5678));
    Assert.AreEqual(true, Kata.IsThreeOrMoreDigitNumber(999999999));
    Assert.AreEqual(false, Kata.IsThreeOrMoreDigitNumber(1000000000));
    Assert.AreEqual(false, Kata.IsThreeOrMoreDigitNumber(99));
    Assert.AreEqual(false, Kata.IsThreeOrMoreDigitNumber(2000111222));
    Assert.AreEqual(false, Kata.IsThreeOrMoreDigitNumber(1));
  }
  
  [Test]
  public void IsFollowedByAllZerosTests()
  {
    Assert.AreEqual(true, Kata.IsFollowedByAllZeros(100));
    Assert.AreEqual(true, Kata.IsFollowedByAllZeros(5000));
    Assert.AreEqual(true, Kata.IsFollowedByAllZeros(6000000));
    Assert.AreEqual(false, Kata.IsFollowedByAllZeros(1));
    Assert.AreEqual(false, Kata.IsFollowedByAllZeros(70));
    Assert.AreEqual(false, Kata.IsFollowedByAllZeros(10005));
    Assert.AreEqual(false, Kata.IsFollowedByAllZeros(543098));
  }
  
  [Test]
  public void EveryDigitIsSameTests()
  {
    Assert.AreEqual(true, Kata.EveryDigitIsSame(666));
    Assert.AreEqual(true, Kata.EveryDigitIsSame(9999999));
    Assert.AreEqual(false, Kata.EveryDigitIsSame(1));
    Assert.AreEqual(false, Kata.EveryDigitIsSame(12));
    Assert.AreEqual(false, Kata.EveryDigitIsSame(54309));
  }
  
  [Test]
  public void DigitsAreIncrementingTests()
  {
    Assert.AreEqual(true, Kata.DigitsAreIncrementing(123));
    Assert.AreEqual(true, Kata.DigitsAreIncrementing(890));
    Assert.AreEqual(true, Kata.DigitsAreIncrementing(1234));
    Assert.AreEqual(false, Kata.DigitsAreIncrementing(2));
    Assert.AreEqual(false, Kata.DigitsAreIncrementing(134));
    Assert.AreEqual(false, Kata.DigitsAreIncrementing(390));
    Assert.AreEqual(false, Kata.DigitsAreIncrementing(90123));
  }
  
  [Test]
  public void DigitsAreDecrementingTests()
  {
    Assert.AreEqual(true, Kata.DigitsAreDecrementing(321));
    Assert.AreEqual(true, Kata.DigitsAreDecrementing(3210));
    Assert.AreEqual(true, Kata.DigitsAreDecrementing(987654));
    Assert.AreEqual(false, Kata.DigitsAreDecrementing(2));
    Assert.AreEqual(false, Kata.DigitsAreDecrementing(9865));
    Assert.AreEqual(false, Kata.DigitsAreDecrementing(652));
    Assert.AreEqual(false, Kata.DigitsAreDecrementing(109));
  }
  
  [Test]
  public void IsPalindromeTests()
  {
    Assert.AreEqual(true, Kata.IsPalindrome(1221));
    Assert.AreEqual(true, Kata.IsPalindrome(73837));
    Assert.AreEqual(true, Kata.IsPalindrome(123454321));
    Assert.AreEqual(false, Kata.IsPalindrome(1));
    Assert.AreEqual(false, Kata.IsPalindrome(66));
    Assert.AreEqual(false, Kata.IsPalindrome(2121));
    Assert.AreEqual(false, Kata.IsPalindrome(104501));
  }
  
  [Test]
  public void MatchesAwesomePhraseTest()
  {
    Assert.AreEqual(true, Kata.MatchesAwesomePhrase(123, new List<int>() { 123, 456 }));
    Assert.AreEqual(true, Kata.MatchesAwesomePhrase(456, new List<int>() { 123, 456 }));
    Assert.AreEqual(false, Kata.MatchesAwesomePhrase(111, new List<int>() { 123, 456 }));
    Assert.AreEqual(false, Kata.MatchesAwesomePhrase(11, new List<int>() { 11, 456 }));
  }
}
