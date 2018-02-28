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
    [ComImport, Guid("5E0B54E7-D88A-4626-9420-A691E0A78B49"), InterfaceType((short) 1)]
    public interface ICorDebugValue2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetExactType([MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);
    }
}

#pragma warning restore 108, 1591