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
    public IList<int> RightSideView(TreeNode root) {
        List<int> view = new List<int>();
        if (root == null) return view;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            int levelLength = queue.Count;
            for (int i = 0; i < levelLength; i++) {
                TreeNode currentNode = queue.Dequeue();
                // Only add the last node of each level to the view
                if (i == levelLength - 1) {
                    view.Add(currentNode.val);
                }
                // Add left and right children to the queue
                if (currentNode.left != null) queue.Enqueue(currentNode.left);
                if (currentNode.right != null) queue.Enqueue(currentNode.right);
            }
        }

        return view;
    }
}