using System;

namespace AlienEngine.Core.Threading
{
    /// <summary>
    /// Creates and manages simple works.
    /// </summary>
    public class DelegateWork : IWork
    {
        /// <summary>
        /// A list of <see cref="DelegateWork"/> instances.
        /// </summary>
        private static readonly Pool<DelegateWork> Instances = new Pool<DelegateWork>();

        /// <summary>
        /// The <see cref="Action"/> to execute.
        /// </summary>
        public Action Action { get; set; }

        /// <summary>
        /// A set of options to customize the work.
        /// </summary>
        public WorkOptions Options { get; set; }

        /// <summary>
        /// Executes the work.
        /// </summary>
        public void DoWork()
        {
            Action();
            Instances.Return(this);
        }

        /// <summary>
        /// Gets an instance from the <see cref="Pool{T}"/>.
        /// </summary>
        internal static DelegateWork GetInstance()
        {
            return Instances.Get();
        }
    }
}