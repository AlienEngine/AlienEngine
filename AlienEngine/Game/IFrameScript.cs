using System;

namespace AlienEngine
{
    public interface IFrameScript: IDisposable
    {
        void Load();
        
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

        void Unload();
    }
}