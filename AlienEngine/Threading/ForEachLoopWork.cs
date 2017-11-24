using System;
using System.Collections.Generic;

namespace AlienEngine.Core.Threading
{
    class ForEachLoopWork<T> : IWork
    {
        static Pool<ForEachLoopWork<T>> pool = Pool<ForEachLoopWork<T>>.Instance;

        private Action<T> action;
        private IEnumerator<T> enumerator;
        private volatile bool notDone;
        private object syncLock;

        public WorkOptions Options { get; private set; }

        public ForEachLoopWork()
        {
            Options = new WorkOptions() { MaximumThreads = int.MaxValue };
            syncLock = new object();
        }

        public void Prepare(Action<T> action, IEnumerator<T> enumerator)
        {
            this.action = action;
            this.enumerator = enumerator;
            this.notDone = true;
        }

        public void DoWork()
        {
            T item = default(T);
            while (notDone)
            {
                bool haveValue = false;
                lock (syncLock)
                {
                    if (notDone = enumerator.MoveNext())
                    {
                        item = enumerator.Current;
                        haveValue = true;
                    }
                }

                if (haveValue)
                    action(item);
            }
        }

        public static ForEachLoopWork<T> Get()
        {
            return pool.Get();
        }

        public void Return()
        {
            pool.Return(this);
        }
    }
}
