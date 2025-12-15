namespace RPN.Operators;

public class AbsoluteValueOperator : IOperator
{
    public void Apply(MyStack<int> stack)
    {
        int x = stack.Pop();
        stack.Push(Math.Abs(x));
    }
}