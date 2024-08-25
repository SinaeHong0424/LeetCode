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
    public int GetMinimumDifference(TreeNode root) {
        List<int> values = new List<int>();
        InOrderTraversal(root, values);
        
        int minDifference = int.MaxValue;
        
        for (int i = 1; i < values.Count; i++) {
            int difference = values[i] - values[i - 1];
            if (difference < minDifference) {
                minDifference = difference;
            }
        }
        
        return minDifference;
    }
    
    private void InOrderTraversal(TreeNode node, List<int> values) {
        if (node == null) return;
        
        InOrderTraversal(node.left, values);
        values.Add(node.val);
        InOrderTraversal(node.right, values);
    }
}
