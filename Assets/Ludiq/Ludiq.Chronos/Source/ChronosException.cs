using System;

namespace RewindEngine
{
	/// <summary>
	/// An exception thrown by the Chronos plugin.
	/// </summary>
	public class ChronosException : Exception
	{
		public ChronosException() : base() { }
		public ChronosException(string message) : base(message) { }
		public ChronosException(string message, Exception innerException) : base(message, innerException) { }
	}
}
