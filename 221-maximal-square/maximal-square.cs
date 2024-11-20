public class Solution {
    public int MaximalSquare(char[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) return 0;

        int m = matrix.Length;
        int n = matrix[0].Length;
        int maxSide = 0;
        
        int[,] dp = new int[m, n];
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (matrix[i][j] == '1') {
                    if (i == 0 || j == 0) {
                        dp[i, j] = 1;
                    } else {
                        dp[i, j] = Math.Min(Math.Min(dp[i-1, j], dp[i, j-1]), dp[i-1, j-1]) + 1;
                    }
                    maxSide = Math.Max(maxSide, dp[i, j]);
                }
            }
        }
        
        return maxSide * maxSide;
    }
}
