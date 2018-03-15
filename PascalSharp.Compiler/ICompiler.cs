// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System.Collections.Generic;
using PascalABCCompiler;
using PascalABCCompiler.SemanticTree;
using PascalSharp.Compiler.SemanticTreeConverters;
using PascalSharp.Internal.Errors;
using PascalSharp.Internal.ParserTools;
using PascalSharp.Internal.SyntaxTree;

///В разработке DarkStar

namespace PascalSharp.Compiler
{
    public enum CompilerType { Standart, Remote }
    public interface ICompiler
    {
        SyntaxTreeConvertersController SyntaxTreeConvertersController
        {
            get; 
        }
        SemanticTreeConvertersController SemanticTreeConvertersController
        {
            get;
        }
        
        Controller ParsersController
        {
            get;
        }

        IProgramNode SemanticTree
        {
            get;
        }
        
        uint LinesCompiled
        {
            get;
        }

        CompilerInternalDebug InternalDebug
        {
            get;
            set;
        }

        CompilerState State
        {
            get;
        }

        SupportedSourceFile[] SupportedSourceFiles
        {
            get;
        }
		
        SupportedSourceFile[] SupportedProjectFiles
        {
        	get;
        }
        
        CompilerOptions CompilerOptions
        {
            get;
            set;
        }

        List<Error> ErrorsList
        {
            get;
        }

        List<CompilerWarning> Warnings
        {
            get;
        }

        int BeginOffset
        {
            get;
        }
        
        int VarBeginOffset
        {
        	get;
        }
        
        CompilationUnitHashTable UnitTable
        {
            get;
        }

        SourceFilesProviderDelegate SourceFilesProvider
        {
            get;
        }

        event ChangeCompilerStateEventDelegate OnChangeCompilerState;

        void Free();

        void Reload();

        string Compile();

        void StartCompile();

        void AddWarnings(List<CompilerWarning> WarningList);

        compilation_unit ParseText(string FileName, string Text, List<Error> ErrorList, List<CompilerWarning> Warnings);

        string GetSourceFileText(string FileName);

        CompilerType CompilerType
        {
            get;
        }


    }

}
