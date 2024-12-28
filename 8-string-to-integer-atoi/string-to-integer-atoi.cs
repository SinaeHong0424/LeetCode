public class Solution {
    public int MyAtoi(string s) {
        s = s.Trim();
        if (s.Length == 0) return 0;

        int sign = 1;
        int index = 0;
        if (s[index] == '+' || s[index] == '-') {
            sign = s[index] == '-' ? -1 : 1;
            index++;
        }

        int result = 0;
        int maxInt = int.MaxValue / 10;
        while (index < s.Length) {
            char c = s[index];
            if (c < '0' || c > '9') break;

            if (result > maxInt || (result == maxInt && c - '0' > 7)) {
                return sign == 1 ? int.MaxValue : int.MinValue;
            }

            result = result * 10 + (c - '0');
            index++;
        }

        return result * sign;
    }
}
