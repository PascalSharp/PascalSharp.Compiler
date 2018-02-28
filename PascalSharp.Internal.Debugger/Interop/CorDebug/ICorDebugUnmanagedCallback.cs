// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2077 $</version>
// </file>

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 108, 1591 

namespace PascalSharp.Internal.Debugger.Interop.CorDebug
{
    [ComImport, Guid("5263E909-8CB5-11D3-BD2F-0000F80849BD"), InterfaceType((short) 1)]
    public interface ICorDebugUnmanagedCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void DebugEvent([In, ComAliasName("Debugger.Interop.CorDebug.ULONG_PTR")] uint pDebugEvent, [In] int fOutOfBand);
    }
}

#pragma warning restore 108, 1591