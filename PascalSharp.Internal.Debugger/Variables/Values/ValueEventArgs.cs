﻿// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2185 $</version>
// </file>

using System;
using PascalSharp.Internal.Debugger.Threads;

namespace PascalSharp.Internal.Debugger.Variables.Values 
{	
	/// <summary>
	/// Provides data for events related to <see cref="Values.Value"/> class
	/// </summary>
	[Serializable]
	public class ValueEventArgs : ProcessEventArgs
	{
		Value val;
		
		/// <summary> The value that caused the event </summary>
		public Value Value {
			get {
				return val;
			}
		}
		
		/// <summary> Initializes a new instance of the class </summary>
		public ValueEventArgs(Value val): base(val.Process)
		{
			this.val = val;
		}
	}
}
