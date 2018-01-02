namespace AlienEngine.UI
{
    /// <summary>
    /// Stores data about text change events in input fields.
    /// </summary>
    public class TextChangeEventArgs
    {
        /// <summary>
        /// The old value.
        /// </summary>
        public readonly string Oldvalue;

        /// <summary>
        /// The new value.
        /// </summary>
        public readonly string NewValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldvalue"></param>
        /// <param name="newValue"></param>
        public TextChangeEventArgs(string oldvalue, string newValue)
        {
            Oldvalue = oldvalue;
            NewValue = newValue;
        }
    }
}