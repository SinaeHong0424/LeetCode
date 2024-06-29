public class Solution {
    public bool IsValidSudoku(char[][] board) {
        // Initialize hash sets for rows, columns, and sub-boxes
        HashSet<char>[] rows = new HashSet<char>[9];
        HashSet<char>[] cols = new HashSet<char>[9];
        HashSet<char>[] boxes = new HashSet<char>[9];
        
        for (int i = 0; i < 9; i++) {
            rows[i] = new HashSet<char>();
            cols[i] = new HashSet<char>();
            boxes[i] = new HashSet<char>();
        }
        
        // Traverse the board
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                char current = board[i][j];
                
                // If the cell is empty, continue
                if (current == '.') {
                    continue;
                }
                
                // Check the row
                if (rows[i].Contains(current)) {
                    return false;
                } else {
                    rows[i].Add(current);
                }
                
                // Check the column
                if (cols[j].Contains(current)) {
                    return false;
                } else {
                    cols[j].Add(current);
                }
                
                // Check the 3x3 sub-box
                int boxIndex = (i / 3) * 3 + (j / 3);
                if (boxes[boxIndex].Contains(current)) {
                    return false;
                } else {
                    boxes[boxIndex].Add(current);
                }
            }
        }
        
        return true;
    }
}
