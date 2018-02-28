// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2077 $</version>
// </file>

using System.Runtime.InteropServices;

#pragma warning disable 108, 1591 

namespace PascalSharp.Internal.Debugger.Interop.CorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct _COR_IL_MAP
    {
        public uint oldOffset;
        public uint newOffset;
        public int fAccurate;
    }
}

#pragma warning restore 108, 1591