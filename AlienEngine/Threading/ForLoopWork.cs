using System;
using System.Threading;

namespace AlienEngine.Core.Threading
{
    class ForLoopWork : IWork
    {
        private static Pool<ForLoopWork> pool = new Pool<ForLoopWork>();

        private Action<int> action;
        private int length;
        private int stride;
        private volatile int index;

        public WorkOptions Options { get; private set; }

        public ForLoopWork()
        {
            Options = new WorkOptions() { MaximumThreads = int.MaxValue };
        }

        public void Prepare(Action<int> action, int startInclusive, int endExclusive, int stride)
        {
            this.action = action;
            this.index = startInclusive;
            this.length = endExclusive;
            this.stride = stride;
        }

        public void DoWork()
        {
            int start;
            while ((start = IncrementIndex()) < length)
            {
                int end = Math.Min(start + stride, length);
                for (int i = start; i < end; i++)
                {
                    action(i);
                }
            }
        }

        private int IncrementIndex()
        {
#if XBOX
            int x;
            do
            {
                x = index;
            } while (Interlocked.CompareExchange(ref index, x + stride, x) != x);
            return x;
#else
            return Interlocked.Add(ref index, stride) - stride;
#endif
        }

        public static ForLoopWork Get()
        {
            return pool.Get();
        }

        public void Return()
        {
            pool.Return(this);
        }
    }
}
