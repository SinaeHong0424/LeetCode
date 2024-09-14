public class Solution {
    public int TotalNQueens(int n) {
        int count = 0;
        bool[] cols = new bool[n];             
        bool[] d1 = new bool[2 * n];            
        bool[] d2 = new bool[2 * n];             

        void Backtrack(int row) {
            if (row == n) {
                count++;
                return;
            }
            for (int col = 0; col < n; col++) {
                int id1 = col - row + n;         
                int id2 = col + row;             
                if (cols[col] || d1[id1] || d2[id2])
                    continue;

                cols[col] = true;
                d1[id1] = true;
                d2[id2] = true;

                Backtrack(row + 1);

                cols[col] = false;
                d1[id1] = false;
                d2[id2] = false;
            }
        }

        Backtrack(0);
        return count;
    }
}
