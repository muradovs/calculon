// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the Log type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Lib
{
  using System;

  /// <summary>
  /// The log.
  /// </summary>
  public class Log
  {
    /// <summary>
    /// The lazy.
    /// </summary>
    private static readonly Lazy<Log> Lazy =
        new Lazy<Log>(() => new Log());

    /// <summary>
    /// Gets the instance.
    /// </summary>
    private static Log Instance
    {
      get
      {
        return Lazy.Value;
      }
    }

    /// <summary>
    /// The error.
    /// </summary>
    /// <param name="ex">
    /// The ex.
    /// </param>
    /// <param name="message">
    /// The message.
    /// </param>
    public static void Error(Exception ex, string message)
    {
      Instance.ErrorLocal(ex, message);
    }

    /// <summary>
    /// The error.
    /// </summary>
    /// <param name="ex">
    /// The ex.
    /// </param>
    public static void Error(Exception ex)
    {
      Instance.ErrorLocal(ex);
    }

    /// <summary>
    /// The trace.
    /// </summary>
    /// <param name="message">
    /// The message.
    /// </param>
    public static void Trace(string message)
    {
      Instance.TraceLocal(message);
    }

    /// <summary>
    /// The trace local.
    /// </summary>
    /// <param name="message">
    /// The message.
    /// </param>
    private void TraceLocal(string message)
    {
    }

    /// <summary>
    /// The error local.
    /// </summary>
    /// <param name="ex">
    /// The ex.
    /// </param>
    /// <param name="message">
    /// The message.
    /// </param>
    private void ErrorLocal(Exception ex, string message)
    {
    }

    /// <summary>
    /// The error local.
    /// </summary>
    /// <param name="ex">
    /// The ex.
    /// </param>
    private void ErrorLocal(Exception ex)
    {
      this.ErrorLocal(ex, string.Empty);
    }
  }
}