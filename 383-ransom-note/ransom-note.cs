public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        // Create a dictionary to store the frequency of each character in the magazine
        Dictionary<char, int> magazineCounts = new Dictionary<char, int>();
        
        // Count the frequency of each character in the magazine
        foreach (char c in magazine) {
            if (magazineCounts.ContainsKey(c)) {
                magazineCounts[c]++;
            } else {
                magazineCounts[c] = 1;
            }
        }
        
        // Check if the ransom note can be constructed from the magazine
        foreach (char c in ransomNote) {
            if (magazineCounts.ContainsKey(c) && magazineCounts[c] > 0) {
                magazineCounts[c]--;
            } else {
                return false;
            }
        }
        
        return true;
    }
}
