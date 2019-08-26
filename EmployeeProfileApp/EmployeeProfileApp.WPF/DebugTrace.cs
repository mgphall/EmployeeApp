namespace EmployeeProfileApp.WPF
{
    using System;
    using System.Diagnostics;
    using MvvmCross.Platform.Platform;
  
    /// <summary>
    /// Debug Trace
    /// </summary>
    /// <seealso cref="MvvmCross.Platform.Platform.IMvxTrace" />
    public class DebugTrace : IMvxTrace
    {
        /// <summary>
        /// Traces the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="message">The message.</param>
        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message());
        }

        /// <summary>
        /// Traces the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="message">The message.</param>
        public void Trace(MvxTraceLevel level, string tag, string message)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message);
        }

        /// <summary>
        /// Traces the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            try
            {
                Debug.WriteLine(tag + ":" + level + ":" + message, args);
            }
            catch (FormatException)
            {
                this.Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1}", level, message);
            }
        }
    }
}
