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
    [ComImport, Guid("E3AC4D6C-9CB7-43E6-96CC-B21540E5083C"), InterfaceType((short) 1)]
    public interface ICorDebugHeapValue2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateHandle([In] CorDebugHandleType type, [MarshalAs(UnmanagedType.Interface)] out ICorDebugHandleValue ppHandle);
    }
}

#pragma warning restore 108, 1591