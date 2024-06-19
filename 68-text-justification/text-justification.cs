
public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        var result = new List<string>();
        int index = 0;
        
        while (index < words.Length) {
            int totalChars = words[index].Length;
            int last = index + 1;
            while (last < words.Length) {
                if (totalChars + 1 + words[last].Length > maxWidth) break;
                totalChars += 1 + words[last].Length;
                last++;
            }
            
            StringBuilder line = new StringBuilder();
            int numOfWords = last - index;
            if (last == words.Length || numOfWords == 1) {
                for (int i = index; i < last; i++) {
                    line.Append(words[i]);
                    if (i < last - 1) line.Append(' ');
                }
                for (int i = line.Length; i < maxWidth; i++) {
                    line.Append(' ');
                }
            } else {
                int spaces = (maxWidth - totalChars) / (numOfWords - 1);
                int extraSpaces = (maxWidth - totalChars) % (numOfWords - 1);
                
                for (int i = index; i < last; i++) {
                    line.Append(words[i]);
                    if (i < last - 1) {
                        int spaceToApply = spaces + (i - index < extraSpaces ? 1 : 0);
                        for (int j = 0; j <= spaceToApply; j++) {
                            line.Append(' ');
                        }
                    }
                }
            }
            result.Add(line.ToString());
            index = last;
        }
        
        return result;
    }
}
