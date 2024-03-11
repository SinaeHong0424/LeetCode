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
public class Solution{
    public int GoodNodes(TreeNode root) {
        return DFSGoodNodes(root, root.val);
    }
    private int DFSGoodNodes(TreeNode node, int maxValue){
        if (node ==null){
            return 0;
        }
        int goodNodes=0;
        if (node.val >=maxValue){
            goodNodes=1;
            maxValue=node.val;
        }
        goodNodes +=DFSGoodNodes(node.left, maxValue);
        goodNodes += DFSGoodNodes(node.right, maxValue);

        return goodNodes;
    }
}