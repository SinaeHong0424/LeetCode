public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        int len1 = s1.Length, len2 = s2.Length, len3 = s3.Length;
        if (len1 + len2 != len3) return false;

        bool[,] dp = new bool[len1 + 1, len2 + 1];
        dp[0, 0] = true;

        for (int i = 1; i <= len1; i++) {
            dp[i, 0] = dp[i - 1, 0] && s1[i - 1] == s3[i - 1];
        }

        for (int j = 1; j <= len2; j++) {
            dp[0, j] = dp[0, j - 1] && s2[j - 1] == s3[j - 1];
        }

        for (int i = 1; i <= len1; i++) {
            for (int j = 1; j <= len2; j++) {
                dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) || (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
            }
        }

        return dp[len1, len2];
    }
}
