using AreaCalculator.Handlers;
using AreaCalculator.Shapes;
using AreaCalculatorTests.Utils;

namespace AreaCalculatorTests.ValidationTests;

public class ShapesValidationTests
{
    [Theory]
    [InlineData(new double[] { 1, 2 }, ExceptionMessages.NoShapeImplemented)]
    [InlineData(new double[] { }, ExceptionMessages.NoParameters)]
    public void AreaCalculatorGenericValidationThrowsException(double[] args, string exceptionMessage)
    {
        // Arrange, Act
        var exception = Assert.Throws<Exception>(() => AreaCalculatorGeneric.CalculateArea(args));

        // Assert
        Assert.Equal(exceptionMessage, exception.Message);
    }
    
    [Theory]
    [InlineData(new double[] { 10, 2, 3 }, ExceptionMessages.OneSideLengthGreaterThanSumOfOthers)]
    [InlineData(new double[] { 0, 1, 2 }, ExceptionMessages.SideLengthIsLessThanOrEqualZero)]
    [InlineData(new double[] { -1, 1, 1 }, ExceptionMessages.SideLengthIsLessThanOrEqualZero)]
    [InlineData(new double[] { 1, 2 }, ExceptionMessages.TriangleCreationWithNotThreeArguments)]
    public void TriangleValidationThrowsException(double[] args, string exceptionMessage)
    {
        // Arrange, Act
        var exception = Assert.Throws<Exception>(() => new Triangle(args));
        
        // Assert
        Assert.Equal(exceptionMessage, exception.Message);
    }

    [Theory]
    [InlineData(new double[] { 0 }, ExceptionMessages.RadiusIsLessThanOrEqualZero)]
    [InlineData(new double[] { -1 }, ExceptionMessages.RadiusIsLessThanOrEqualZero)]
    [InlineData(new double[] { }, ExceptionMessages.CircleCreationWithNotOneArgument)]
    public void CircleValidationThrowsException(double[] args, string exceptionMessage)
    {
        // Arrange, Act
        var exception = Assert.Throws<Exception>(() => new Circle(args));
        
        // Assert
        Assert.Equal(exceptionMessage, exception.Message);
    }
}