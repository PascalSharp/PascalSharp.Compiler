// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using PascalABCCompiler.SemanticTree;

namespace PascalSharp.Compiler.SemanticTreeConverters
{
    public enum ConverterType
    {
        Conversion, Analysis, CodeGenerator
    }
    public enum ExecutionOrder
    {
        Undefined, First, Last
    }
    public interface ISemanticTreeConverter
    {
        string Name
        {
            get;
        }
        
        string Version
        {
            get;
        }

        string Description
        {
            get;
        }

        string Copyright
        {
            get;
        }

        ConverterType ConverterType
        {
            get;
        }

        ExecutionOrder ExecutionOrder
        {
            get;
        }

        IProgramNode Convert(ICompiler Compiler, IProgramNode ProgramNode);

    }
}
