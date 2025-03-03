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
var reverseKGroup = function(head, k) {
    if (!head || k===1) return head;
    let dummy=new ListNode(0);
    dummy.next=head;
    let prevGroupEnd=dummy, current=head;
    while (true){
        let kthNode=getKthNode(current, k);
        if (!kthNode) break;
        let nextGroupStart=kthNode.next, groupStart=current;
        reverse(groupStart,nextGroupStart);
        prevGroupEnd.next=kthNode;
        groupStart.next=nextGroupStart;
        prevGroupEnd=groupStart;
        current=nextGroupStart;
    }return dummy.next;
    function getKthNode(node,k){
        while (node && k>1){node=node.next; k--;}return node;
    }
    function reverse(start, end){
        let prev=null, current=start;
        while (current !==end){
            let tempNext=current.next;
            current.next=prev;
            prev=current;
            current=tempNext;
        }
    }
    
};