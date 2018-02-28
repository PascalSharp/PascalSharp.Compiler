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
    [ComImport, Guid("3D6F5F61-7538-11D3-8D5B-00104B35E7EF"), CoClass(typeof(EmbeddedCLRCorDebugClass))]
    public interface EmbeddedCLRCorDebug : ICorDebug
    {
    }
}

#pragma warning restore 108, 1591