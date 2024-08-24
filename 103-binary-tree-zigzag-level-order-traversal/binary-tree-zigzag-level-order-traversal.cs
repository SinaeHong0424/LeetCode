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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool leftToRight = true;

        while (queue.Count > 0) {
            int levelSize = queue.Count;
            var levelNodes = new List<int>();

            for (int i = 0; i < levelSize; i++) {
                var node = queue.Dequeue();
                if (leftToRight) {
                    levelNodes.Add(node.val);
                } else {
                    levelNodes.Insert(0, node.val);  // Insert at the beginning for reverse order
                }

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            result.Add(levelNodes);
            leftToRight = !leftToRight;  // Flip the order for the next level
        }

        return result;
    }
}
