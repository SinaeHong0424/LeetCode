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
public class Solution{
    public int PairSum(ListNode head){
        if (head==null || head.next==null) return 0;

        ListNode slow=head, fast=head;
        while (fast !=null && fast.next !=null){
            slow=slow.next;
            fast=fast.next.next;
        }
        ListNode prev=null, current=slow, temp;
        while (current !=null){
            temp=current.next;
            current.next=prev;
            prev=current;
            current=temp;
        }
        int maxSum=0;
        ListNode firstHalf=head, secondHalf=prev;
        while (secondHalf !=null){
            maxSum=Math.Max(maxSum, firstHalf.val+secondHalf.val);
            firstHalf=firstHalf.next;
            secondHalf=secondHalf.next;
        }
        return maxSum;
    }
}