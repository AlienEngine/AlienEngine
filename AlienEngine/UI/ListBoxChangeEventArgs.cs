using System;

namespace AlienEngine.UI
{
    /// <summary>
    /// Stores data about a change event in a list box.
    /// </summary>
    public class ListBoxChangeEventArgs : EventArgs
    {
        /// <summary>
        /// The last value just before the change.
        /// </summary>
        public readonly string OldValue;

        /// <summary>
        /// The new value.
        /// </summary>
        public readonly string NewValue;

        /// <summary>
        /// Constructs a new list box change event data store.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public ListBoxChangeEventArgs(string oldValue, string newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}