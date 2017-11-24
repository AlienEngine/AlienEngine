using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlienEngine.Core.Threading
{
    /// <summary>
    /// Implements a singleton instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of object to create a singleton instance of.</typeparam>
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instance;

        /// <summary>
        /// Gets a singleton instance.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var newInstance = new T();
                    Interlocked.CompareExchange(ref _instance, newInstance, null);
                }

                return _instance;
            }
        }
    }
}
