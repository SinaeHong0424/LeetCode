public class Solution {
    public void GameOfLife(int[][] board) {
        int m = board.Length;
        int n = board[0].Length;
        
        // Directions array for the 8 neighbors (horizontal, vertical, diagonal)
        int[][] directions = new int[][] {
            new int[] {-1, -1}, new int[] {-1, 0}, new int[] {-1, 1},
            new int[] {0, -1},                new int[] {0, 1},
            new int[] {1, -1}, new int[] {1, 0}, new int[] {1, 1}
        };
        
        // Make a copy of the original board to reference the original states
        int[][] copyBoard = new int[m][];
        for (int i = 0; i < m; i++) {
            copyBoard[i] = new int[n];
            for (int j = 0; j < n; j++) {
                copyBoard[i][j] = board[i][j];
            }
        }
        
        for (int row = 0; row < m; row++) {
            for (int col = 0; col < n; col++) {
                int liveNeighbors = 0;
                
                // Check all 8 neighbors
                foreach (var direction in directions) {
                    int r = row + direction[0];
                    int c = col + direction[1];
                    
                    // Check the validity of the neighboring cell and whether it was originally a live cell
                    if (r >= 0 && r < m && c >= 0 && c < n && copyBoard[r][c] == 1) {
                        liveNeighbors++;
                    }
                }
                
                // Apply the Game of Life rules
                if (copyBoard[row][col] == 1 && (liveNeighbors < 2 || liveNeighbors > 3)) {
                    board[row][col] = 0; // Rule 1 or Rule 3
                }
                if (copyBoard[row][col] == 0 && liveNeighbors == 3) {
                    board[row][col] = 1; // Rule 4
                }
                // Rule 2 does not need to change anything, as the cell remains the same.
            }
        }
    }
}
