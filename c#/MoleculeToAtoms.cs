//https://www.codewars.com/kata/molecule-to-atoms
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Kata
{
  public static Dictionary<string, int> ParseMolecule(string formula)
  {
    int after;
    return EvaluateAndAddAtomsToDictionary(0, formula, '$', out after);
  }
  
  public static Dictionary<string, int> EvaluateAndAddAtomsToDictionary(
    int index,
    string formula,
    char endingBracket,
    out int indexAfter)
  {
    var atoms = new Dictionary<string, int>();
    var currentAtomLength = 0;
    var atom = "";
    while (index < formula.Length)
    {
      if (formula[index] == '(' ||
        formula[index] == '[' ||
        formula[index] == '{')
      {
        if (currentAtomLength > 0)
        {
          if (atoms.ContainsKey(atom))
          {
            atoms[atom] += 1;
          }
          else
          {
            atoms.Add(atom, 1);
          }

          atom = "";
          currentAtomLength = 0;
        }
        
        var endBracket = formula[index] == '(' ? ')' : formula[index] == '[' ? ']' : '}';
        
        int afterIndex;
        var innerDictionary = EvaluateAndAddAtomsToDictionary(index + 1, formula, endBracket, out afterIndex);
        index = afterIndex;
        
        if (index < formula.Length && IsNumeric(formula[index]))
        {
          var multiplierString = "";
          while (index < formula.Length && IsNumeric(formula[index]))
          {
            multiplierString += $"{formula[index]}";
            index++;
          }
          
          var multiplier = Convert.ToInt32(multiplierString);
          
          var copy = new Dictionary<string, int>(innerDictionary);
          foreach (var key in copy.Keys)
          {
            innerDictionary[key] *= multiplier;
          }
        }
        
        foreach (var entry in innerDictionary)
        {
          if (atoms.ContainsKey(entry.Key))
          {
            atoms[entry.Key] += innerDictionary[entry.Key];
          }
          else
          {
            atoms.Add(entry.Key, innerDictionary[entry.Key]);
          }
        }
        
        currentAtomLength = 0;
        
        if (index >= formula.Length)
        {
          break;
        }
      }
      else if (IsUppercaseLetter(formula[index]))
      {
        if (currentAtomLength == 0)
        {
          atom += $"{formula[index]}";
          currentAtomLength++;
        }
        else
        {
          if (atoms.ContainsKey(atom))
          {
            atoms[atom] += 1;
          }
          else
          {
            atoms.Add(atom, 1);
          }

          atom = $"{formula[index]}";
          currentAtomLength = 1;
        }
        
        index++;
      }
      else if (IsLowercaseLetter(formula[index]))
      {
        atom += $"{formula[index]}";
        currentAtomLength++;
        index++;
      }
      else if (IsNumeric(formula[index]))
      {
        var multiplierString = "";
        while (index < formula.Length && IsNumeric(formula[index]))
        {
          multiplierString += $"{formula[index]}";
          index++;
        }
        
        var multiplier = Convert.ToInt32(multiplierString);
        
        if (atoms.ContainsKey(atom))
        {
          atoms[atom] += multiplier;
        }
        else
        {
          atoms.Add(atom, multiplier);
        }
        currentAtomLength = 0;
        atom = "";
        
        if (index >= formula.Length)
        {
          break;
        }
        
      }
      else if (formula[index] == endingBracket)
      {
        if (currentAtomLength > 0)
        {
          if (atoms.ContainsKey(atom))
          {
            atoms[atom] += 1;
          }
          else
          {
            atoms.Add(atom, 1);
          }
        }
        
        indexAfter = index + 1;
        return atoms;
      }
    }
    
    if (currentAtomLength > 0)
    {
      if (atoms.ContainsKey(atom))
      {
        atoms[atom] += 1;
      }
      else
      {
        atoms.Add(atom, 1);
      }
    }
    
    indexAfter = index;
    return atoms;
  }
  
  private static bool IsNumeric(char c) =>
    Array.Exists(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }, ch => ch == c);
    
  private static bool IsUppercaseLetter(char c) => c > '@' && c < '[';
  
  private static bool IsLowercaseLetter(char c) => c > '`' && c < '{';
}
