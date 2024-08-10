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
    public TreeNode InvertTree(TreeNode root) {
        // Base case: If the root is null, return null
        if (root == null) {
            return null;
        }

        // Recursively invert the left and right subtrees
        TreeNode left = InvertTree(root.left);
        TreeNode right = InvertTree(root.right);

        // Swap the left and right children
        root.left = right;
        root.right = left;

        // Return the root (which now has inverted children)
        return root;
    }
}
