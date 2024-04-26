namespace AreaCalculator.CustomExceptions.Abstractions;

/// <summary>
/// Custom exception of the application
/// </summary>
public class ShapeException : ArgumentException
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="message">The message of the exception</param>
    public ShapeException(string message) : base(message)
    {
    }
}