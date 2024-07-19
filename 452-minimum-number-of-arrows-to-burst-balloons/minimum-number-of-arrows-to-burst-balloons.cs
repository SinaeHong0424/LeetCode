public class Solution {
    public int FindMinArrowShots(int[][] points) {
        if (points == null || points.Length == 0) {
            return 0;
        }

        // Sort balloons by their end coordinate
        Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));

        int arrows = 1; // At least one arrow is needed
        int end = points[0][1]; // Position of the first arrow

        foreach (var point in points) {
            if (point[0] > end) {
                // Need a new arrow for this balloon
                arrows++;
                end = point[1];
            }
        }

        return arrows;
    }
}
