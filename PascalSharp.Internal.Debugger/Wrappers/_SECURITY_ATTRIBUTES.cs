// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2077 $</version>
// </file>

using System;

#pragma warning disable 1591

namespace PascalSharp.Internal.Debugger.Wrappers
{
    public static class _SECURITY_ATTRIBUTES
	{
		public static Interop.CorDebug._SECURITY_ATTRIBUTES Default;
		
		static unsafe _SECURITY_ATTRIBUTES() {
			Default = new Interop.CorDebug._SECURITY_ATTRIBUTES();
			Default.bInheritHandle = 0;
			Default.lpSecurityDescriptor = IntPtr.Zero;
			Default.nLength = (uint)sizeof(Interop.CorDebug._SECURITY_ATTRIBUTES);
		}
	}
}

#pragma warning restore 1591
