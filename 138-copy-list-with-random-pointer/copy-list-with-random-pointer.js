/**
 * // Definition for a _Node.
 * function _Node(val, next, random) {
 *    this.val = val;
 *    this.next = next;
 *    this.random = random;
 * };
 */

/**
 * @param {_Node} head
 * @return {_Node}
 */
var copyRandomList = function(head) {
    if (head===null) return null;
    let current =head;
    while (current !==null){
        let copy=new _Node(current.val);
        copy.next=current.next;
        current.next=copy;
        current=copy.next;
    }
    current=head;
    while (current !==null){
        if(current.random !== null){current.next.random=current.random.next;}
        current=current.next.next;
    }
    current=head;
    let copiedHead=head.next;
    while (current !==null){
        let copy=current.next;
        current.next=copy.next;
        if(copy.next !==null){copy.next=copy.next.next;}
        current=current.next;
    }return copiedHead;
};