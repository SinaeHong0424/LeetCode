public class Solution {
    public int NumTilings(int n) {
        const int MOD = 1000000007;
        long[] dp = new long[Math.Max(n + 1, 4)];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 5;
        
        for (int i = 4; i <= n; i++) {
            dp[i] = (2 * dp[i - 1] + dp[i - 3]) % MOD;
        }
        
        return (int)dp[n];
    }
}
