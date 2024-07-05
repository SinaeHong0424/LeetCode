public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }
        
        // Dictionaries to keep track of mappings from s to t and t to s
        Dictionary<char, char> mapST = new Dictionary<char, char>();
        Dictionary<char, char> mapTS = new Dictionary<char, char>();
        
        for (int i = 0; i < s.Length; i++) {
            char charS = s[i];
            char charT = t[i];
            
            // Check if there is already a mapping from charS to charT
            if (mapST.ContainsKey(charS)) {
                if (mapST[charS] != charT) {
                    return false; // Mismatch in mapping
                }
            } else {
                mapST[charS] = charT;
            }
            
            // Check if there is already a mapping from charT to charS
            if (mapTS.ContainsKey(charT)) {
                if (mapTS[charT] != charS) {
                    return false; // Mismatch in mapping
                }
            } else {
                mapTS[charT] = charS;
            }
        }
        
        return true;
    }
}
