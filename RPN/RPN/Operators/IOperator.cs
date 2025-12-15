namespace RPN.Operators;

public interface IOperator
{
    void Apply(MyStack<int> stack);
}