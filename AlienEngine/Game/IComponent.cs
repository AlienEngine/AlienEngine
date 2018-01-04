namespace AlienEngine
{
    internal interface IComponent
    {
        #region Component behavior

        /// <summary>
        /// Triggered when the <see cref="Game"/> is starting.
        /// Initialize your component with this method.
        /// </summary>
        void Start();

        /// <summary>
        /// Trigerred just before the frame update.
        /// </summary>
        void BeforeUpdate();

        /// <summary>
        /// Triggered during the frame update.
        /// </summary>
        void Update();

        /// <summary>
        /// Trigerred just after the frame update.
        /// </summary>
        void AfterUpdate();

        /// <summary>
        /// Trigerred when the <see cref="Game"/> is being stopped.
        /// You can use this method to release resources used by your
        /// component.
        /// </summary>
        void Stop();

        #endregion
    }
}
