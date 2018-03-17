// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System.Collections.Generic;
using System.Linq;

namespace PascalSharp.Internal.SyntaxTree.Visitors.YieldVisitors
{
    public class CollectUnitGlobalsVisitor : CollectUpperNodesVisitor
    {
        public ISet<ident> CollectedGlobals { get; private set; } 

        public CollectUnitGlobalsVisitor()
        {
            CollectedGlobals = new HashSet<ident>();
        }

        /*public override void visit(interface_node node)
        {
            var globals = node.interface_definitions.defs
                .Select(def => def as variable_definitions)
                .Where(varDefsObj => (object)varDefsObj != null)
                .SelectMany(varDefs => varDefs.var_definitions)
                .SelectMany(v => v.vars.idents);

            CollectedGlobals.UnionWith(globals);
        }*/

        public override void visit(declarations node)
        {
            var globals = node.defs
                .Select(def => def as variable_definitions)
                .Where(varDefsObj => (object)varDefsObj != null)
                .SelectMany(varDefs => varDefs.var_definitions)
                .SelectMany(v => v.vars.idents);

            CollectedGlobals.UnionWith(globals);
        }
    }
}
