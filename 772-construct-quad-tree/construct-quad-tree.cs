/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

public class Solution {
    public Node Construct(int[][] grid) {
        return Construct(grid, 0, 0, grid.Length);
    }

    private Node Construct(int[][] grid, int row, int col, int size) {
        if (IsUniform(grid, row, col, size)) {
            return new Node(grid[row][col] == 1, true);
        }

        int newSize = size / 2;
        Node topLeft = Construct(grid, row, col, newSize);
        Node topRight = Construct(grid, row, col + newSize, newSize);
        Node bottomLeft = Construct(grid, row + newSize, col, newSize);
        Node bottomRight = Construct(grid, row + newSize, col + newSize, newSize);

        return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
    }

    private bool IsUniform(int[][] grid, int row, int col, int size) {
        int val = grid[row][col];
        for (int i = row; i < row + size; i++) {
            for (int j = col; j < col + size; j++) {
                if (grid[i][j] != val) {
                    return false;
                }
            }
        }
        return true;
    }
}