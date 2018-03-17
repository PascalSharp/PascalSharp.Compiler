namespace PascalSharp.Internal.SyntaxTree
{
    public class BaseEnterExitVisitor: WalkingVisitorNew
    {
        public BaseEnterExitVisitor()
        {
            OnEnter = Enter;
            OnLeave = Exit;
        }

        public virtual void Enter(syntax_tree_node st)
        {
        }
        public virtual void Exit(syntax_tree_node st)
        {
        }
    }
}
