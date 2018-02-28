// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 1634 $</version>
// </file>

using System;

namespace PascalSharp.Internal.Debugger.Debugger
{
	public interface IExpirable
	{
		event EventHandler Expired;
		
		bool HasExpired { get ; }
	}
}
