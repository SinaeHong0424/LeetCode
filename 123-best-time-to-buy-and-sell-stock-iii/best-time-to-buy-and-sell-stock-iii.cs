public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices == null || prices.Length == 0) return 0;

        int firstBuy = int.MinValue, firstSell = 0,secondBuy = int.MinValue, secondSell = 0;
        

        foreach (int price in prices) {
            firstBuy = Math.Max(firstBuy, -price); 
            firstSell = Math.Max(firstSell, firstBuy + price); 
            secondBuy = Math.Max(secondBuy, firstSell - price); 
            secondSell = Math.Max(secondSell, secondBuy + price); 
        }

        return secondSell;
    }
}
