public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1;
        int right = (int)Math.Pow(10, 9); 
        while (left < right) {
            int mid = left + (right - left) / 2;
            
            if (CanEatAll(piles, mid, h)) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        
        return left;
    }
    
    private bool CanEatAll(int[] piles, int k, int h) {
        int hours = 0;
        foreach (int pile in piles) {
            hours += (int)Math.Ceiling((double)pile / k);
        }
        return hours <= h;
    }
}
