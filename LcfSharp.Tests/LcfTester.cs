using System.Diagnostics;

namespace LcfSharp.Tests
{
    public abstract class LcfTester
    {
        // Static Stopwatch shared across all tests
        protected static readonly Stopwatch Stopwatch = new Stopwatch( );

        /// <summary>
        /// Executes the given action and measures its execution time.
        /// </summary>
        /// <param name="action">The action to be executed.</param>
        public void ExecuteWithTiming( Action action )
        {
            Stopwatch.Restart( ); // Start or restart the stopwatch
            action( ); // Execute the action
            Stopwatch.Stop( ); // Stop the stopwatch
            Trace.WriteLine( $"Execution Time: {Stopwatch.ElapsedMilliseconds} ms" );
        }

        /// <summary>
        /// Executes the given function, measures its execution time, and returns the result.
        /// </summary>
        /// <typeparam name="T">The type of the result returned by the function.</typeparam>
        /// <param name="func">The function to be executed.</param>
        /// <returns>The result of the function execution.</returns>
        public T ExecuteWithTiming<T>( Func<T> func )
        {
            Stopwatch.Restart( ); // Start or restart the stopwatch
            T result = func( ); // Execute the function and get the result
            Stopwatch.Stop( ); // Stop the stopwatch
            Trace.WriteLine( $"Execution Time: {Stopwatch.ElapsedMilliseconds} ms" );
            return result; // Return the result
        }
    }
}
