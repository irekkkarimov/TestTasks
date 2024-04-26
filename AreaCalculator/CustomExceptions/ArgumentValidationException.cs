using AreaCalculator.CustomExceptions.Abstractions;

namespace AreaCalculator.CustomExceptions;

public class ArgumentValidationException : ShapeException
{
    public ArgumentValidationException(string message) : base(message)
    {
    }
}