/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int CountNodes(TreeNode root) {
        if (root == null) return 0;

        int leftHeight = GetHeight(root, true);
        int rightHeight = GetHeight(root, false);

        // If the left and right heights are the same, it's a perfect binary tree
        if (leftHeight == rightHeight) {
            return (1 << leftHeight) - 1;
        }

        // If not, recursively count the nodes in the left and right subtrees
        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }

    // Helper function to calculate the height of the tree
    private int GetHeight(TreeNode node, bool isLeft) {
        int height = 0;
        while (node != null) {
            height++;
            node = isLeft ? node.left : node.right;
        }
        return height;
    }
}
