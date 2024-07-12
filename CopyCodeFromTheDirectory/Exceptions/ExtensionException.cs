namespace CopyCodeFromTheDirectory.Exceptions;

internal class ExtensionException : ArgumentException
{
    public ExtensionException(string message) : base(message) { }
}
