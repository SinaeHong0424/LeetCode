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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        // Dictionary to store the index of each value in the inorder array for quick access
        Dictionary<int, int> inorderIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) {
            inorderIndexMap[inorder[i]] = i;
        }

        // Helper function to build the tree
        return BuildSubTree(preorder, inorder, 0, 0, inorder.Length - 1, inorderIndexMap);
    }

    private TreeNode BuildSubTree(int[] preorder, int[] inorder, int preStart, int inStart, int inEnd, Dictionary<int, int> inorderIndexMap) {
        if (preStart >= preorder.Length || inStart > inEnd) {
            return null;
        }

        // Root value is the first element in the current preorder section
        int rootVal = preorder[preStart];
        TreeNode root = new TreeNode(rootVal);

        // Find the root index in inorder traversal
        int rootIndex = inorderIndexMap[rootVal];

        // Recursively build the left and right subtrees
        root.left = BuildSubTree(preorder, inorder, preStart + 1, inStart, rootIndex - 1, inorderIndexMap);
        root.right = BuildSubTree(preorder, inorder, preStart + 1 + (rootIndex - inStart), rootIndex + 1, inEnd, inorderIndexMap);

        return root;
    }
}