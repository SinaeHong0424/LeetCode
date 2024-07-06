public class Solution {
    public bool WordPattern(string pattern, string s) {
        // Split the string into words
        string[] words = s.Split(' ');

        // Check if the length of the pattern matches the number of words
        if (pattern.Length != words.Length) {
            return false;
        }

        // Dictionaries to keep track of mappings from pattern to words and words to pattern
        Dictionary<char, string> patternToWord = new Dictionary<char, string>();
        Dictionary<string, char> wordToPattern = new Dictionary<string, char>();

        for (int i = 0; i < pattern.Length; i++) {
            char p = pattern[i];
            string word = words[i];

            // Check if there is already a mapping from pattern to word
            if (patternToWord.ContainsKey(p)) {
                if (patternToWord[p] != word) {
                    return false; // Mismatch in mapping
                }
            } else {
                patternToWord[p] = word;
            }

            // Check if there is already a mapping from word to pattern
            if (wordToPattern.ContainsKey(word)) {
                if (wordToPattern[word] != p) {
                    return false; // Mismatch in mapping
                }
            } else {
                wordToPattern[word] = p;
            }
        }

        return true;
    }
}
