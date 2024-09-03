public class Solution {
    public int SnakesAndLadders(int[][] board) {
        int n = board.Length;
        bool[] visited = new bool[n * n + 1];
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        visited[1] = true;
        int moves = 0;

        while (queue.Count > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                int curr = queue.Dequeue();
                if (curr == n * n) {
                    return moves; 
                }
                for (int next = curr + 1; next <= Math.Min(curr + 6, n * n); next++) {
                    int destination = GetBoardValue(board, next);
                    if (!visited[destination]) {
                        visited[destination] = true;
                        queue.Enqueue(destination);
                    }
                }
            }
            moves++;
        }

        return -1; 
    }

    private int GetBoardValue(int[][] board, int num) {
        int n = board.Length;
        int row = (num - 1) / n;
        int col = (num - 1) % n;

        if (row % 2 == 0) {
            col = col;
        } else {
            col = n - 1 - col;
        }

        int actualRow = n - 1 - row;
        if (board[actualRow][col] != -1) {
            return board[actualRow][col];
        }
        return num;
    }
}
