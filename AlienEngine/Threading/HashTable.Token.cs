namespace AlienEngine.Core.Threading
{
    public partial class Hashtable<TKey, TData>
    {
        enum Token
        {
            Empty,
            Used,
            Deleted
        }
    }
}