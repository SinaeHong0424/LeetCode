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
public class Solution
{
    private int ans;

    public int LongestZigZag(TreeNode root)
    {
        ans = 0;
        DFS(root, 0, 0);
        return ans;
    }

    private void DFS(TreeNode node, int leftLength, int rightLength)
    {
        if (node == null)
            return;

        ans = Math.Max(ans, Math.Max(leftLength, rightLength));
        DFS(node.left, rightLength + 1, 0);
        DFS(node.right, 0, leftLength + 1);
    }
}