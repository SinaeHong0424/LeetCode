public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> currentCombination = new List<int>();
        
        Array.Sort(candidates);

        void Backtrack(int remainingTarget, int startIndex) {
            if (remainingTarget == 0) {
                result.Add(new List<int>(currentCombination));
                return;
            }

            if (remainingTarget < 0) {
                return;
            }

            for (int i = startIndex; i < candidates.Length; i++) {
                int currentCandidate = candidates[i];

                currentCombination.Add(currentCandidate);

                Backtrack(remainingTarget - currentCandidate, i);

                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }

        Backtrack(target, 0);
        return result;
    }
}
