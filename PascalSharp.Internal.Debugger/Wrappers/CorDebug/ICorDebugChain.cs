// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbeck�" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2077 $</version>
// </file>

#pragma warning disable 1591

namespace PascalSharp.Internal.Debugger.Wrappers.CorDebug
{
    public partial class ICorDebugChain
	{
		uint index;
		
		public uint Index {
			get {
				return index;
			}
			set {
				index = value;
			}
		}
	}
}

#pragma warning restore 1591
