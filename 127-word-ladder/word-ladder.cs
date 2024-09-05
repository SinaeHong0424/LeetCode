public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> wordSet = new HashSet<string>(wordList);
        
        if (!wordSet.Contains(endWord)) {
            return 0;
        }
        
        Queue<(string word, int steps)> queue = new Queue<(string, int)>();
        queue.Enqueue((beginWord, 1));
        
        while (queue.Count > 0) {
            var (currentWord, steps) = queue.Dequeue();
            
            for (int i = 0; i < currentWord.Length; i++) {
                char[] wordChars = currentWord.ToCharArray();
                
                for (char c = 'a'; c <= 'z'; c++) {
                    wordChars[i] = c;
                    string newWord = new string(wordChars);
                    
                    if (newWord == endWord) {
                        return steps + 1;
                    }
                    
                    if (wordSet.Contains(newWord)) {
                        queue.Enqueue((newWord, steps + 1));
                        wordSet.Remove(newWord); 
                    }
                }
            }
        }
        
        return 0;
    }
}
