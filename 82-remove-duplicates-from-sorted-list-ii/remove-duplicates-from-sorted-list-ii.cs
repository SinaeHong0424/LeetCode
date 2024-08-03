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
    public ListNode DeleteDuplicates(ListNode head) {
        // Initialize a dummy node
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        // prev is the last node before the sublist of duplicates
        ListNode prev = dummy;
        
        while (head != null) {
            // If it's a beginning of duplicates sublist
            // skip all duplicates
            if (head.next != null && head.val == head.next.val) {
                // move till the end of duplicates sublist
                while (head.next != null && head.val == head.next.val) {
                    head = head.next;
                }
                // skip all duplicates
                prev.next = head.next; 
            } else {
                // otherwise, move prev
                prev = prev.next;
            }
            // move forward
            head = head.next;
        }
        
        return dummy.next;
    }
}