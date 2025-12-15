namespace RPN.Operators;

public class FactorialOperator : IOperator
{
    public void Apply(MyStack<int> stack)
    {
        int x = stack.Pop();
        if (x == 0)
        {
            stack.Push(1);
            return;
        }

        int result = 1;
        for (var i = x; i >= 1; i--)
        {
            result *= i;
        }
        stack.Push(result);
    }
}