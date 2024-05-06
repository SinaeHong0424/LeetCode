public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        int n = spells.Length;
        int m = potions.Length;
        int[] pairs = new int[n];

        // Sort the potions array in ascending order
        Array.Sort(potions);

        for (int i = 0; i < n; i++) {
            int spell = spells[i];
            int count = 0;

            // Binary search to find the first potion that makes a successful pair
            int left = 0, right = m - 1;
            while (left <= right) {
                int mid = left + (right - left) / 2;
                long product = (long)spell * potions[mid];
                if (product < success) {
                    left = mid + 1;
                } else {
                    count = m - mid;
                    right = mid - 1;
                }
            }

            pairs[i] = count;
        }

        return pairs;
    }
}