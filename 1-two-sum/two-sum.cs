public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Create a dictionary to store the numbers and their indices
        Dictionary<int, int> numDict = new Dictionary<int, int>();

        // Iterate through the array
        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];

            // Check if the complement exists in the dictionary
            if (numDict.ContainsKey(complement)) {
                return new int[] { numDict[complement], i };
            }

            // If not, add the current number and its index to the dictionary
            if (!numDict.ContainsKey(nums[i])) {
                numDict.Add(nums[i], i);
            }
        }

        // Return an empty array if no solution is found (this line should never be reached)
        return new int[0];
    }
}
