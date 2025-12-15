namespace RPN;

public interface IBaseSystemConverter
{
    public int GetBaseSystemDecimalRepresentation(String systemSymbol);
    public int ParseSystem(String token, int decimalRepresentation);
}