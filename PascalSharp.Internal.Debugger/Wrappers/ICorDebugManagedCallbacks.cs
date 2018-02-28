// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2077 $</version>
// </file>

using PascalSharp.Internal.Debugger.Interop.CorDebug;

#pragma warning disable 1591

namespace PascalSharp.Internal.Debugger.Wrappers
{
    public interface ICorDebugManagedCallbacks: ICorDebugManagedCallback, ICorDebugManagedCallback2
	{
		
	}
}

#pragma warning restore 1591
