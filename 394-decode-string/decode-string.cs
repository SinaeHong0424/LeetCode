
public class Solution {
    public string DecodeString(string s) {
        Stack<int> counts = new Stack<int>();
        Stack<string> resultStack = new Stack<string>();
        string result = "";
        int index = 0;

        while (index < s.Length) {
            if (Char.IsDigit(s[index])) {
                int count = 0;
                while (Char.IsDigit(s[index])) {
                    count = 10 * count + (s[index] - '0');
                    index++;
                }
                counts.Push(count);
                resultStack.Push(result);
                result = "";
                index++;
            } else if (s[index] == ']') {
                StringBuilder temp = new StringBuilder(resultStack.Pop());
                int repeatTimes = counts.Pop();
                for (int i = 0; i < repeatTimes; i++) {
                    temp.Append(result);
                }
                result = temp.ToString();
                index++;
            } else {
                result += s[index];
                index++;
            }
        }

        return result;
    }
}