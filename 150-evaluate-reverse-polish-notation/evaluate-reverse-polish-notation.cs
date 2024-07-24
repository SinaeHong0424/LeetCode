public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        
        foreach (string token in tokens) {
            if (IsOperator(token)) {
                int rightOperand = stack.Pop();
                int leftOperand = stack.Pop();
                int result = PerformOperation(leftOperand, rightOperand, token);
                stack.Push(result);
            } else {
                stack.Push(int.Parse(token));
            }
        }
        
        return stack.Pop();
    }

    private bool IsOperator(string token) {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

    private int PerformOperation(int leftOperand, int rightOperand, string operatorToken) {
        switch (operatorToken) {
            case "+":
                return leftOperand + rightOperand;
            case "-":
                return leftOperand - rightOperand;
            case "*":
                return leftOperand * rightOperand;
            case "/":
                return leftOperand / rightOperand;
            default:
                throw new ArgumentException("Invalid operator");
        }
    }
}
