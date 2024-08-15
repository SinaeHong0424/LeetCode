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
    public bool HasPathSum(TreeNode root, int targetSum) {
        // If the root is null, there is no path, so return false
        if (root == null) {
            return false;
        }
        
        // If this is a leaf node, check if the sum of the path equals targetSum
        if (root.left == null && root.right == null) {
            return root.val == targetSum;
        }
        
        // Subtract the current node's value from targetSum and check recursively for the left and right subtrees
        int newTargetSum = targetSum - root.val;
        
        // Return true if either the left or right subtree has a path that satisfies the condition
        return HasPathSum(root.left, newTargetSum) || HasPathSum(root.right, newTargetSum);
    }
}
