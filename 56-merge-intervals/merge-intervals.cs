public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0) return new int[0][];

        // Sort intervals by the starting values
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> mergedIntervals = new List<int[]>();
        int[] currentInterval = intervals[0];

        foreach (var interval in intervals) {
            // If the current interval overlaps with the next interval, merge them
            if (interval[0] <= currentInterval[1]) {
                currentInterval[1] = Math.Max(currentInterval[1], interval[1]);
            } else {
                // If not, add the current interval to the list and move to the next
                mergedIntervals.Add(currentInterval);
                currentInterval = interval;
            }
        }

        // Add the last interval
        mergedIntervals.Add(currentInterval);

        return mergedIntervals.ToArray();
    }
}
