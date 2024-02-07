namespace TaskFileCopy.EnumHolder
{
    /// <summary>
    /// Enum used for error codes.
    /// </summary>
    enum ErrorCodes
    {
        UnauthorizedAccessException = 1,
        IOException = 2,
        ArgumentException = 3,
        NotSupportedException = 4,
        ObjectDisposedException = 5,
        DirectoryNotExist = 6,
        DirectoryHasNotPermission = 7,
        DirectoryIsEmpty = 8,
        FileNotExist = 9,
        FileHasNotPermission = 10,
        InvalidInput = 11,
        UndefinedException = 12,
        ArgumentNullException = 13,
    }
}