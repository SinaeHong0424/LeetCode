public class Solution {
    public int LengthOfLastWord(string s) {
        s = s.Trim();
        
        string[] words = s.Split(' ');
        
        return words[words.Length - 1].Length;
    }
}
