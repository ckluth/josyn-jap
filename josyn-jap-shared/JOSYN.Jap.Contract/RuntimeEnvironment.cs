namespace JOSYN.Jap.Contract;

/// <summary>
/// Represents the different environments in which the application can run.
/// </summary>
public enum RuntimeEnvironment
{
    /// <summary>
    /// The development environment.
    /// </summary>
    DEV = 0,
    
    /// <summary>
    /// The integration environment.
    /// </summary>

    INT = 1,
    
    /// <summary>
    /// The production environment.
    /// </summary>
    PROD = 2,
}