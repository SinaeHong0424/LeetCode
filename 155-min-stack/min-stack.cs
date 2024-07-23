public class MinStack
{
    private Stack<int> stack;
    private Stack<int> minStack;

    // Constructor initializes the stack and minStack
    public MinStack()
    {
        stack = new Stack<int>();
        minStack = new Stack<int>();
    }
    
    // Pushes the element val onto the stack
    public void Push(int val)
    {
        stack.Push(val);
        // Push onto minStack if it's empty or the new value is smaller than or equal to the current minimum
        if (minStack.Count == 0 || val <= minStack.Peek())
        {
            minStack.Push(val);
        }
    }
    
    // Removes the element on the top of the stack
    public void Pop()
    {
        // If the top of stack and minStack are the same, pop from minStack as well
        if (stack.Peek() == minStack.Peek())
        {
            minStack.Pop();
        }
        stack.Pop();
    }
    
    // Gets the top element of the stack
    public int Top()
    {
        return stack.Peek();
    }
    
    // Retrieves the minimum element in the stack
    public int GetMin()
    {
        return minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
