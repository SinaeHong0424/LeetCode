public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        // Dictionary to hold the grouped anagrams
        Dictionary<string, List<string>> anagramGroups = new Dictionary<string, List<string>>();

        foreach (string str in strs) {
            // Sort the characters in the string to form the key
            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            string sortedStr = new string(charArray);

            // Add the string to the corresponding group in the dictionary
            if (!anagramGroups.ContainsKey(sortedStr)) {
                anagramGroups[sortedStr] = new List<string>();
            }
            anagramGroups[sortedStr].Add(str);
        }

        // Convert the dictionary values to a list of lists and return
        return anagramGroups.Values.Select(group => (IList<string>)group).ToList();
    }
}
