/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        // If the current node is null, return null
        if (root == null) return null;

        // If the current node is either p or q, then this node is an ancestor
        if (root == p || root == q) return root;

        // Recursively search for the LCA in the left and right subtrees
        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        // If both left and right are non-null, p and q are found in different subtrees
        // Hence, the current node is their LCA
        if (left != null && right != null) return root;

        // Otherwise, return the non-null node (either left or right)
        return left != null ? left : right;
    }
}