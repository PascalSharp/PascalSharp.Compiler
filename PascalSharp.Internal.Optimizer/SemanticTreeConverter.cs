// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using PascalSharp.Compiler;
using PascalSharp.Compiler.SemanticTreeConverters;
using PascalSharp.Internal.SemanticTree;

namespace PascalSharp.Internal.Optimizer
{
    public class Optimizer_SemanticTreeConverter : ISemanticTreeConverter
    {
        public Optimizer_SemanticTreeConverter()
        {
        }
        public string Name
        {
            get { return "Optimizer"; }
        }

        public string Description
        {
            get { return ""; }
        }

        public string Version
        {
            get { return "1.0"; }
        }

        public string Copyright
        {
            get { return "Copyright © 2005-2018 by Ivan Bondarev, Stanislav Mihalkovich"; }
        }

        public ConverterType ConverterType
        {
            get { return ConverterType.Analysis; }
        }

        public ExecutionOrder ExecutionOrder
        {
            get { return ExecutionOrder.Undefined; }
        }

        public IProgramNode Convert(ICompiler Compiler, IProgramNode ProgramNode)
        {
            Optimizer Optimizer = new Optimizer();
            Compiler.AddWarnings(Optimizer.Optimize(ProgramNode as PascalSharp.Internal.TreeConverter.TreeRealization.program_node));
            return ProgramNode;
        }
        public override string ToString()
        {
            return String.Format("{0} v{1} {2}", Name, Version, Copyright);
        }
    }
}
