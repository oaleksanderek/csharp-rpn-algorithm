namespace RPN.Operators;

public class DivideOperator : IOperator
{
    public void Apply(MyStack<int> stack)
    {
        int x = stack.Pop();
        int y = stack.Pop();
        if (x == 0)
        {
            throw new DivideByZeroException("Cannot divide by 0");
        }
        stack.Push(y / x);
    }
}