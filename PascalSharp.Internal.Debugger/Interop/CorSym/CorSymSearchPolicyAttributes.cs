// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2077 $</version>
// </file>

#pragma warning disable 108, 1591 

namespace PascalSharp.Internal.Debugger.Interop.CorSym
{
    public enum CorSymSearchPolicyAttributes
    {
        // Fields
        AllowOriginalPathAccess = 4,
        AllowReferencePathAccess = 8,
        AllowRegistryAccess = 1,
        AllowSymbolServerAccess = 2
    }
}

#pragma warning restore 108, 1591