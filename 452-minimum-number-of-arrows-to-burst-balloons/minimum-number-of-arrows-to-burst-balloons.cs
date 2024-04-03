public class Solution {
    public int FindMinArrowShots(int[][] points) {
        if (points.Length == 0)
            return 0;

        Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));

        int arrowsShot = 1; 
        int lastEnd = points[0][1]; 

        for (int i = 1; i < points.Length; i++) {
            
            if (points[i][0] > lastEnd) {
                arrowsShot++; 
                lastEnd = points[i][1]; 
            }
        }

        return arrowsShot;
    }
}