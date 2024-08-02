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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        // Create a dummy node to handle edge cases such as removing the head
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode first = dummy;
        ListNode second = dummy;
        
        // Move the first pointer n steps ahead
        for (int i = 0; i <= n; i++) {
            first = first.next;
        }
        
        // Move both pointers until the first one reaches the end
        while (first != null) {
            first = first.next;
            second = second.next;
        }
        
        // Remove the nth node from the end
        second.next = second.next.next;
        
        return dummy.next;
    }
}