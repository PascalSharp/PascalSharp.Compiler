﻿// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using PascalSharp.Internal.Errors;

namespace PascalSharp.Internal.SyntaxTree.Visitors
{
    public static class StringResources
    {
        public static string Get(string key)
        {
            return PascalSharp.Internal.Localization.StringResources.Get("SYNTAXTREEVISITORSERROR_" + key);
        }

        public static string Get(string key, params object[] values)
        {
            return (string.Format(Get(key), values));
        }
    }

    public class SyntaxVisitorError: SyntaxError
    {
        public SyntaxVisitorError(string resourcestring, SourceContext sc, params object[] values): base(StringResources.Get(resourcestring),"",sc,null)
        {

        }
    }
}
