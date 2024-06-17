public class Solution {
    public int StrStr(string haystack, string needle) {
        if (needle.Length == 0) {
            return 0;
        }

        int index = haystack.IndexOf(needle);

        return index;
    }
}
