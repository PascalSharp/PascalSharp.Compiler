// Copyright (c) Ivan Bondarev, Stanislav Mihalkovich (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using PascalSharp.Internal.Errors;
using PascalSharp.Internal.TreeConverter.TreeRealization;

namespace PascalSharp.Internal.TreeConverter.TreeConversion
{

    public class StringResourcesForWarning
    {
        public static string Get(string key)
        {
            return PascalSharp.Internal.Localization.StringResources.Get("WARNING_" + key);
        }

        public static string Get(string key, params object[] values)
        {
            return (string.Format(Get(key), values));
        }
    }

    public class CompilerWarningWithLocation : CompilerWarning
    {
        location loc;
        public CompilerWarningWithLocation(location loc)
        {
            this.loc = loc;
        }
        public override SourceLocation SourceLocation
        {
            get
            {
                if (loc != null)
                    return new SourceLocation(loc.doc.file_name, loc.begin_line_num, loc.begin_column_num, loc.end_line_num, loc.end_column_num);
                else
                    return null;
            }
        }
    }
    public class OverrideOrReintroduceExpected : CompilerWarningWithLocation
    {
        public OverrideOrReintroduceExpected(location loc)
            : base(loc)
        {
        }
        public override string ToString()
        {
            return StringResourcesForWarning.Get("OVERRIDE_OR_REINTRODUCE_EXPECTED");
        }
    }
    public class ExtensionOperatorForPrimitiveType : CompilerWarningWithLocation
    {
        public ExtensionOperatorForPrimitiveType(location loc)
            : base(loc)
        {
        }
        public override string ToString()
        {
            return StringResourcesForWarning.Get("");
        }
    }

    public class OMP_ConstructionNotSupportedNow : CompilerWarningWithLocation
    {
        public OMP_ConstructionNotSupportedNow(location loc)
            : base(loc)
        {
        }
        public override string ToString()
        {
            return "This OMP construction not supported now.";
        }
    }

    public class OMP_BuildigError : CompilerWarningWithLocation
    {
        Exception _e;
        public OMP_BuildigError(Exception e, location loc)
            : base(e is CompilationErrorWithLocation ? ((CompilationErrorWithLocation)e).loc : loc)
        {
            _e = e;
        }
        public override string ToString()
        {
            return "This OMP construction not builded: " + _e.Message;
        }
    }

}
