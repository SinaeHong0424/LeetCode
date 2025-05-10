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
var sortList = function(head) {
    if (!head || !head.next) return head;

    let length = 0;
    let node = head;
    while (node) {length++;node = node.next;}

    let dummy = new ListNode(0, head);
    for (let size = 1; size < length; size *= 2) {
        let prev = dummy;
        let curr = dummy.next;
        
        while (curr) {
            let left = curr;
            let right = split(left, size);
            curr = split(right, size);
            prev = merge(prev, left, right);
        }
    }
    
    return dummy.next;
};

function split(head, size) {
    if (!head) return null;
    let prev = head;
    for (let i = 1; i < size && prev.next; i++) {
        prev = prev.next;
    }
    let next = prev.next;
    prev.next = null;
    return next;
}

function merge(prev, left, right) {
    let curr = prev;
    while (left && right) {
        if (left.val < right.val) {
            curr.next = left;
            left = left.next;
        } else {
            curr.next = right;
            right = right.next;
        }
        curr = curr.next;
    }
    curr.next = left ? left : right;
    while (curr.next) {
        curr = curr.next;
    }
    return curr;
}
