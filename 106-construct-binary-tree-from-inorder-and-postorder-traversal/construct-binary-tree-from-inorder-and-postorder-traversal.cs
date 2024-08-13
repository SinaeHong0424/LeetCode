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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        if (inorder == null || postorder == null || inorder.Length != postorder.Length) {
            return null;
        }
        
        // Dictionary to store value -> index mappings for inorder array
        var inorderMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) {
            inorderMap[inorder[i]] = i;
        }
        
        return BuildTreeHelper(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1, inorderMap);
    }
    
    private TreeNode BuildTreeHelper(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd, Dictionary<int, int> inorderMap) {
        if (inStart > inEnd || postStart > postEnd) {
            return null;
        }
        
        // The root value is the last element in the current postorder segment
        int rootValue = postorder[postEnd];
        TreeNode root = new TreeNode(rootValue);
        
        // Get the root index from the inorder array using the map
        int rootIndex = inorderMap[rootValue];
        
        // Calculate the size of the left subtree
        int leftTreeSize = rootIndex - inStart;
        
        // Recursively build the left and right subtrees
        root.left = BuildTreeHelper(inorder, inStart, rootIndex - 1, postorder, postStart, postStart + leftTreeSize - 1, inorderMap);
        root.right = BuildTreeHelper(inorder, rootIndex + 1, inEnd, postorder, postStart + leftTreeSize, postEnd - 1, inorderMap);
        
        return root;
    }
}