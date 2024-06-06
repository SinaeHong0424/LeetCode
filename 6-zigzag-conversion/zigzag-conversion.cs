public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1 || s.Length <= numRows)
            return s;

        StringBuilder result = new StringBuilder();
        int cycle = 2 * numRows - 2;

        for (int i = 0; i < s.Length; i += cycle)
            result.Append(s[i]);

        for (int row = 1; row < numRows - 1; row++) {
            int j = row;
            bool flag = true;
            while (j < s.Length) {
                result.Append(s[j]);
                if (flag)
                    j += cycle - 2 * row;
                else
                    j += 2 * row;
                flag = !flag;
            }
        }

        for (int i = numRows - 1; i < s.Length; i += cycle)
            result.Append(s[i]);

        return result.ToString();
    }
}