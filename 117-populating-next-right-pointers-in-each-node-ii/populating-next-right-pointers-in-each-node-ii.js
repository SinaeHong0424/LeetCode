/**
 * // Definition for a _Node.
 * function _Node(val, left, right, next) {
 *    this.val = val === undefined ? null : val;
 *    this.left = left === undefined ? null : left;
 *    this.right = right === undefined ? null : right;
 *    this.next = next === undefined ? null : next;
 * };
 */

/**
 * @param {_Node} root
 * @return {_Node}
 */
var connect = function(root) {
    if (!root) return null;
    let queue = [root]; 
    while (queue.length > 0) {
        let levelSize = queue.length;
        let prevNode = null;
        for (let i = 0; i < levelSize; i++) {
            let currentNode = queue.shift();
            if (prevNode) {
                prevNode.next = currentNode;
            }
            prevNode = currentNode;
            if (currentNode.left) queue.push(currentNode.left);
            if (currentNode.right) queue.push(currentNode.right);
        }
        prevNode.next = null;
    }
    return root;
};
