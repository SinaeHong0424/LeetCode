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
    public int SumNumbers(TreeNode root) {
        return SumNumbersHelper(root, 0);
    }

    private int SumNumbersHelper(TreeNode node, int currentSum) {
        if (node == null) {
            return 0;
        }

        currentSum = currentSum * 10 + node.val;

        // If it's a leaf node, return the current sum
        if (node.left == null && node.right == null) {
            return currentSum;
        }

        // Recursively calculate the sum for left and right subtrees
        int leftSum = SumNumbersHelper(node.left, currentSum);
        int rightSum = SumNumbersHelper(node.right, currentSum);

        return leftSum + rightSum;
    }
}