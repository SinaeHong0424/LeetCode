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
    public void Flatten(TreeNode root) {
        if (root == null) return;

        // Flatten the left and right subtrees
        Flatten(root.left);
        Flatten(root.right);

        // Store the right subtree
        TreeNode rightSubtree = root.right;

        // Move the left subtree to the right
        root.right = root.left;
        root.left = null;

        // Move to the end of the new right subtree
        TreeNode current = root;
        while (current.right != null) {
            current = current.right;
        }

        // Attach the stored right subtree
        current.right = rightSubtree;
    }
}