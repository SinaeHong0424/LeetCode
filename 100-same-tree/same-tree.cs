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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        // If both nodes are null, the trees are the same up to this point
        if (p == null && q == null) {
            return true;
        }
        
        // If one node is null and the other is not, the trees are different
        if (p == null || q == null) {
            return false;
        }
        
        // Check if the values of the current nodes are the same and 
        // recursively check the left and right subtrees
        return (p.val == q.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
