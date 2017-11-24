using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlienEngine.Core.Threading
{
    /// <summary>
    /// A semaphore class.
    /// </summary>
    public class Semaphore
    {
        private AutoResetEvent _gate;
        private int _free;
        private object _free_lock = new object();

        /// <summary>
        /// Creates a new instance of the <see cref="Semaphore"/> class.
        /// </summary>
        /// <param name="maximumCount"></param>
        public Semaphore(int maximumCount)
        {
            _free = maximumCount;
            _gate = new AutoResetEvent(_free > 0);
        }

        /// <summary>
        /// Blocks the calling thread until resources are made available, then consumes one resource.
        /// </summary>
        public void WaitOne()
        {
            _gate.WaitOne(); //Enter and close gate

            lock (_free_lock)
            {
                _free--;

                if (_free > 0)// If not is full
                    _gate.Set(); //Open gate
            }
        }

        /// <summary>
        /// Adds one resource.
        /// </summary>
        public void Release()
        {
            lock (_free_lock)
            {
                _free++;
                _gate.Set();//Open gate
            }
        }
    }
}
