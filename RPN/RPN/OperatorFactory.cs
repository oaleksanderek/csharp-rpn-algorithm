using RPN.Operators;

namespace RPN;

public class OperatorFactory
{
    private readonly Dictionary<string, IOperator> _operators = new();

    public OperatorFactory()
    {
        RegisterOperator("+", new AddOperator());
        RegisterOperator("-", new SubtractOperator());
        RegisterOperator("*", new MultiplyOperator());
        RegisterOperator("/", new DivideOperator());
        RegisterOperator("!", new FactorialOperator());
    }

    public void RegisterOperator(string operationSymbol, IOperator op)
    {
        _operators[operationSymbol] = op;
    }

    public IOperator GetOperator(string operationSymbol)
    {
        if (_operators.TryGetValue(operationSymbol, out var result))
        {
            return _operators[operationSymbol];
        }
        throw new ArgumentException($"Unknown operator: {operationSymbol}");
    }
}