// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System.Collections.Generic;

namespace PascalSharp.Internal.ParserTools
{
    public interface IPreprocessor
    {
        List<compiler_directive> CompilerDirectives
        {
            get;
        }
        /*SourceFilesProviderDelegate SourceFilesProvider
        {
            get;
            set;
        }*/
        //string Build(string[] fileNames, List<Error> errors, ParserTools.SourceContextMap sourceContextMap);
    }
}
