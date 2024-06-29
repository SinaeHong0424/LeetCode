public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        List<int> result = new List<int>();
        if (matrix == null || matrix.Length == 0) {
            return result;
        }
        
        int top = 0, bottom = matrix.Length - 1;
        int left = 0, right = matrix[0].Length - 1;
        
        while (top <= bottom && left <= right) {
            // Traverse from left to right along the top row
            for (int i = left; i <= right; i++) {
                result.Add(matrix[top][i]);
            }
            top++;
            
            // Traverse from top to bottom along the right column
            for (int i = top; i <= bottom; i++) {
                result.Add(matrix[i][right]);
            }
            right--;
            
            // Traverse from right to left along the bottom row, if still within bounds
            if (top <= bottom) {
                for (int i = right; i >= left; i--) {
                    result.Add(matrix[bottom][i]);
                }
                bottom--;
            }
            
            // Traverse from bottom to top along the left column, if still within bounds
            if (left <= right) {
                for (int i = bottom; i >= top; i--) {
                    result.Add(matrix[i][left]);
                }
                left++;
            }
        }
        
        return result;
    }
}
