using RPN.Operators;

namespace RPNTest;

[TestFixture]
public class RpnTest {
    private Rpn _sut;
    private OperatorFactory _operatorFactory;
    private BaseSystemConverter _baseSystemConverter;
    [SetUp]
    public void Setup() {
        _operatorFactory = new OperatorFactory();
        _baseSystemConverter = new BaseSystemConverter();
        _sut = new Rpn(_operatorFactory, _baseSystemConverter);
    }
    [Test]
    public void CheckIfTestWorks() {
        Assert.Pass();
    }

    [Test]
    public void CheckIfCanCreateSut() {
        Assert.That(_sut, Is.Not.Null);
    }

    [Test]
    public void SingleDigitOneInputOneReturn() {
        var result = _sut.EvalRpn("D1");

        Assert.That(result, Is.EqualTo(1));

    }
    [Test]
    public void SingleDigitOtherThenOneInputNumberReturn() {
        var result = _sut.EvalRpn("D2");

        Assert.That(result, Is.EqualTo(2));

    }
    [Test]
    public void TwoDigitsNumberInputNumberReturn() {
        var result = _sut.EvalRpn("D12");

        Assert.That(result, Is.EqualTo(12));

    }
    [Test]
    public void TwoNumbersGivenWithoutOperator_ThrowsExcepton() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("D1 2"));

    }
    [Test]
    public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("D1 2 +");

        Assert.That(result, Is.EqualTo(3));
    }
    [Test]
    public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("D2 2 *");

        Assert.That(result, Is.EqualTo(4));
    }
    [Test]
    public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("D1 2 -");

        Assert.That(result, Is.EqualTo(-1));
    }
    [Test]
    public void ComplexExpression() {
        var result = _sut.EvalRpn("D15 7 1 1 + - / 3 * 2 1 1 + + -");

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void OperatorDivide_DivisionByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _sut.EvalRpn("D1 0 /"));
    }

    [Test]
    public void OperatorFactorial_ReturnCorrectResult()
    {
        var result = _sut.EvalRpn("D3 !");
        
        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void OperatorFactorial_ZeroFactorial_ReturnCorrectResult()
    {
        var result = _sut.EvalRpn("D0 !");
        
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void AddingTwoNumbers_Binary_ReturnsCorrentResult()
    {
        var result = _sut.EvalRpn("B101 001 +");
        
        Assert.That(result, Is.EqualTo(6));
    }
    
    [Test]
    public void AddingTwoNumbers_Decimal_ReturnsCorrentResult()
    {
        var result = _sut.EvalRpn("D10 1 +");
        
        Assert.That(result, Is.EqualTo(11));
    }

    [Test]
    public void AddingTwoNumbers_Hex_ReturnsCorrectResult()
    {
        var result = _sut.EvalRpn("#BA D13 +");
        
        Assert.That(result, Is.EqualTo(3533));
    }
    
    [Test]
    public void TwoNumbersGivenWithoutOperator_Binary_ThrowsExcepton() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("B100 101"));
    }
    
    [Test]
    public void TwoNumbersGivenWithoutOperator_Hex_ThrowsExcepton() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("#BA D13"));
    }

    [Test]
    public void AddedOperatorOnTheGo_Decimal_AbsoluteValue()
    {
        IOperator op = new AbsoluteValueOperator();
        _operatorFactory.RegisterOperator("abs", op);
        
        var result = _sut.EvalRpn("D-10 abs");
        Assert.That(result, Is.EqualTo(10));
    }
}