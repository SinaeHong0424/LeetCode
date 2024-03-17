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
    public int MaxLevelSum(TreeNode root) {
        if (root == null) return 0;

        int maxSum = int.MinValue, maxLevel = 1, level = 1;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            int levelSize = queue.Count;
            int currentLevelSum = 0;
            
            for (int i = 0; i < levelSize; i++) {
                TreeNode currentNode = queue.Dequeue();
                currentLevelSum += currentNode.val;

                if (currentNode.left != null) queue.Enqueue(currentNode.left);
                if (currentNode.right != null) queue.Enqueue(currentNode.right);
            }

            if (currentLevelSum > maxSum) {
                maxSum = currentLevelSum;
                maxLevel = level;
            }

            level++;
        }

        return maxLevel;
    }
}