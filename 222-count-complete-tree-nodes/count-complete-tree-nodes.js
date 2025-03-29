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
var countNodes = function(root) {
    if (!root)return 0;
    const calculateDepth=(node)=>{
        let depth=0;
        while (node){depth++; node=node.left;}return depth;
    };
    const leftDepth=calculateDepth(root.left);
    const rightDepth=calculateDepth(root.right);

    if(leftDepth===rightDepth){return(1<<leftDepth)+countNodes(root.right);}
    else{return (1<<rightDepth)+countNodes(root.left);}
};