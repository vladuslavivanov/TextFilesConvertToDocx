namespace CopyCodeFromTheDirectory.Exceptions;

internal class NotAnEmptyFileException : ArgumentException{
    public NotAnEmptyFileException(string message) : base(message) { }
}
