using AlienEngine.Core.Resources;
using System.Collections.Generic;
using System.Threading;

namespace AlienEngine.Core.Threading
{
    public static class ThreadsManager
    {
        /// <summary>
        /// The list of <see cref="Thread"/>s registered in the
        /// <see cref="ThreadsManager"/>.
        /// </summary>
        private static List<Thread> _threads;

        public static int ThreadsCount => _threads.Count;

        static ThreadsManager()
        {
            _threads = new List<Thread>();

            ResourcesManager.AddOnDisposeEvent(() =>
            {
                foreach (var thread in _threads)
                {
                    thread.Abort();
                }

                _threads.Clear();
                _threads = null;
            });
        }

        public static void AddThread(Thread thread)
        {
            _threads.Add(thread);
        }

        public static int CreateThread(ParameterizedThreadStart action, bool isBackground = false, string name = null, ThreadPriority priority = ThreadPriority.Normal)
        {
            _threads.Add(new Thread(action) { IsBackground = isBackground, Name = name, Priority = priority });
            return ThreadsCount - 1;
        }

        public static int CreateThread(ThreadStart action, bool isBackground = false, string name = null, ThreadPriority priority = ThreadPriority.Normal)
        {
            _threads.Add(new Thread(action) { IsBackground = isBackground, Name = name, Priority = priority });
            return ThreadsCount - 1;
        }

        public static void StartThread(int index)
        {
            _threads[index].Start();
        }

        public static void AbortThread(int index)
        {
            _threads[index].Abort();
        }
    }
}
