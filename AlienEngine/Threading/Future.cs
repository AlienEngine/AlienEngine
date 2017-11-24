using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AlienEngine.Core.Threading;

namespace AlienEngine.Core.Threading
{
    /// <summary>
    /// A task struct which can return a result.
    /// </summary>
    /// <typeparam name="T">The type of result this future calculates.</typeparam>
    public struct Future<T>
    {
        private Task _task;
        private FutureWork<T> _work;
        private int _id;

        /// <summary>
        /// Gets a value which indicates if this future has completed.
        /// </summary>
        public bool IsComplete => _task.IsComplete;

        /// <summary>
        /// Gets an array containing any exceptions thrown by this future.
        /// </summary>
        public Exception[] Exceptions => _task.Exceptions;

        internal Future(Task task, FutureWork<T> work)
        {
            _task = task;
            _work = work;
            _id = work.ID;
        }

        /// <summary>
        /// Gets the result. Blocks the calling thread until the future has completed execution.
        /// This can only be called once!
        /// </summary>
        /// <returns></returns>
        public T GetResult()
        {
            if (_work == null || _work.ID != _id)
                throw new InvalidOperationException("The result of a future can only be retrieved once.");

            _task.Wait();
            var result = _work.Result;
            _work.ReturnToPool();
            _work = null;

            return result;
        }
    }
}