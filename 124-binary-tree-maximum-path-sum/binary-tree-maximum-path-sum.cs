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
    private int maxSum = int.MinValue;

    public int MaxPathSum(TreeNode root) {
        CalculateMaxPath(root);
        return maxSum;
    }

    private int CalculateMaxPath(TreeNode node) {
        if (node == null) return 0;

        // Recursively calculate the maximum path sum for the left and right subtrees
        int leftMax = Math.Max(CalculateMaxPath(node.left), 0); // Ignore paths with negative sum
        int rightMax = Math.Max(CalculateMaxPath(node.right), 0); // Ignore paths with negative sum

        // Calculate the maximum path sum with the current node as the highest node (root of this subtree)
        int currentMax = node.val + leftMax + rightMax;

        // Update the global maximum path sum
        maxSum = Math.Max(maxSum, currentMax);

        // Return the maximum path sum where the current node is the highest node on the path
        return node.val + Math.Max(leftMax, rightMax);
    }
}
