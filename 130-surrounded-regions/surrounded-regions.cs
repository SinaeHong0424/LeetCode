public class Solution {
    public void Solve(char[][] board) {
        if (board == null || board.Length == 0) return;

        int m = board.Length;
        int n = board[0].Length;

        // Step 1: Mark the 'O's connected to the border
        for (int i = 0; i < m; i++) {
            DFS(board, i, 0); // Left border
            DFS(board, i, n - 1); // Right border
        }

        for (int j = 0; j < n; j++) {
            DFS(board, 0, j); // Top border
            DFS(board, m - 1, j); // Bottom border
        }

        // Step 2: Replace all 'O' with 'X', and all '#' back to 'O'
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (board[i][j] == 'O') {
                    board[i][j] = 'X';
                } else if (board[i][j] == '#') {
                    board[i][j] = 'O';
                }
            }
        }
    }

    private void DFS(char[][] board, int i, int j) {
        int m = board.Length;
        int n = board[0].Length;

        if (i < 0 || i >= m || j < 0 || j >= n || board[i][j] != 'O') {
            return;
        }

        // Mark the cell as part of the safe region
        board[i][j] = '#';

        // Explore the four directions
        DFS(board, i - 1, j); // Up
        DFS(board, i + 1, j); // Down
        DFS(board, i, j - 1); // Left
        DFS(board, i, j + 1); // Right
    }
}
