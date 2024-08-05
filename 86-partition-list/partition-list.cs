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
    public ListNode Partition(ListNode head, int x) {
        // Dummy nodes to start the less and greater lists
        ListNode lessHead = new ListNode(0);
        ListNode greaterHead = new ListNode(0);
        
        // Pointers to build the new lists
        ListNode less = lessHead;
        ListNode greater = greaterHead;
        
        // Traverse the original list
        while (head != null) {
            if (head.val < x) {
                less.next = head;
                less = less.next;
            } else {
                greater.next = head;
                greater = greater.next;
            }
            head = head.next;
        }
        
        // End the greater list
        greater.next = null;
        // Connect less list with greater list
        less.next = greaterHead.next;
        
        // Return the new head, which is the start of the less list
        return lessHead.next;
    }
}