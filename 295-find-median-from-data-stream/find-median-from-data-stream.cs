public class MedianFinder {
    private PriorityQueue<int, int> leftHeap;
    
    private PriorityQueue<int, int> rightHeap;

    public MedianFinder() {
        leftHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        
        rightHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        leftHeap.Enqueue(num, num);
        
        if (leftHeap.Count > 0 && rightHeap.Count > 0 && leftHeap.Peek() > rightHeap.Peek()) {
            int maxLeft = leftHeap.Dequeue();
            rightHeap.Enqueue(maxLeft, maxLeft);
        }
        
        if (leftHeap.Count > rightHeap.Count + 1) {
            int maxLeft = leftHeap.Dequeue();
            rightHeap.Enqueue(maxLeft, maxLeft);
        } else if (rightHeap.Count > leftHeap.Count) {
            int minRight = rightHeap.Dequeue();
            leftHeap.Enqueue(minRight, minRight);
        }
    }
    
    public double FindMedian() {
        if (leftHeap.Count > rightHeap.Count) {
            return leftHeap.Peek();
        }
        return (leftHeap.Peek() + rightHeap.Peek()) / 2.0;
    }
}
