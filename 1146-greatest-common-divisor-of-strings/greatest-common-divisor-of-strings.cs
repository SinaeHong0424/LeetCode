public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        bool IsDivisible(string str1, string str2) {
            int len1 = str1.Length;
            int len2 = str2.Length;
            
            if (len1 % len2 != 0) return false;
            
            StringBuilder repeatedStr2 = new StringBuilder();
            for (int i = 0; i < len1 / len2; i++) {
                repeatedStr2.Append(str2);
            }
            
            return repeatedStr2.ToString().Equals(str1);
        }
        
        int gcdLength = GCD(str1.Length, str2.Length);
        
        string candidate = str1.Substring(0, gcdLength);
        
        if (IsDivisible(str1, candidate) && IsDivisible(str2, candidate)) {
            return candidate;
        }
        
        return "";
    }
    
    private int GCD(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
