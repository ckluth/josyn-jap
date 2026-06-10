namespace JOSYN.Jap.Contract;

/// <inheritdoc cref="IErrorReport"/>
public sealed record ErrorReport(
    string  Causer,
    string  Message,
    string? CallStack,
    string? ExceptionDetails,
    DateTimeOffset OccurredAt) : IErrorReport;
