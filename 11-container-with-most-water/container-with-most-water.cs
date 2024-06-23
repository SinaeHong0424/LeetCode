public class Solution {
    public int MaxArea(int[] height) {
        int left = 0;
        int right = height.Length - 1;
        int maxArea = 0;

        while (left < right) {
            int minHeight = Math.Min(height[left], height[right]);
            int width = right - left;
            int currentArea = minHeight * width;
            maxArea = Math.Max(maxArea, currentArea);

            if (height[left] < height[right]) {
                left++;
            } else {
                right--;
            }
        }

        return maxArea;
    }
}
