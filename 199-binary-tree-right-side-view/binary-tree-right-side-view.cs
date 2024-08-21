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
        IList<int> result = new List<int>();
        if (root == null) {
            return result;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            int levelSize = queue.Count;
            int lastNodeVal = 0;

            for (int i = 0; i < levelSize; i++) {
                TreeNode currentNode = queue.Dequeue();
                lastNodeVal = currentNode.val;

                if (currentNode.left != null) {
                    queue.Enqueue(currentNode.left);
                }
                if (currentNode.right != null) {
                    queue.Enqueue(currentNode.right);
                }
            }

            result.Add(lastNodeVal);
        }

        return result;
    }
}