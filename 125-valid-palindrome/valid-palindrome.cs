public class Solution {
    public bool IsPalindrome(string s) {
        StringBuilder sb = new StringBuilder();
        
        foreach (char c in s) {
            if (char.IsLetterOrDigit(c)) {
                sb.Append(char.ToLower(c));
            }
        }
        
        string filteredString = sb.ToString();
        int left = 0;
        int right = filteredString.Length - 1;
        
        while (left < right) {
            if (filteredString[left] != filteredString[right]) {
                return false;
            }
            left++;
            right--;
        }
        
        return true;
    }
}
