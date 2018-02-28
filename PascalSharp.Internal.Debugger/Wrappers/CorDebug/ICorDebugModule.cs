// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2077 $</version>
// </file>

#pragma warning disable 1591

namespace PascalSharp.Internal.Debugger.Wrappers.CorDebug
{
    public partial class ICorDebugModule
	{
		public string Name {
			get {
				return Util.GetString(GetName);
			}
		}
	}
}

#pragma warning restore 1591
