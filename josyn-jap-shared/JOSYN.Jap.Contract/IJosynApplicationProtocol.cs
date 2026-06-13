using JOSYN.Foundation.ResultPattern;

namespace JOSYN.Jap.Contract;

/// <summary>
/// Contract definition for the JOSYN Application Protocol (JAP).
/// Describes the communication between the <b>JobHost</b> (frontend) and
/// the <b>JAPServer</b> (backend) at the application layer — independent of
/// the transport mechanism.
/// <para>
/// Session start negotiation: <c>JobHost</c> calls <see cref="AcceptSession"/> or
/// <see cref="RejectSession"/> as the very first exchange, before any other call.
/// </para>
/// <para>
/// Job execution: <c>JobHost</c> retrieves <see cref="GetRawArguments"/>,
/// executes the job, and submits the result via <see cref="PutRawResult"/> or
/// <see cref="PutDomainError"/> — or reports an infrastructure error via <see cref="PutError"/>.
/// </para>
/// </summary>
public interface IJosynApplicationProtocol
{
    // -------------------------------------------------------------------------
    // Session start negotiation (ADR-008)
    // Must be the first exchange in every session, before GetRawArguments.
    // -------------------------------------------------------------------------

    /// <summary>
    /// Signals that the job accepts the session. Execution proceeds normally.
    /// JAPServer transitions <c>ExecutionStatus</c> from <c>preparing</c> to <c>running</c>.
    /// </summary>
    Task<Result> AcceptSession();

    /// <summary>
    /// Signals that the job rejects the session. Execution does not proceed.
    /// JAPServer transitions <c>ExecutionStatus</c> from <c>preparing</c> to <c>finished-rejected</c>.
    /// </summary>
    Task<Result> RejectSession();

    /// <summary>
    /// Returns the raw arguments of all currently running sessions of the same job type,
    /// excluding the session being started, as a JSON-serialized <c>string[]</c>.
    /// Used by <c>JobHost</c> to evaluate a conditional parallel-execution policy (ADR-008).
    /// Returns a JSON empty array (<c>"[]"</c>) when no sibling sessions are running.
    /// </summary>
    Task<Result<string>> GetConcurrentSessionArguments();

    // -------------------------------------------------------------------------
    // Job execution
    // -------------------------------------------------------------------------

    /// <summary>
    /// Retrieves the serialized job arguments as a raw string.
    /// The caller is responsible for deserialization.
    /// </summary>
    /// <returns>
    /// Serialized argument string on success;
    /// failure if no arguments are available or the transport fails.
    /// </returns>
    Task<Result<string>> GetRawArguments();

    /// <summary>
    /// Submits the job result as a serialized string.
    /// The caller is responsible for serialization.
    /// JAPServer sets <c>ExecutionStatus</c> to <c>finished-successfully</c>.
    /// </summary>
    /// <param name="result">Serialized job result.</param>
    /// <returns>
    /// Successful when the result has been submitted;
    /// failure if the transport fails.
    /// </returns>
    Task<Result> PutRawResult(string result);

    /// <summary>
    /// Reports a domain-level error outcome. The job ran to completion but its
    /// subject-matter conclusion is negative.
    /// JAPServer sets <c>ExecutionStatus</c> to <c>finished-with-errors</c>.
    /// The optional <paramref name="description"/> carries a human-readable summary
    /// for diagnostics — it is not a job result record.
    /// </summary>
    /// <param name="description">Optional human-readable description of the domain error.</param>
    Task<Result> PutDomainError(string? description = null);

    /// <summary>
    /// Submits an error that occurred as a serialized <see cref="ErrorReport"/>.
    /// Serves for error logging on the server side.
    /// JAPServer sets <c>ExecutionStatus</c> to <c>finished-faulted</c>.
    /// If the transport itself fails, the error remains in the caller's local log.
    /// </summary>
    /// <param name="serializedError">A <see cref="ErrorReport"/> serialized via PropertyBag.</param>
    Task<Result> PutError(string serializedError);

    /// <summary>
    /// Retrieves the current environment in which the application is running.
    /// </summary>
    Task<Result<RuntimeEnvironment>> GetEnvironment();
}

