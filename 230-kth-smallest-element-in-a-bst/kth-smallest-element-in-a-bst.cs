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
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = root;
        int count = 0;

        while (current != null || stack.Count > 0) {
            while (current != null) {
                stack.Push(current);
                current = current.left;
            }
            
            current = stack.Pop();
            count++;
            
            if (count == k) {
                return current.val;
            }
            
            current = current.right;
        }
        
        // In case of an invalid input (k out of range), though constraints ensure k is always valid.
        throw new ArgumentException("k is out of range");
    }
}