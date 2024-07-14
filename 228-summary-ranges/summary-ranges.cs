public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        List<string> ranges = new List<string>();
        
        if (nums.Length == 0) return ranges;

        int start = nums[0];
        int end = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] == end + 1) {
                end = nums[i];
            } else {
                if (start == end) {
                    ranges.Add(start.ToString());
                } else {
                    ranges.Add($"{start}->{end}");
                }
                start = nums[i];
                end = nums[i];
            }
        }

        if (start == end) {
            ranges.Add(start.ToString());
        } else {
            ranges.Add($"{start}->{end}");
        }

        return ranges;
    }
}
