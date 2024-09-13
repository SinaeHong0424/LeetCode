public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> currentPermutation = new List<int>();
        bool[] used = new bool[nums.Length];

        void Backtrack() {
            if (currentPermutation.Count == nums.Length) {
                result.Add(new List<int>(currentPermutation));
                return;
            }

            for (int i = 0; i < nums.Length; i++) {
                if (used[i]) continue;

                used[i] = true;
                currentPermutation.Add(nums[i]);

                Backtrack();

                currentPermutation.RemoveAt(currentPermutation.Count - 1);
                used[i] = false;
            }
        }

        Backtrack();
        return result;
    }
}
