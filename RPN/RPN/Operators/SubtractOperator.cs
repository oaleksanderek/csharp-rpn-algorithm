namespace RPN.Operators;

public class SubtractOperator : IOperator
{
    public void Apply(MyStack<int> stack)
    {
        int x = stack.Pop();
        int y = stack.Pop();
        stack.Push(y - x);
    }
}