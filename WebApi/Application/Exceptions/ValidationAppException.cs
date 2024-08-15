namespace WebApi.Application.Exceptions;

public class ValidationAppException : Exception
{
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    public ValidationAppException(IReadOnlyDictionary<string, string[]> errors)
        : base("Ocurrió un error con una o más validaciones.")
    {
        Errors = errors;
    }
}
