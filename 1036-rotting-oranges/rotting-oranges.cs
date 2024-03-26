public class Solution {
    public int OrangesRotting(int[][] grid) {
        if (grid == null || grid.Length == 0) return 0;

        int rows = grid.Length, cols = grid[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int freshOranges = 0;

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 2) {
                    queue.Enqueue((r, c));
                } else if (grid[r][c] == 1) {
                    freshOranges++;
                }
            }
        }

        int minutes = 0;
        int[][] directions = new int[][] { new int[] {1, 0}, new int[] {0, 1}, new int[] {-1, 0}, new int[] {0, -1} };

        while (queue.Count > 0 && freshOranges > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                var (r, c) = queue.Dequeue();
                foreach (var dir in directions) {
                    int newRow = r + dir[0], newCol = c + dir[1];
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1) {
                        grid[newRow][newCol] = 2;
                        queue.Enqueue((newRow, newCol));
                        freshOranges--;
                    }
                }
            }
            minutes++;
        }

        return freshOranges == 0 ? minutes : -1;
    }
}
