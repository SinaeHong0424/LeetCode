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
var zigzagLevelOrder = function(root) {
    if (!root) return [];
    const result=[], queue=[root];
    let leftToRight=true;
    while (queue.length >0){
        const level=[], size=queue.length;
        for (let i=0; i<size; i++){
            const node=queue.shift();
            level.push(node.val);
            if (node.left) queue.push(node.left);
            if (node.right) queue.push(node.right);
        }
        if (!leftToRight){level.reverse();}
        result.push(level);
        leftToRight=!leftToRight;
    }return result;
};