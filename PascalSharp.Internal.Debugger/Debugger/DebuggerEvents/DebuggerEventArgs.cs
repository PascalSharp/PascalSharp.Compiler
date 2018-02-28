// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 915 $</version>
// </file>

using System;

namespace PascalSharp.Internal.Debugger.Debugger.DebuggerEvents 
{	
	[Serializable]
	public class DebuggerEventArgs : EventArgs 
	{
		NDebugger debugger;

		public NDebugger Debugger {
			get {
				return debugger;
			}
		}

		public DebuggerEventArgs(NDebugger debugger)
		{
			this.debugger = debugger;
		}
	}
}
