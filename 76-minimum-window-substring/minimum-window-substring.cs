public class Solution {
    public string MinWindow(string s, string t) {
        if (s.Length == 0 || t.Length == 0) return "";
        
        // Dictionary to count all characters in t
        Dictionary<char, int> dictT = new Dictionary<char, int>();
        foreach (char c in t) {
            if (dictT.ContainsKey(c)) {
                dictT[c]++;
            } else {
                dictT[c] = 1;
            }
        }

        // Number of unique characters in t that must be present in the window
        int required = dictT.Count;
        
        // Left and right pointer
        int l = 0, r = 0;

        // Dictionary to keep track of the characters in the current window
        Dictionary<char, int> windowCounts = new Dictionary<char, int>();

        // Variables to keep track of the number of unique characters in the current window
        // that match the desired frequency in t
        int formed = 0;

        // (window length, left, right)
        int[] ans = {-1, 0, 0};

        while (r < s.Length) {
            // Add one character from the right to the window
            char c = s[r];
            if (windowCounts.ContainsKey(c)) {
                windowCounts[c]++;
            } else {
                windowCounts[c] = 1;
            }

            // If the frequency of the current character added equals to the desired count in t
            // increment the formed count
            if (dictT.ContainsKey(c) && windowCounts[c] == dictT[c]) {
                formed++;
            }

            // Try to contract the window till the point where it ceases to be 'desirable'
            while (l <= r && formed == required) {
                c = s[l];
                
                // Save the smallest window until now
                if (ans[0] == -1 || r - l + 1 < ans[0]) {
                    ans[0] = r - l + 1;
                    ans[1] = l;
                    ans[2] = r;
                }

                // The character at the position pointed by the
                // `left` pointer is no longer a part of the window
                windowCounts[c]--;
                if (dictT.ContainsKey(c) && windowCounts[c] < dictT[c]) {
                    formed--;
                }

                // Move the left pointer ahead
                l++;
            }

            // Keep expanding the window
            r++;
        }

        return ans[0] == -1 ? "" : s.Substring(ans[1], ans[0]);
    }
}
