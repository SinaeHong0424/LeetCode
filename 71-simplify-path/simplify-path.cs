public class Solution {
    public string SimplifyPath(string path) {
        // Split the input path by '/'.
        var parts = path.Split('/');
        var stack = new Stack<string>();

        // Iterate over each part of the split path.
        foreach (var part in parts) {
            if (part == "" || part == ".") {
                // Ignore empty parts and current directory indicators.
                continue;
            }
            if (part == "..") {
                // Pop from stack if we need to go up one level.
                if (stack.Count > 0) {
                    stack.Pop();
                }
            } else {
                // Push the valid directory/file name onto the stack.
                stack.Push(part);
            }
        }

        // Construct the canonical path from the stack.
        var result = new List<string>(stack);
        result.Reverse(); // Because stack is LIFO, we need to reverse to get the correct order.

        return "/" + string.Join("/", result);
    }
}
