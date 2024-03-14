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
    private Dictionary<long, int> cnt = new Dictionary<long, int>();
    private int targetSum;

    public int PathSum(TreeNode root, int targetSum)
    {
        cnt[0L] = 1;
        this.targetSum = targetSum;
        return Dfs(root, 0);
    }

    private int Dfs(TreeNode node, long s)
    {
        if (node == null)
        {
            return 0;
        }
        s += node.val;
        int ans = cnt.GetValueOrDefault(s - targetSum, 0);
        cnt[s] = cnt.GetValueOrDefault(s, 0) + 1;
        ans += Dfs(node.left, s);
        ans += Dfs(node.right, s);
        cnt[s] -= 1;
        return ans;
    }
}

