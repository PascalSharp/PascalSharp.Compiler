// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 1687 $</version>
// </file>

using System;
using PascalSharp.Internal.Debugger.Threads;

namespace PascalSharp.Internal.Debugger.Modules 
{	
	[Serializable]
	public class ModuleEventArgs : ProcessEventArgs
	{
		Module module;
		
		public Module Module {
			get {
				return module;
			}
		}
		
		public ModuleEventArgs(Module module): base(module.Process)
		{
			this.module = module;
		}
	}
}
