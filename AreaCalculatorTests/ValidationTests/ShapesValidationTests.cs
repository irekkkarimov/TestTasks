using AreaCalculator.CustomExceptions;
using AreaCalculator.CustomExceptions.Messages;
using AreaCalculator.Shapes;

namespace AreaCalculatorTests.ValidationTests;

/// <summary>
/// Tests for shape creation arguments validation
/// </summary>
public class ShapesValidationTests
{
    [Theory]
    [InlineData(new double[] { 10, 2, 3 }, ShapeExceptionMessages.OneSideLengthGreaterThanSumOfOthers)]
    [InlineData(new double[] { 0, 1, 2 }, ShapeExceptionMessages.SideLengthIsLessThanOrEqualZero)]
    [InlineData(new double[] { -1, 1, 1 }, ShapeExceptionMessages.SideLengthIsLessThanOrEqualZero)]
    public void TriangleArgumentsValidationThrowsException(double[] args, string exceptionMessage)
    {
        // Arrange, Act
        var exception = Assert.Throws<ArgumentValidationException>(() => new Triangle(args));

        // Assert
        Assert.Equal(exceptionMessage, exception.Message);
    }

    [Theory]
    [InlineData(new double[] { }, ShapeExceptionMessages.TriangleCreationWithNotThreeArguments)]
    [InlineData(new double[] { 1 }, ShapeExceptionMessages.TriangleCreationWithNotThreeArguments)]
    [InlineData(new double[] { 1, 2 }, ShapeExceptionMessages.TriangleCreationWithNotThreeArguments)]
    [InlineData(new double[] { 1, 2, 3, 4 }, ShapeExceptionMessages.TriangleCreationWithNotThreeArguments)]
    public void TriangleArgumentCountThrowsException(double[] args, string exceptionMessage)
    {
        // Arrange, Act
        var exception = Assert.Throws<ArgumentCountException>(() => new Triangle(args));

        // Assert
        Assert.Equal(exceptionMessage, exception.Message);
    }
}