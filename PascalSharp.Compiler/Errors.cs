// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using PascalSharp.Internal.SyntaxTree;
using PascalSharp.Internal.TreeConverter;
using StringResources = PascalSharp.Internal.Localization.StringResources;

namespace PascalSharp.Compiler
{

	public class FileNotFound : CompilationError
	{
		private string _file_name;

		public FileNotFound(string file_name)
		{
			_file_name=file_name;
		}

		public string file_name
		{
			get
			{
				return _file_name;
			}
		}

		public override string ToString()
		{
			return ("File: "+_file_name+" not found");
		}

	}

	public class DLLReadingError : CompilationError
	{
		private string _dll_name;

		public DLLReadingError(string dll_name)
		{
			_dll_name=dll_name;
		}

		public string dll_name
		{
			get
			{
				return _dll_name;
			}
		}

		public override string ToString()
		{
			//return ("Dll: "+dll_name+" not found");
			return string.Format(StringResources.Get("COMPILATIONERROR_ASSEMBLY_{0}_READING_ERROR"), dll_name);
		}

	}

	public class InvalidUnit : CompilationError
	{
		private string _unit_name;

		public InvalidUnit(string unit_name)
		{
			_unit_name=unit_name;
		}

		public string unit_name
		{
			get
			{
				return _unit_name;
			}
		}

		public override string ToString()
		{
			return ("Invalid unit: "+_unit_name);
		}

	}

	public class UnitCompilationError : CompilationError
	{
		private unit_or_namespace _SyntaxUsesUnit;
		private string _file_name;

		public UnitCompilationError(string fileName,unit_or_namespace syntaxUsesUnit)
		{
			_SyntaxUsesUnit=syntaxUsesUnit;
			_file_name=fileName;
		}

		public unit_or_namespace SyntaxUsesUnit
		{
			get
			{
				return _SyntaxUsesUnit;
			}
		}

		public string file_name
		{
			get
			{
				return _file_name;
			}
		}
	}

}
