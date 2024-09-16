public class Solution {
    public bool Exist(char[][] board, string word) {
        int rows = board.Length;
        int cols = board[0].Length;

        bool Backtrack(int row, int col, int index) {
            if (index == word.Length) {
                return true;
            }

            if (row < 0 || row >= rows || col < 0 || col >= cols || board[row][col] != word[index]) {
                return false;
            }

            char temp = board[row][col];
            board[row][col] = '#'; 

            bool found = Backtrack(row + 1, col, index + 1) ||  
                         Backtrack(row - 1, col, index + 1) ||  
                         Backtrack(row, col + 1, index + 1) ||  
                         Backtrack(row, col - 1, index + 1);    

            board[row][col] = temp;

            return found;
        }

        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                if (Backtrack(row, col, 0)) {
                    return true;
                }
            }
        }

        return false;
    }
}
