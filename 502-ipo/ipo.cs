public class Solution {
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        PriorityQueue<(int capital, int profit), int> capitalQueue = new PriorityQueue<(int capital, int profit), int>();
        
        PriorityQueue<int, int> profitQueue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        
        for (int i = 0; i < profits.Length; i++) {
            capitalQueue.Enqueue((capital[i], profits[i]), capital[i]);
        }
        
        for (int i = 0; i < k; i++) {
            while (capitalQueue.Count > 0 && capitalQueue.Peek().capital <= w) {
                var project = capitalQueue.Dequeue();
                profitQueue.Enqueue(project.profit, project.profit);
            }
            
            if (profitQueue.Count == 0) {
                break;
            }
            
            w += profitQueue.Dequeue();
        }
        
        return w;
    }
}
