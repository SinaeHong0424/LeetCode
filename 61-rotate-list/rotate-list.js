/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} head
 * @param {number} k
 * @return {ListNode}
 */
var rotateRight = function(head, k) {
    if (!head || k===0) return head;
    let length=1, tail=head;
    while (tail.next){tail=tail.next; length++;}
    tail.next=head;
    k=k%length; 
    let stepsToNewHead=length-k, newTail=tail; 
    while (stepsToNewHead--){newTail=newTail.next;}
    let newHead=newTail.next;
    newTail.next=null;
    return newHead;
};