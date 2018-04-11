using AlienEngine.Core.Game;

namespace AlienEngine
{
    internal interface IComponent: IFrameScript
    {
        #region Component behavior

        /// <summary>
        /// Triggered when the <see cref="Game"/> is starting.
        /// Initialize your component with this method.
        /// </summary>
        void Start();

        /// <summary>
        /// Trigerred when the <see cref="Game"/> is being stopped.
        /// You can use this method to release resources used by your
        /// component.
        /// </summary>
        void Stop();

        #endregion
    }
}
