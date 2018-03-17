// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)
/***************************************************************************
 *   
 *   Интерфейс доступа к кодогенераторам для Compiler   
 *   Зависит от SemanticTree
 *
 ***************************************************************************/

using System.Collections;
using PascalSharp.Internal.SemanticTree;

namespace PascalSharp.Internal.EmitPE
{
	/*public class CodeGeneratorOptions
	{
		public NETGenerator.TargetType TargetType;
	}*/

	public class Controller
	{
		private ILConverter il_converter;//=new NETGenerator.ILConverter();

		public void Compile(IProgramNode ProgramTree,string TargetFileName,string SourceFileName ,
            CompilerOptions options, Hashtable StandartDirectories, string[] ResourceFiles)
		{
            il_converter = new ILConverter(StandartDirectories);
            il_converter.ConvertFromTree(ProgramTree,TargetFileName,SourceFileName,options,ResourceFiles);
		}

		public void Reset()
		{
            il_converter = null;
        }
	}
}
