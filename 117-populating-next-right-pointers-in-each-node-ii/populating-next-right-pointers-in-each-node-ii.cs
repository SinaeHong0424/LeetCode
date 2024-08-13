/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if (root == null) return null;
        
        Node leftmost = root;

        while (leftmost != null) {
            Node head = leftmost;
            Node prev = null;
            leftmost = null;

            while (head != null) {
                if (head.left != null) {
                    if (prev != null) {
                        prev.next = head.left;
                    } else {
                        leftmost = head.left;
                    }
                    prev = head.left;
                }

                if (head.right != null) {
                    if (prev != null) {
                        prev.next = head.right;
                    } else {
                        leftmost = head.right;
                    }
                    prev = head.right;
                }

                head = head.next;
            }
        }

        return root;
    }
}
