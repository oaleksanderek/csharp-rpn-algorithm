using System;

namespace RPN;

public class Rpn
{
    private readonly MyStack<int> _stack= new MyStack<int>();
    private readonly OperatorFactory _operatorFactory;
    private readonly IBaseSystemConverter _baseSystemConverter;

    public Rpn(OperatorFactory operatorFactory, BaseSystemConverter baseSystemConverter)
    {
        _operatorFactory = operatorFactory;
        _baseSystemConverter = baseSystemConverter;
    }

    public int EvalRpn(String expression)
    {
        String systemSymbol = expression[0].ToString();
        String tokens = expression.Substring(1, expression.Length - 1);
        int systemDecimalRepresentation = _baseSystemConverter.GetBaseSystemDecimalRepresentation(systemSymbol);
        bool singleToken = tokens.Split(" ").Length == 1;
        
        if (tokens.Split(" ").Length == 0)
        {
            throw new ArgumentException("Invalid expression");
        }
        
        foreach (var token in tokens.Split(" "))
        {
            try
            {
                var op = _operatorFactory.GetOperator(token);
                op.Apply(_stack);
            }
            catch (ArgumentException)
            {
                int parsedNumber = _baseSystemConverter.ParseSystem(token, systemDecimalRepresentation);
                if (singleToken)
                {
                    return parsedNumber;
                }
                Console.WriteLine(parsedNumber);
                _stack.Push(parsedNumber);
            }
        }
        var result = _stack.Pop();
        if (_stack.IsEmpty)
        {
            return result;
        }

        throw new InvalidOperationException();
    }
}