public class Solution {
    private class TrieNode {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public string Word = null;  
    }
    
    public IList<string> FindWords(char[][] board, string[] words) {
        List<string> result = new List<string>();

        TrieNode root = BuildTrie(words);

        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[0].Length; j++) {
                if (root.Children.ContainsKey(board[i][j])) {
                    Backtrack(i, j, root, board, result);
                }
            }
        }

        return result;
    }
    
    private TrieNode BuildTrie(string[] words) {
        TrieNode root = new TrieNode();
        foreach (string word in words) {
            TrieNode node = root;
            foreach (char c in word) {
                if (!node.Children.ContainsKey(c)) {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.Word = word;  
        }
        return root;
    }

    private void Backtrack(int row, int col, TrieNode parent, char[][] board, List<string> result) {
        char letter = board[row][col];
        TrieNode currNode = parent.Children[letter];

        if (currNode.Word != null) {
            result.Add(currNode.Word);
            currNode.Word = null;  
        }

        board[row][col] = '#';

        int[][] directions = new int[][] {
            new int[] { 0, 1 },    
            new int[] { 1, 0 },    
            new int[] { 0, -1 },   
            new int[] { -1, 0 }    
        };

        foreach (int[] direction in directions) {
            int newRow = row + direction[0];
            int newCol = col + direction[1];
            if (newRow >= 0 && newRow < board.Length && newCol >= 0 && newCol < board[0].Length) {
                if (currNode.Children.ContainsKey(board[newRow][newCol])) {
                    Backtrack(newRow, newCol, currNode, board, result);
                }
            }
        }

        board[row][col] = letter;

        if (currNode.Children.Count == 0) {
            parent.Children.Remove(letter);
        }
    }
}
