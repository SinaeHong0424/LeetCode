public class Solution {
    public bool IsAnagram(string s, string t) {
        // If lengths are not the same, they cannot be anagrams
        if (s.Length != t.Length) {
            return false;
        }

        // Create arrays to count the frequency of each character
        int[] countS = new int[26];
        int[] countT = new int[26];

        // Count the frequency of each character in both strings
        for (int i = 0; i < s.Length; i++) {
            countS[s[i] - 'a']++;
            countT[t[i] - 'a']++;
        }

        // Compare the frequency arrays
        for (int i = 0; i < 26; i++) {
            if (countS[i] != countT[i]) {
                return false;
            }
        }

        return true;
    }
}
