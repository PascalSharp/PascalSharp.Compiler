namespace PascalSharp.Internal.YieldHelpers
{
    public static class YieldConsts
    {
        public static string Current = "<>2__current";
        public static string State = "<>1__state";
        public static string LabelStatePrefix = "lbstate#";

        public static string Self = "<>4__self";

        public static string YieldHelperMethodPrefix = "<yield_helper";

        public enum ReservedNum { StateField = 1, CurrentField = 2, MethodFormalParam = 3, MethodSelf = 4, MethodLocalVariable = 5 }
    }
}
