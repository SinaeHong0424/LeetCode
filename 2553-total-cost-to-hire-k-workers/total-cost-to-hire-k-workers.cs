using System;
using System.Collections.Generic;

public class Solution {
    public long TotalCost(int[] costs, int k, int candidates) {
        long ans = 0;  // Variable to store the total cost
        PriorityQueue<int> q1 = new PriorityQueue<int>();  // Priority queue to store the lowest costs from the beginning of the array
        PriorityQueue<int> q2 = new PriorityQueue<int>();  // Priority queue to store the highest costs from the end of the array
        int low = 0;  // Pointer to track the beginning of the array

        // Insert 'candidates' number of costs into q1
        while (low < candidates) {
            q1.Push(costs[low]);
            low++;
        }

        int cnt = 0;
        int high = costs.Length - 1;  // Pointer to track the end of the array

        // Adjust 'candidates' if it is greater than the number of elements from the end of the array
        if (candidates > costs.Length - candidates) {
            candidates = costs.Length - candidates;
        }  

        // Insert 'candidates' number of costs into q2 from the end of the array
        while (cnt < candidates) {
            q2.Push(costs[high]);
            cnt++;
            high--;
        }    

        while (k-- > 0) {
            if (q1.IsEmpty()) {  // If q1 is empty, take the lowest cost from q2
                ans += q2.Top();
                q2.Pop();
                if (low <= high) {
                    q2.Push(costs[high]);
                    high--;
                }        
            } else if (q2.IsEmpty()) {  // If q2 is empty, take the lowest cost from q1
                ans += q1.Top();
                q1.Pop();
                if (low <= high) {
                    q1.Push(costs[low]);
                    low++;
                } 
            } else if (q1.Top() <= q2.Top()) {  // If the lowest cost in q1 is less than or equal to the lowest cost in q2, take the lowest cost from q1
                ans += q1.Top();
                q1.Pop();
                if (low <= high) {
                    q1.Push(costs[low]);
                    low++;
                }
            } else {  // If the lowest cost in q2 is less than the lowest cost in q1, take the lowest cost from q2
                ans += q2.Top();
                q2.Pop();
                if (low <= high) {
                    q2.Push(costs[high]);
                    high--;
                }           
            }
        }
        return ans;  // Return the total cost
    }
}

// Implementation of priority queue
public class PriorityQueue<T> where T : IComparable<T> {
    private List<T> data;
    public PriorityQueue() {
        this.data = new List<T>();
    }
    public void Push(T item) {
        data.Add(item);
        int ci = data.Count - 1;
        while (ci > 0) {
            int pi = (ci - 1) / 2;
            if (data[ci].CompareTo(data[pi]) >= 0) break;
            T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
            ci = pi;
        }
    }
    public T Top() {
        return data[0];
    }
    public void Pop() {
        data[0] = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);

        int pi = 0;
        while (true) {
            int ci = pi * 2 + 1;
            if (ci >= data.Count) break;
            int rc = ci + 1;
            if (rc < data.Count && data[rc].CompareTo(data[ci]) < 0) ci = rc;
            if (data[pi].CompareTo(data[ci]) <= 0) break;
            T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp;
            pi = ci;
        }
    }
    public int Count {
        get { return data.Count; }
    }
    public bool IsEmpty() {
        return data.Count == 0;
    }
}
