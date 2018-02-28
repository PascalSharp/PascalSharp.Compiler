// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System.Collections.Generic;
using PascalSharp.Internal.Errors;

namespace PascalSharp.Internal.CompilerTools.Errors
{
    public enum ErrorsStrategy { All=0, FirstOnly=1, FirstSemanticAndSyntax=2 };
    public class ErrorsStrategyManager
    {
        public ErrorsStrategy Strategy;

        public ErrorsStrategyManager(ErrorsStrategy Strategy)
        {
            this.Strategy = Strategy;
        }

        public List<Error> CreateErrorsList(List<Error> CompilerErrorsList)
        {
            List<Error> ErrorsList = new List<Error>();
            switch (Strategy)
            {
                case ErrorsStrategy.All:
                    ErrorsList = CompilerErrorsList;
                    break;
                case ErrorsStrategy.FirstOnly:
                    if (CompilerErrorsList.Count > 0)
                        ErrorsList.Add(CompilerErrorsList[0]);
                    break;
                case ErrorsStrategy.FirstSemanticAndSyntax:
                    if (CompilerErrorsList.Count > 0)
                    {
                        ErrorsList.Add(CompilerErrorsList[0]);
                        bool syntax_add = ErrorsList[0] is SyntaxError;
                        bool semantic_add = ErrorsList[0] is SemanticError;
                        int i = 0;
                        while (i < CompilerErrorsList.Count && (!syntax_add || !semantic_add))
                        {
                            if (!syntax_add && CompilerErrorsList[i] is SyntaxError)
                            {
                                ErrorsList.Add(CompilerErrorsList[i]);
                                syntax_add = true;
                            }
                            if (!semantic_add && CompilerErrorsList[i] is SemanticError)
                            {
                                ErrorsList.Add(CompilerErrorsList[i]);
                                semantic_add = true;
                            }
                            i++;
                        }
                    }
                    break;                            
            }
            return ErrorsList;
        }
        

    }
}
