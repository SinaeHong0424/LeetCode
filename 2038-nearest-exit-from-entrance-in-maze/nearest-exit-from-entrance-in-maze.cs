public class Solution {
    public int NearestExit(char[][] maze, int[] entrance) {
        int m = maze.Length, n = maze[0].Length;
        var visited = new bool[m, n];
        var queue = new Queue<(int row, int col, int steps)>();
        int[] dr = {0, 1, 0, -1}; 
        int[] dc = {1, 0, -1, 0}; 
        queue.Enqueue((entrance[0], entrance[1], 0));
        visited[entrance[0], entrance[1]] = true;

        while (queue.Count > 0) {
            var (row, col, steps) = queue.Dequeue();

            if ((row != entrance[0] || col != entrance[1]) && (row == 0 || row == m - 1 || col == 0 || col == n - 1)) {
                return steps; 
            }

            for (int i = 0; i < 4; i++) { 
                int newRow = row + dr[i];
                int newCol = col + dc[i];

                if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n && !visited[newRow, newCol] && maze[newRow][newCol] == '.') {
                    visited[newRow, newCol] = true;
                    queue.Enqueue((newRow, newCol, steps + 1));
                }
            }
        }

        return -1; 
    }
}
