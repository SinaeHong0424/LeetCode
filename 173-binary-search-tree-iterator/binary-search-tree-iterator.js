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
 */
var BSTIterator = function(root) {
    this.nodes=[];
    this._inorderTraversal(root);
    this.index=0;
};

/**
 * @return {number}
 */
BSTIterator.prototype.next = function() {
return this.nodes[this.index++];
};

/**
 * @return {boolean}
 */
BSTIterator.prototype.hasNext = function() {
    return this.index <this.nodes.length;
};

/**
*@param {TreeNode} root
*@return {void}
 */
 BSTIterator.prototype._inorderTraversal=function(root){
    if(root){
        this._inorderTraversal(root.left);
        this.nodes.push(root.val);
        this._inorderTraversal(root.right);
    }
 };
/** 
 * Your BSTIterator object will be instantiated and called as such:
 * var obj = new BSTIterator(root)
 * var param_1 = obj.next()
 * var param_2 = obj.hasNext()
 */