public class Solution {
    private static readonly Dictionary<char, string> digitToLetters = new Dictionary<char, string>() {
        { '2', "abc" },
        { '3', "def" },
        { '4', "ghi" },
        { '5', "jkl" },
        { '6', "mno" },
        { '7', "pqrs" },
        { '8', "tuv" },
        { '9', "wxyz" }
    };

    public IList<string> LetterCombinations(string digits) {
        IList<string> result = new List<string>();
        
        if (string.IsNullOrEmpty(digits)) {
            return result;
        }

        void Backtrack(int index, string currentCombination) {
            if (index == digits.Length) {
                result.Add(currentCombination);
                return;
            }

            string possibleLetters = digitToLetters[digits[index]];

            foreach (char letter in possibleLetters) {
                Backtrack(index + 1, currentCombination + letter);
            }
        }

        Backtrack(0, "");
        
        return result;
    }
}
