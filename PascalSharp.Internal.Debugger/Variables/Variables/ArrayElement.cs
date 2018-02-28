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
	/// Represents an element of an array
	/// </summary>
	public class ArrayElement: NamedValue
	{
		uint[] indicies;
		
		/// <summary>
		/// The indicies of the element; one for each dimension of
		/// the array.
		/// </summary>
		public uint[] Indicies {
			get {
				return indicies;
			}
		}
		
		internal ArrayElement(uint[] indicies,
		                      Process process,
		                      IExpirable[] expireDependencies,
		                      IMutable[] mutateDependencies,
		                      CorValueGetter corValueGetter)
			:base (GetNameFromIndices(indicies),
			       process,
			       expireDependencies,
			       mutateDependencies,
			       corValueGetter)
		{
			this.indicies = indicies;
		}
		
		static string GetNameFromIndices(uint[] indices)
		{
			string elementName = "[";
			for (int i = 0; i < indices.Length; i++) {
				elementName += indices[i].ToString() + ",";
			}
			elementName = elementName.TrimEnd(new char[] {','}) + "]";
			return elementName;
		}
	}
}
