public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> current = new List<int>();
        Backtrack(result, current, 1, k, n);
        return result;
    }
    
    private void Backtrack(IList<IList<int>> result, List<int> current, int start, int k, int target) {
        if (k == 0 && target == 0) {
            result.Add(new List<int>(current));
            return;
        }
        
        for (int i = start; i <= 9; i++) {
            if (target - i < 0) break; 
            current.Add(i);
            Backtrack(result, current, i + 1, k - 1, target - i);
            current.RemoveAt(current.Count - 1);
        }
    }
}