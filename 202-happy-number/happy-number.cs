public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> seenNumbers = new HashSet<int>();
        
        while (n != 1 && !seenNumbers.Contains(n)) {
            seenNumbers.Add(n);
            n = GetNextNumber(n);
        }
        
        return n == 1;
    }

    private int GetNextNumber(int n) {
        int sum = 0;
        while (n > 0) {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }
        return sum;
    }
}
