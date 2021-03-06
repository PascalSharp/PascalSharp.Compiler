﻿// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

namespace PascalSharp.Internal.SyntaxTree.Visitors.BaseVisitors
{
    public class HasStatementVisitor<T> : WalkingVisitorNew
        where T : statement
    {
        private bool foundT = false;

        public static bool Has(syntax_tree_node node)
        {
            HasStatementVisitor<T> vis = new HasStatementVisitor<T>();

            vis.ProcessNode(node);

            return vis.foundT;
        }

        public override void DefaultVisit(syntax_tree_node node)
        {
            if (node is T)
                foundT = true;
            else 
                base.DefaultVisit(node);
        }
    }
}
