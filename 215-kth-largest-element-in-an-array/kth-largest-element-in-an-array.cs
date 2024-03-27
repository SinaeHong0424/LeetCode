public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var maxHeap = new PriorityQueue<int>((a, b) => b.CompareTo(a));

        for (int i = 0; i < k; i++) {
            maxHeap.Enqueue(nums[i]);
        }

        for (int i = k; i < nums.Length; i++) {
            if (nums[i] > maxHeap.Peek()) {
                maxHeap.Dequeue();
                maxHeap.Enqueue(nums[i]);
            }
        }

        return maxHeap.Peek();
    }
}

public class PriorityQueue<T> where T : IComparable<T> {
    private readonly List<T> heap;
    private readonly Comparison<T> comparison;

    public PriorityQueue(Comparison<T> comparison) {
        this.heap = new List<T>();
        this.comparison = comparison;
    }

    public void Enqueue(T item) {
        heap.Add(item);
        int i = heap.Count - 1;
        while (i > 0) {
            int parent = (i - 1) / 2;
            if (comparison(heap[parent], heap[i]) >= 0) break;
            Swap(parent, i);
            i = parent;
        }
    }

    public T Dequeue() {
        int lastIndex = heap.Count - 1;
        T frontItem = heap[0];
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        int i = 0;
        while (true) {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < heap.Count && comparison(heap[left], heap[largest]) > 0)
                largest = left;
            if (right < heap.Count && comparison(heap[right], heap[largest]) > 0)
                largest = right;

            if (largest == i) break;
            Swap(i, largest);
            i = largest;
        }

        return frontItem;
    }

    public T Peek() {
        return heap[0];
    }

    private void Swap(int i, int j) {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}
