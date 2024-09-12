public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> currentCombination = new List<int>();

        void Backtrack(int start) {
            if (currentCombination.Count == k) {
                result.Add(new List<int>(currentCombination));
                return;
            }

            for (int i = start; i <= n; i++) {
                currentCombination.Add(i);

                Backtrack(i + 1);

                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }

        Backtrack(1);
        
        return result;
    }
}
