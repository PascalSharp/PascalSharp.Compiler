// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2210 $</version>
// </file>

using System.Collections.Generic;

#pragma warning disable 1591

namespace PascalSharp.Internal.Debugger.Wrappers.CorDebug
{
    public partial class ICorDebugTypeEnum
	{
		public IEnumerable<ICorDebugType> Enumerator {
			get {
				Reset();
				while (true) {
					ICorDebugType corType = Next();
					if (corType != null) {
						yield return corType;
					} else {
						break;
					}
				}
			}
		}
		
		public ICorDebugType Next()
		{
			ICorDebugType[] corTypes = new ICorDebugType[1];
			uint typesFetched = this.Next(1, corTypes);
			if (typesFetched == 0) {
				return null;
			} else {
				return corTypes[0];
			}
		}
		
		public List<ICorDebugType> ToList()
		{
			return new List<ICorDebugType>(this.Enumerator);
		}
	}
	
	
}

#pragma warning restore 1591
