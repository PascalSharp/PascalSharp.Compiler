// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="David Srbecký" email="dsrbecky@gmail.com"/>
//     <version>$Revision: 2185 $</version>
// </file>

using PascalSharp.Internal.Debugger.Debugger;
using PascalSharp.Internal.Debugger.Variables.Values;
using Process = PascalSharp.Internal.Debugger.Threads.Process;

namespace PascalSharp.Internal.Debugger.Variables.Variables
{
	/// <summary>
	/// Represents a local variable in a function
	/// </summary>
	public class LocalVariable: NamedValue
	{
		internal LocalVariable(string name,
		                       Process process,
		                       IExpirable[] expireDependencies,
		                       IMutable[] mutateDependencies,
		                       CorValueGetter corValueGetter)
			:base (name,
			       process,
			       expireDependencies,
			       mutateDependencies,
			       corValueGetter)
		{
			
		}
	}
}
