public class StockSpanner {
    private Stack<int> priceStack;
    private Stack<int> spanStack;

    public StockSpanner() {
        priceStack = new Stack<int>();
        spanStack = new Stack<int>();
    }

    public int Next(int price) {
        int span = 1;

        while (priceStack.Count > 0 && price >= priceStack.Peek()) {
            priceStack.Pop();
            span += spanStack.Pop();
        }

        priceStack.Push(price);
        spanStack.Push(span);

        return span;
    }
}
/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */