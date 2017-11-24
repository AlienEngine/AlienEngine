using System;

namespace AlienEngine.Core.Threading
{
    /// <summary>
    /// Represents a work which can return a value.
    /// </summary>
    /// <typeparam name="T">The type of the returned value.</typeparam>
    public class FutureWork<T> : IWork
    {
        public int ID { get; private set; }
        public WorkOptions Options { get; set; }
        public Func<T> Function { get; set; }
        public T Result { get; set; }

        public void DoWork()
        {
            Result = Function();
        }

        public static FutureWork<T> GetInstance()
        {
            return Pool<FutureWork<T>>.Instance.Get();
        }

        public void ReturnToPool()
        {
            if (ID < int.MaxValue)
            {
                ID++;

                // MartinG@DigitalRune: Reset properties before recycling to avoid "memory leaks".
                Function = null;
                Result = default(T);

                Pool<FutureWork<T>>.Instance.Return(this);
            }
        }
    }
}