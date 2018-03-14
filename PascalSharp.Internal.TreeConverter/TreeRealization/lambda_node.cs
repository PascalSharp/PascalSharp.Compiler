// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

namespace PascalSharp.Internal.TreeConverter.TreeRealization  //lroman//
{
    public class lambda_node
    {
        private PascalSharp.Internal.TreeConverter.SymbolTable.Scope _scope;

        public PascalSharp.Internal.TreeConverter.SymbolTable.Scope scope
        {
            get
            {
                return _scope;
            }
            set
            {
                _scope = value;
            }
        }

        public lambda_node(PascalSharp.Internal.TreeConverter.SymbolTable.Scope _scope)
        {
            this._scope = _scope;
        }
    }
}
