using AlienEngine.Core.Audio.OpenAL;

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
        /// The gain of the sound listener.
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
                Vector3f _delta = _new - _old;
                AL.Listener(ALListener3f.Position, ref _new);
                AL.Listener(ALListener3f.Velocity, ref _delta);
            });

            gameElement.LocalTransform.OnRotationChange += ((_old, _new) =>
            {
                Vector3f _forward = gameElement.LocalTransform.ForwardVector,
                         _up = gameElement.LocalTransform.UpVector;

                AL.Listener(ALListenerfv.Orientation, ref _forward, ref _up);
            });
        }

        public override void Update()
        {
            // Reset Velocity
            AL.Listener(ALListener3f.Velocity, Vector3f.Zero.X, Vector3f.Zero.Y, Vector3f.Zero.Z);
        }

        /// <summary>
        /// Make this sound listener the current.
        /// </summary>
        public void MakeCurrent()
        {
            if (gameElement.ParentScene.AudioListener != gameElement)
            {
                gameElement.ParentScene.AudioListener.GetComponent<AudioListener>().Disable();
                gameElement.ParentScene.SetAudioListener(gameElement);
                Enable();
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
