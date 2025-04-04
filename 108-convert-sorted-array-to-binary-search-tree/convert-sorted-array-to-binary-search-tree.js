/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {number[]} nums
 * @return {TreeNode}
 */
var sortedArrayToBST = function(nums) {
    if(nums.length===0) return null;
    const buildTree=(left,right)=>{
        if (left >right) return null;
        let mid=Math.floor((left+right)/2), root=new TreeNode(nums[mid]);
        root.left=buildTree(left,mid-1);
        root.right=buildTree(mid+1,right);
        return root;
    };
    return buildTree(0,nums.length-1);
};