using System.Collections.Generic;
using System.Threading;

namespace AlienEngine.Core.Threading
{
    /// <summary>
    /// Creates and manage tasks intended to work in the background.
    /// </summary>
    public class BackgroundWorker
    {
        /// <summary>
        /// A list of idle workers.
        /// </summary>
        private static Stack<BackgroundWorker> IdleWorkers = new Stack<BackgroundWorker>();

        /// <summary>
        /// The <see cref="Thread"/> in which this worker is executed.
        /// </summary>
        private Thread _thread;
        
        /// <summary>
        /// The auto reset event for the thread.
        /// </summary>
        private AutoResetEvent _resetEvent;
        
        /// <summary>
        /// The work to do.
        /// </summary>
        private Task _work;

        /// <summary>
        /// Initializes a new background worker.
        /// </summary>
        public BackgroundWorker()
        {
            _resetEvent = new AutoResetEvent(false);
            _thread = new Thread(_workLoop);
            _thread.IsBackground = true;
            _thread.Start();
        }

        /// <summary>
        /// Loops the work.
        /// </summary>
        private void _workLoop()
        {
            while (true)
            {
                _resetEvent.WaitOne();
                _work.DoWork();

                lock (IdleWorkers)
                {
                    IdleWorkers.Push(this);
                }
            }
        }

        /// <summary>
        /// Start the given work.
        /// </summary>
        /// <param name="work">The work to start.</param>
        private void _start(Task work)
        {
            _work = work;
            _resetEvent.Set();
        }

        /// <summary>
        /// Start the given work.
        /// </summary>
        /// <param name="work">The <see cref="Task"/> to start.</param>
        public static void StartWork(Task work)
        {
            BackgroundWorker worker = null;
            lock (IdleWorkers)
            {
                if (IdleWorkers.Count > 0)
                    worker = IdleWorkers.Pop();
            }

            if (worker == null)
                worker = new BackgroundWorker();

            worker._start(work);
        }
    }
}
