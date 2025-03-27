/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number}
 */
var sumNumbers = function(root) {
    const helper =(node, currentSum)=>{
        if (!node)return 0;
        currentSum=currentSum*10+node.val;
        if(!node.left && !node.right){return currentSum;}
        return helper(node.left,currentSum)+helper(node.right,currentSum);
    };
    return helper(root, 0);
};