using System.Collections.Generic;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; private set; }
    public bool IsEndOfWord { get; set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}

public class Trie
{
    private readonly TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }
    
    public void Insert(string word)
    {
        TrieNode current = root;
        foreach (var ch in word)
        {
            if (!current.Children.ContainsKey(ch))
            {
                current.Children[ch] = new TrieNode();
            }
            current = current.Children[ch];
        }
        current.IsEndOfWord = true;
    }
    
    public bool Search(string word)
    {
        TrieNode current = root;
        foreach (var ch in word)
        {
            if (!current.Children.ContainsKey(ch))
            {
                return false;
            }
            current = current.Children[ch];
        }
        return current.IsEndOfWord;
    }
    
    public bool StartsWith(string prefix)
    {
        TrieNode current = root;
        foreach (var ch in prefix)
        {
            if (!current.Children.ContainsKey(ch))
            {
                return false;
            }
            current = current.Children[ch];
        }
        return true;
    }
}

// Usage example:
// Trie trie = new Trie();
// trie.Insert("apple");
// Console.WriteLine(trie.Search("apple"));   // Output: True
// Console.WriteLine(trie.Search("app"));     // Output: False
// Console.WriteLine(trie.StartsWith("app")); // Output: True
// trie.Insert("app");
// Console.WriteLine(trie.Search("app"));     // Output: True
