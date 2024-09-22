public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        int totalSum = 0;
        int maxSum = int.MinValue;
        int currentMax = 0;
        int minSum = int.MaxValue;
        int currentMin = 0;

        foreach (int num in nums) {
            totalSum += num;

            currentMax = Math.Max(currentMax + num, num);
            maxSum = Math.Max(maxSum, currentMax);

            currentMin = Math.Min(currentMin + num, num);
            minSum = Math.Min(minSum, currentMin);
        }

        if (maxSum < 0) {
            return maxSum;
        }

        return Math.Max(maxSum, totalSum - minSum);
    }
}
