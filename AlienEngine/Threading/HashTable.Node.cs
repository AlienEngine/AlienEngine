namespace AlienEngine.Core.Threading
{
    public partial class Hashtable<TKey, TData>
    {
        struct Node
        {
            public TKey Key;
            public TData Data;
            public Token Token;
        }
    }
}