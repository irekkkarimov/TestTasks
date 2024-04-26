namespace AreaCalculator.CustomExceptions.Messages;

public static class ShapeExceptionMessages
{
    public const string OneSideLengthGreaterThanSumOfOthers = "One side's length is greater than the sum of others";
    public const string SideLengthIsLessThanOrEqualZero = "All sides should be greater than zero";
    public const string RadiusIsLessThanOrEqualZero = "Radius must be greater than zero";
    public const string TriangleCreationWithNotThreeArguments = "Triangle should have 3 sides!";
}