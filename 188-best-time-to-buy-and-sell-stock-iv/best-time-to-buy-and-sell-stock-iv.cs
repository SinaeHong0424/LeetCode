public class Solution {
    public int MaxProfit(int k, int[] prices){
        if (prices.Length==0) return 0;

        if (k >= prices.Length/2){
            int maxProfit=0;
            for (int i=1; i<prices.Length; i++){
                if (prices[i] > prices[i-1]){maxProfit +=prices[i]- prices[i-1];}
            }return maxProfit;
        
    } 
    int[,] dp=new int[k+1, prices.Length];
    for (int i=1; i<=k; i++){
        int maxDiff=-prices[0];
        for (int j=1; j<prices.Length; j++){
            dp[i,j]=Math.Max(dp[i,j-1],prices[j]+maxDiff);
            maxDiff=Math.Max(maxDiff, dp[i-1, j]-prices[j]);
        }
    }
    return dp[k, prices.Length-1];
}}