// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2077 $</version>
// </file>

using System.Runtime.InteropServices;

#pragma warning disable 108, 1591 

namespace PascalSharp.Internal.Debugger.Interop.CorSym
{
    [ComImport, CoClass(typeof(CorSymReader_SxSClass)), Guid("B4CE6286-2A6B-3712-A3B7-1EE1DAD467B5")]
    public interface CorSymReader_SxS : ISymUnmanagedReader
    {
    }
}

#pragma warning restore 108, 1591