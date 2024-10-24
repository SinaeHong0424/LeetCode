public class Solution {
    public int[] PlusOne(int[] digits) {
        int n = digits.Length;
        
        // Traverse the array from the last digit
        for (int i = n - 1; i >= 0; i--) {
            // If the current digit is less than 9, just increment it and return
            if (digits[i] < 9) {
                digits[i]++;
                return digits;
            }
            
            // Set the current digit to 0 and continue to the next
            digits[i] = 0;
        }
        
        // If all digits are 9, we need to add a new digit at the beginning
        int[] newDigits = new int[n + 1];
        newDigits[0] = 1;  // The first digit becomes 1, rest are already 0
        return newDigits;
    }
}
