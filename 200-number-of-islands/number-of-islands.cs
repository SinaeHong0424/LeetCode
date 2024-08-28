public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0) {
            return 0;
        }

        int numIslands = 0;
        int m = grid.Length;
        int n = grid[0].Length;

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '1') {
                    numIslands++;
                    DFS(grid, i, j, m, n);
                }
            }
        }

        return numIslands;
    }

    private void DFS(char[][] grid, int i, int j, int m, int n) {
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == '0') {
            return;
        }

        grid[i][j] = '0'; // Mark this cell as visited by setting it to '0'

        // Explore all four possible directions (up, down, left, right)
        DFS(grid, i + 1, j, m, n); // Down
        DFS(grid, i - 1, j, m, n); // Up
        DFS(grid, i, j + 1, m, n); // Right
        DFS(grid, i, j - 1, m, n); // Left
    }
}
