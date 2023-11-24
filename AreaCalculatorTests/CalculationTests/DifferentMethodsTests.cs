using AreaCalculator.Shapes;

namespace AreaCalculatorTests.CalculatorTests;

public class DifferentMethodsTests
{
    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(30, 41, 56, false)]
    public void CheckIfTriangleIsRightWorksCorrectly(double a, double b, double c, bool expected)
    {
        // Arrange
        var triangle = new Triangle(a, b, c);
        
        // Act
        var isRightTriangle = triangle.CheckIfTriangleIsRight();
        
        // Assert
        Assert.True(expected == isRightTriangle);
    }
}