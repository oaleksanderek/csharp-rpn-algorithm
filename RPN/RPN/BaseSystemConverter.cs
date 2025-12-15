

using System.Globalization;

namespace RPN;

public class BaseSystemConverter : IBaseSystemConverter
{
    private readonly Dictionary<String, int> _systems = new();

    public BaseSystemConverter()
    {
        RegisterBaseSystem("B", 2);
        RegisterBaseSystem("D", 10);
        RegisterBaseSystem("#", 16);
    }

    public void RegisterBaseSystem(String systemSymbol, int decimalRepresentation)
    {
        _systems[systemSymbol] = decimalRepresentation;
    }

    public int GetBaseSystemDecimalRepresentation(String systemSymbol)
    {
        if (_systems.ContainsKey(systemSymbol))
        {
            return _systems[systemSymbol];
        }
        throw new NotImplementedException("This base system was not implemented yet.");
    }

    public int ParseSystem(String token, int decimalRepresentation)
    {
        try
        {
            return Convert.ToInt32(token, decimalRepresentation);
        }
        catch (FormatException)
        {
            throw new FormatException("Token doesn't have a correct format.");
        }
    }
}