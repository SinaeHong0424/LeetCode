public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        if (prices == null || prices.Length <= 1)
            return 0;
        
        int n = prices.Length;
        int cash = 0;
        int hold = -prices[0]; 
        
        for (int i = 1; i < n; i++) {
            cash = Math.Max(cash, hold + prices[i] - fee);
            hold = Math.Max(hold, cash - prices[i]);
        }
        
        return cash;
    }
}
