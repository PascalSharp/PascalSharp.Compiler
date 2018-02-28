// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 1687 $</version>
// </file>

using System;
using PascalSharp.Internal.Debugger.Threads;

namespace PascalSharp.Internal.Debugger.Debugger
{
	public interface IMutable
	{
		event EventHandler<ProcessEventArgs> Changed;
	}
}
