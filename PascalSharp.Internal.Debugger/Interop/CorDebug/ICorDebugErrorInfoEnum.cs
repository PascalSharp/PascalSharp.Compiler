// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2077 $</version>
// </file>

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#pragma warning disable 108, 1591 

namespace PascalSharp.Internal.Debugger.Interop.CorDebug
{
    [ComImport, ComConversionLoss, Guid("F0E18809-72B5-11D2-976F-00A0C9B4D50C"), InterfaceType((short) 1)]
    public interface ICorDebugErrorInfoEnum : ICorDebugEnum
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Skip([In] uint celt);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Reset();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Clone([MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetCount(out uint pcelt);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Next([In] uint celt, [Out] IntPtr errors, out uint pceltFetched);
    }
}

#pragma warning restore 108, 1591