using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading;
using AlienEngine.Core.Threading;


namespace AlienEngine.Core.Threading
{
    class Worker
    {
        private Thread _thread;
        private Deque<Task> _tasks;
        private WorkStealingScheduler _scheduler;

        public bool LookingForWork { get; private set; }
        public AutoResetEvent Gate { get; private set; }

#if WINDOWS_PHONE
        // Cannot access Environment.ProcessorCount in phone app. (Security issue).
        static Hashtable<Thread, Worker> workers = new Hashtable<Thread, Worker>(1);
#else
        private static Hashtable<Thread, Worker> _workers = new Hashtable<Thread, Worker>(Environment.ProcessorCount);
#endif
        public static Worker CurrentWorker
        {
            get
            {
                var currentThread = Thread.CurrentThread;
                Worker worker;
                if (_workers.TryGet(currentThread, out worker))
                    return worker;
                return null;
            }
        }

#if XBOX
        static int affinityIndex;
#endif

        public Worker(WorkStealingScheduler scheduler, int index)
        {
            _thread = new Thread(Work);
            _thread.Name = "AlienEngine Worker " + index;
            _thread.IsBackground = true;
            _tasks = new Deque<Task>();
            this._scheduler = scheduler;
            Gate = new AutoResetEvent(false);

            _workers.Add(_thread, this);
        }

        public void Start()
        {
            _thread.Start();
        }

        public void AddWork(Task task)
        {
            _tasks.LocalPush(task);
        }

        private void Work()
        {
#if XBOX
            int i = Interlocked.Increment(ref affinityIndex) - 1;
            int affinity = Parallel.ProcessorAffinity[i % Parallel.ProcessorAffinity.Length];
            Thread.CurrentThread.SetProcessorAffinity((int)affinity);
#endif

            Task task = new Task();
            while (true)
            {
                if (_tasks.LocalPop(ref task))
                {
                    task.DoWork();
                }
                else
                    FindWork();
            }
        }

        private void FindWork()
        {
            LookingForWork = true;
            Task task;
            bool foundWork = false;
            do
            {
                if (_scheduler.TryGetTask(out task))
                {
                    foundWork = true;
                    break;
                }

                var replicable = WorkItem.Replicable;
                if (replicable.HasValue)
                {
                    replicable.Value.DoWork();
                    WorkItem.SetReplicableNull(replicable);

                    // MartinG@DigitalRune: Continue checking local queue and replicables. 
                    // No need to steal work yet.
                    continue;
                }

                for (int i = 0; i < _scheduler.Workers.Count; i++)
                {
                    var worker = _scheduler.Workers[i];
                    if (worker == this)
                        continue;

                    if (worker._tasks.TrySteal(ref task))
                    {
                        foundWork = true;
                        break;
                    }
                }

                if (!foundWork)
                {
                    // Wait until a new task gets scheduled.
                    Gate.WaitOne();
                }
            } while (!foundWork);

            LookingForWork = false;
            _tasks.LocalPush(task);
        }
    }
}
