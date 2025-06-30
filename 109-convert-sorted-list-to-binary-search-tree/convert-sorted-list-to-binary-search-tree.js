/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {ListNode} head
 * @return {TreeNode}
 */
var sortedListToBST = function(head) {
  function getSize(node){
    let size=0;
    while (node){
        size++;
        node=node.next;
    }
    return size;
  }  
  let current=head;
  function convert(left,right){
    if(left>right)return null;
    const mid=Math.floor((left+right)/2);
    let leftChild=convert(left,mid-1);
    let node=new TreeNode(current.val);
    node.left=leftChild;
    current=current.next;
    node.right=convert(mid+1,right);
    return node;
      }
    const size=getSize(head);
    return convert(0,size-1);
};