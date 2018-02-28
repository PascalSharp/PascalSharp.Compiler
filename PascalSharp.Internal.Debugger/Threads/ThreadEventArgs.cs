// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2274 $</version>
// </file>

using System;
using PascalSharp.Internal.Debugger.Tests;

namespace PascalSharp.Internal.Debugger.Threads 
{	
	[Serializable]
	public class ThreadEventArgs : ProcessEventArgs
	{
		Thread thread;
		
		[Ignore]
		public Thread Thread {
			get {
				return thread;
			}
		}
		
		public ThreadEventArgs(Thread thread): base(thread.Process)
		{
			this.thread = thread;
		}
	}
}
