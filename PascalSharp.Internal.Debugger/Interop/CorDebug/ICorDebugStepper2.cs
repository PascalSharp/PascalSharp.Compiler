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
    [ComImport, InterfaceType((short) 1), Guid("C5B6E9C3-E7D1-4A8E-873B-7F047F0706F7")]
    public interface ICorDebugStepper2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void SetJMC([In] int fIsJMCStepper);
    }
}

#pragma warning restore 108, 1591