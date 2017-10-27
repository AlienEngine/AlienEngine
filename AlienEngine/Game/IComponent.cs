using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienEngine.Core.Game;

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

        #region Physics triggers

        /// <summary>
        /// Trigerred when the <see cref="Collider"/> of this
        /// <see cref="GameElement"/> hit another.
        /// </summary>
        /// <param name="element">The other collider.</param>
        void OnColliderHit(Collider element);

        /// <summary>
        /// Trigerred when the <see cref="Collider"/> of this
        /// <see cref="GameElement"/> enter in another.
        /// </summary>
        /// <param name="element">The other collider.</param>
        void OnColliderEnter(Collider element);

        /// <summary>
        /// Trigerred when the <see cref="Collider"/> of this
        /// <see cref="GameElement"/> is in another.
        /// </summary>
        /// <param name="element">The other collider.</param>
        void OnColliderStay(Collider element);

        /// <summary>
        /// Trigerred when the <see cref="Collider"/> of this
        /// <see cref="GameElement"/> exit out another.
        /// </summary>
        /// <param name="element">The other collider.</param>
        void OnColliderExit(Collider element);

        #endregion
    }
}
