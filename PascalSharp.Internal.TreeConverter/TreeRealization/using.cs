// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

namespace PascalSharp.Internal.TreeConverter.TreeRealization
{
	public class using_namespace
	{
		private string _namespace_name;

		public using_namespace(string namespace_name)
		{
			_namespace_name=namespace_name;
		}

		public string namespace_name
		{
			get
			{
				return _namespace_name;
			}
		}
	}
}