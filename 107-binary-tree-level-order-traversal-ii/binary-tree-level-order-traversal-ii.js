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
 * @return {number[][]}
 */
var levelOrderBottom = function(root) {
    if(!root) return [];
    const queue=[root];
    const result=[];
    while (queue.length>0){
        const levelSize=queue.length;
        const currentLevel=[];
        for(let i=0; i<levelSize; i++){
            const node=queue.shift();
            currentLevel.push(node.val);
            if(node.left)queue.push(node.left);
            if(node.right)queue.push(node.right);
        }
        result.unshift(currentLevel);
    }
    return result;
};