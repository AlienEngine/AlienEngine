using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienEngine.Core.Audio.OpenAL;
using AlienEngine.Core.Game;

namespace AlienEngine
{
    public class AudioListener : Component
    {
        /// <summary>
        /// The velociy of the sound listener.
        /// </summary>
        private Vector3f _velocity;

        /// <summary>
        /// EFX meters per unit.
        /// </summary>
        private float _efxMetersPerUnit;

        /// <summary>
        /// The gain (volume).
        /// </summary>
        private float _gain;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AudioListener() : this(Vector3f.Zero, 0.5f, 1f)
        { }

        public AudioListener(Vector3f velocity, float efxMetersPerUnit, float gain)
        {
            _velocity = velocity;
            _efxMetersPerUnit = efxMetersPerUnit;
            _gain = gain;
        }

        /// <summary>
        /// The velocity of the sound listener
        /// </summary>
        /// <returns>The <see cref="Vector3f"/> of the velocity.</returns>
        public Vector3f Velocity
        {
            get { return _velocity; }
        }

        /// <summary>
        /// The EFX meters per unit of the sound listener
        /// </summary>
        /// <returns>The EFX meters per unit.</returns>
        public float EfxMetersPerUnit
        {
            get { return _efxMetersPerUnit; }
        }

        /// <summary>
        /// The gain od the sound listener.
        /// </summary>
        /// <returns>The gain.</returns>
        public float Gain
        {
            get { return _gain; }
        }

        public override void Start()
        {
            MakeCurrent();

            gameElement.LocalTransform.OnPositionChange += ((_old, _new) =>
            {
                AL.Listener(ALListener3f.Position, _new.X, _new.Y, _new.Z);
                AL.Listener(ALListener3f.Velocity, _new.X - _old.X, _new.Y - _old.Y, _new.Z - _old.Z);
            });

            gameElement.LocalTransform.OnRotationChange += ((_old, _new) =>
            {
                Matrix3f r = Matrix4f.CreateRotation(_new).ToMatrix3f();
                float[] coords = new float[] { -r.Column2.X, r.Column2.Y, r.Column2.Z, -r.Column1.X, r.Column1.Y, r.Column1.Z };
                AL.Listener(ALListenerfv.Orientation, ref coords);
            });
        }

        /// <summary>
        /// Make this sound listener the current.
        /// </summary>
        public void MakeCurrent()
        {
            if (Game.CurrentAudioListener != gameElement)
            {
                Game.SetCurrentAudioListener(gameElement);
                Update();
            }
        }

        /// <summary>
        /// Changes the velocity of this listener.
        /// </summary>
        /// <param name="orientation">The new velocity.</param>
        public void SetVelocity(Vector3f velocity)
        {
            _velocity = velocity;
        }

        /// <summary>
        /// Changes the EFX meters per unit of this listener.
        /// </summary>
        /// <param name="orientation">The new EFX meters per unit.</param>
        public void SetEfxMetersPerUnit(float efxMetersPerUnit)
        {
            _efxMetersPerUnit = efxMetersPerUnit;
            AL.Listener(ALListenerf.EfxMetersPerUnit, EfxMetersPerUnit);
        }

        /// <summary>
        /// Changes the gain of this listener.
        /// </summary>
        /// <param name="orientation">The new gain.</param>
        public void SetGain(float gain)
        {
            _gain = gain;
            AL.Listener(ALListenerf.Gain, Gain);
        }
    }
}
