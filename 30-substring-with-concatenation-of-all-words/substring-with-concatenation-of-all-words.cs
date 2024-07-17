public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        IList<int> result = new List<int>();
        if (words == null || words.Length == 0 || s.Length == 0) return result;

        int wordLength = words[0].Length;
        int numWords = words.Length;
        int totalLength = wordLength * numWords;

        // Create a frequency map of the words
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (var word in words) {
            if (wordCount.ContainsKey(word)) {
                wordCount[word]++;
            } else {
                wordCount[word] = 1;
            }
        }

        // Slide over each possible starting point within the word length range
        for (int i = 0; i < wordLength; i++) {
            int left = i, right = i, count = 0;
            Dictionary<string, int> seenWords = new Dictionary<string, int>();

            while (right + wordLength <= s.Length) {
                string word = s.Substring(right, wordLength);
                right += wordLength;
                if (wordCount.ContainsKey(word)) {
                    if (seenWords.ContainsKey(word)) {
                        seenWords[word]++;
                    } else {
                        seenWords[word] = 1;
                    }
                    count++;

                    while (seenWords[word] > wordCount[word]) {
                        string leftWord = s.Substring(left, wordLength);
                        seenWords[leftWord]--;
                        left += wordLength;
                        count--;
                    }

                    if (count == numWords) {
                        result.Add(left);
                    }
                } else {
                    seenWords.Clear();
                    count = 0;
                    left = right;
                }
            }
        }

        return result;
    }
}
