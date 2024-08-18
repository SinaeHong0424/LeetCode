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
public class BSTIterator {
    private Stack<TreeNode> stack;

    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        // Initialize the stack with the leftmost path of the tree
        PushLeftNodes(root);
    }
    
    // Helper method to push all left nodes of a given node
    private void PushLeftNodes(TreeNode node) {
        while (node != null) {
            stack.Push(node);
            node = node.left;
        }
    }

    public int Next() {
        // Pop the top node from the stack
        TreeNode topNode = stack.Pop();
        // If the popped node has a right child, push its leftmost path to the stack
        if (topNode.right != null) {
            PushLeftNodes(topNode.right);
        }
        // Return the value of the node
        return topNode.val;
    }
    
    public bool HasNext() {
        // The stack being non-empty means there are still elements in the traversal
        return stack.Count > 0;
    }
}


/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */