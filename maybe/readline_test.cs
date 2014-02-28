using System;
using System.Threading; // for ThreadPool
using System.Runtime.InteropServices; // for DllImport

namespace IntroCS
{

	class Timed_ReadLine // this program only works on Windows!
	{
		static void Main(string[] args)
		{
			int seconds = 4; // number of seconds to wait for user input
			Console.WriteLine ("Enter a response within {0} seconds:", seconds);
			string response = TimedReadLine (seconds); // try getting a response
			if (response == null)
				Console.WriteLine ("no response, ReadLine timed out");
			else
				Console.WriteLine ("response was \"{0}\"", response);
			Console.WriteLine ();

			seconds = 8;
			Console.WriteLine ("Enter a response within {0} seconds:", seconds);
			response = TimedReadLine (seconds); // try getting another response
			if (response == null)
				Console.WriteLine ("no response, ReadLine timed out");
			else
				Console.WriteLine ("response was \"{0}\"", response);
			Console.WriteLine ();

			seconds = 3;
			Console.WriteLine ("Enter a response within {0} seconds:", seconds);
			response = TimedReadLine (seconds); // try getting a third response
			if (response == null)
				Console.WriteLine ("no response, ReadLine timed out");
			else
				Console.WriteLine ("response was \"{0}\"", response);
		}

		/// <summary>
		/// mechanisms to send an Enter keypress to Console.ReadLine on timeout
		/// </summary>

		private const int VK_ENTER = 0x0D; // Enter key value
		private const int WM_KEYDOWN = 0x100; // indicator that a key was pressed

		internal static class NativeMethods // encapsulate the two Windows external methods we're using
		{
			[DllImport("kernel32.dll")]
			internal static extern IntPtr GetConsoleWindow();
			// a method to return the window handle for the Console window (first parameter to PostMessage)

			[DllImport("User32.Dll", EntryPoint = "PostMessageA")]
			internal static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
			// a method to send a keystroke to Console.ReadLine (an Enter character, in this case)
		}
		
		private static IntPtr hWnd = NativeMethods.GetConsoleWindow(); 
		// get a window handle for the Console window - assume this works

		/// enum to track status of the timed ReadLine
		private enum ReadStatus {
			Waiting, 	// waiting for user input
			Aborted		// ReadLine aborted due to timeout
		}

		/// <summary>
		/// Returns the result of Console.ReadLine, but times out if no response.
		/// </summary>
		/// <returns>The read line as a string or null if ReadLine times out.</returns>
		/// <param name="seconds">Number of seconds until timeout occurs.</param>
		/// <param name="timer">If set to <c>true</c> then count down the seconds until timeout.</param>
		static string TimedReadLine(int seconds)
		{
			var lockObject = new Object (); // lock for the reading status
			ReadStatus status = ReadStatus.Waiting; // initial status is waiting for user input
			string result = null; // indicates no user input seen so far

			int timeout = seconds * 10; // number of 100 millesecond intervals in the timeout seconds
			ThreadPool.QueueUserWorkItem((o) => // background thread to time the ReadLine
			{
				for (int i = 0; i < timeout && result == null; i++) // stop this thread if we have user input!
				{
					Thread.Sleep(100); // sleep for 100 milleseconds each iteration
					// we're waiting to see if Console.ReadLine returned a response from the user
				}

				// at this point we either timed out or else we detected that we've received user input

				if (result == null) // it looks like we were still waiting for user input and we timed out
				{
					Thread.Sleep (10); // try to eliminate one possible race condition (see below)
					// this will hopefully give a pending assignment to variable result time to complete ...
				} // this may be overkill, and it still doesn't completely prevent all race conditions

				lock(lockObject) // lock status
				{
					if (result == null) // test result a second time to see if it's been assigned a value
					{
						// it seems we were in fact still waiting for user input, so this is a valid timeout
						status = ReadStatus.Aborted; // indicate that we aborted the ReadLine
						NativeMethods.PostMessage(hWnd, WM_KEYDOWN, VK_ENTER, 0);
						// send an Enter keypress to Console.ReadLine to get it to return - assume this works

						// Note: a side effect of this is that a blank line will appear on the Console
						// when timeout occurs! The caller should probably be aware of this ...
					} 
					// if we have received a user response (result != null), don't send an Enter keypress,
					// just let this background thread expire ...
				}
			});

			result = Console.ReadLine(); // try to read from the keyboard and assign the user's response to result
			// now we either have a valid user response or an empty string sent by the background thread on timeout

			lock (lockObject)  // lock status
			{
				if (status == ReadStatus.Aborted) // indicates that the background thread timed out
					return null; // tell that to the caller - there's nothing to return
				return result; // otherwise return the valid user response
			}
			// Note: there is one possible race condition - if the background thread's timeout occurs between when
			// ReadLine returns a response and when it is assigned to result, an extra Enter keypress might be sent.
			// As far as I can tell, there is no way to tell that this has happened, because an empty string is a
			// valid user response returned by ReadLine; however, the window for this race condition is very small,
			// and the extra Thread.Sleep(10) in the background thread may allow a pending assignment to complete.
			// (Of course, that Sleep could interrupt a Console.ReadLine that starts to return after the timeout.)
		}
	}
}