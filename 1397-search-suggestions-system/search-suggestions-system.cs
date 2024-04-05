public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Array.Sort(products);
        
        IList<IList<string>> result = new List<IList<string>>();
        string prefix = "";

        foreach (char c in searchWord) {
            prefix += c;
            IList<string> suggestions = new List<string>();
            
            foreach (string product in products) {
                if (product.StartsWith(prefix)) {
                    suggestions.Add(product);
                    if (suggestions.Count == 3) break;
                }
            }
            
            result.Add(suggestions);
        }
        
        return result;
    }
}
