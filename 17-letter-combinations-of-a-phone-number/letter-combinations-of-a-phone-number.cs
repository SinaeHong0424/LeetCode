public class Solution {
    private Dictionary<char, string> digitToLetters = new Dictionary<char, string>()
    {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };

    public IList<string> LetterCombinations(string digits) {
        IList<string> result = new List<string>();
        if (string.IsNullOrEmpty(digits))
            return result;

        Backtrack(digits, 0, new StringBuilder(), result);
        return result;
    }

    private void Backtrack(string digits, int index, StringBuilder combination, IList<string> result) {
        if (index == digits.Length) {
            result.Add(combination.ToString());
            return;
        }

        string letters = digitToLetters[digits[index]];
        for (int i = 0; i < letters.Length; i++) {
            combination.Append(letters[i]);
            Backtrack(digits, index + 1, combination, result);
            combination.Remove(combination.Length - 1, 1);
        }
    }
}