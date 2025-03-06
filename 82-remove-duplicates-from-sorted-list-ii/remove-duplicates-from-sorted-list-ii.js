/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var deleteDuplicates=function(head){
    if(!head) return null;
    let dummy=new ListNode(0,head), prev=dummy;
    while(head){
        if(head.next && head.val===head.next.val){
            while (head.next && head.val===head.next.val){head=head.next;}
            prev.next=head.next
        }else{prev=prev.next;}
        head=head.next;
    }return dummy.next;
};