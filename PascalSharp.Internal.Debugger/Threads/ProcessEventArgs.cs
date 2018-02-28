// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2274 $</version>
// </file>

using System;
using PascalSharp.Internal.Debugger.Debugger.DebuggerEvents;
using PascalSharp.Internal.Debugger.Tests;

namespace PascalSharp.Internal.Debugger.Threads
{
	[Serializable]
	public class ProcessEventArgs: DebuggerEventArgs
	{
		Process process;
		
		[Ignore]
		public Process Process {
			get {
				return process;
			}
		}

		public ProcessEventArgs(Process process): base(process == null ? null : process.Debugger)
		{
			this.process = process;
		}
	}
}
