public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        // Dictionary to store the last seen index of each element
        Dictionary<int, int> dict = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++) {
            // Check if the current number is in the dictionary and the index difference is within k
            if (dict.ContainsKey(nums[i]) && i - dict[nums[i]] <= k) {
                return true;
            }
            // Update the last seen index of the current number
            dict[nums[i]] = i;
        }
        
        return false;
    }
}
