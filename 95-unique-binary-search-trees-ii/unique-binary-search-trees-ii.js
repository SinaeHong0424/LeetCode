/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {number} n
 * @return {TreeNode[]}
 */
var generateTrees=function(n){
    if(n===0) return [];
    const buildTrees=(start,end)=>{
        const trees=[];
        if(start>end){
            trees.push(null);
            return trees;
        }
        for (let i=start; i<=end; i++){
            const leftSubtrees=buildTrees(start,i-1);
            const rightSubtrees=buildTrees(i+1,end);
            for(let left of leftSubtrees){
                for (let right of rightSubtrees){
                    const root=new TreeNode(i);
                    root.left=left;
                    root.right=right;
                    trees.push(root);
                }
            }
        }
        return trees;
    }
    return buildTrees(1,n);
};