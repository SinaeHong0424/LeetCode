/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null || head.next == null || k == 0) return head;

        // Compute the length of the list
        ListNode oldTail = head;
        int length = 1;
        while (oldTail.next != null) {
            oldTail = oldTail.next;
            length++;
        }
        
        // Connect the tail to the head to make it a circular list
        oldTail.next = head;
        
        // Adjust k to be within the length of the list
        k = k % length;
        if (k == 0) {
            oldTail.next = null;
            return head;
        }
        
        // Find the new tail (length - k - 1) and new head (length - k)
        ListNode newTail = head;
        for (int i = 0; i < length - k - 1; i++) {
            newTail = newTail.next;
        }
        ListNode newHead = newTail.next;
        
        // Break the circle
        newTail.next = null;
        
        return newHead;
    }
}