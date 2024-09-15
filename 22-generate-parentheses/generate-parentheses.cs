public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        IList<string> result = new List<string>();
        
        void Backtrack(string current, int open, int close) {
            if (current.Length == n * 2) {
                result.Add(current);
                return;
            }
            
            if (open < n) {
                Backtrack(current + "(", open + 1, close);
            }
            
            if (close < open) {
                Backtrack(current + ")", open, close + 1);
            }
        }
        
        Backtrack("", 0, 0);
        
        return result;
    }
}
