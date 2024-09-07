public class TrieNode {
    public TrieNode[] children;
    public bool isEndOfWord;

    public TrieNode() {
        children = new TrieNode[26]; // For each letter 'a' to 'z'
        isEndOfWord = false;
    }
}

public class WordDictionary {
    private TrieNode root;

    /** Initializes the data structure. */
    public WordDictionary() {
        root = new TrieNode(); // Root of the trie
    }

    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        TrieNode node = root;
        foreach (char c in word) {
            int index = c - 'a'; // Calculate the index for the character
            if (node.children[index] == null) {
                node.children[index] = new TrieNode();
            }
            node = node.children[index]; // Move to the next node
        }
        node.isEndOfWord = true; // Mark the end of the word
    }

    /** Returns true if the word is in the data structure. */
    public bool Search(string word) {
        return SearchInNode(word, 0, root);
    }

    private bool SearchInNode(string word, int index, TrieNode node) {
        if (node == null) return false; // No matching path in Trie
        if (index == word.Length) return node.isEndOfWord; // If reached the end of the word

        char c = word[index];
        if (c == '.') {
            // '.' can match any character, so we must check all possible children
            for (int i = 0; i < 26; i++) {
                if (node.children[i] != null && SearchInNode(word, index + 1, node.children[i])) {
                    return true;
                }
            }
            return false; // No match found for this path
        } else {
            // Normal case: match the exact character
            int charIndex = c - 'a';
            return SearchInNode(word, index + 1, node.children[charIndex]);
        }
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */