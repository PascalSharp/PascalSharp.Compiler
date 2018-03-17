// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

namespace PascalSharp.Internal.TreeConverter.TreeRealization
{
    public class compiler_directive
    {
        public string name;
        public string directive;
        public location location;
        public compiler_directive(string name,string directive,location loc)
        {
            this.name = name;
            this.directive = directive;
            this.location = loc;
        }
    }
}