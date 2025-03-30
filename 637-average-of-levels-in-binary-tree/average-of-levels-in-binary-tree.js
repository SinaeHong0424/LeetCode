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
 * @return {number[]}
 */
var averageOfLevels = function(root) {
    const averages=[];
    const queue=[root];
    while (queue.length>0){
        let levelSize=queue.length;
        let levelSum=0;
        for(let i=0; i<levelSize; i++){
            const node=queue.shift();
            levelSum+=node.val;

            if(node.left) queue.push(node.left);
            if(node.right) queue.push(node.right);
        }averages.push(levelSum /levelSize);
    }return averages;
};