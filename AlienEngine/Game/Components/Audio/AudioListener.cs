using AlienEngine.Core.Audio.OpenAL;

namespace AlienEngine
{
    public class AudioListener : Component
    {
        private Vector3f _lastPos;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AudioListener() : this(Vector3f.Zero, 1f, 1f)
        { }

        public AudioListener(Vector3f velocity, float efxMetersPerUnit, float gain)
        {
            AL.Listener(ALListener3f.Velocity, ref velocity);
            AL.Listener(ALListenerf.EfxMetersPerUnit, efxMetersPerUnit);
            AL.Listener(ALListenerf.Gain, gain);
        }

        /// <summary>
        /// The velocity of the sound listener
        /// </summary>
        /// <returns>The <see cref="Vector3f"/> of the velocity.</returns>
        public Vector3f Velocity
        {
            get
            {
                Vector3f v;
                AL.GetListener(ALListener3f.Velocity, out v);
                return v;
            }
        }

        /// <summary>
        /// The EFX meters per unit of the sound listener
        /// </summary>
        /// <returns>The EFX meters per unit.</returns>
        public float EfxMetersPerUnit
        {
            get
            {
                float m;
                AL.GetListener(ALListenerf.EfxMetersPerUnit, out m);
                return m;
            }
        }

        /// <summary>
        /// The gain of the sound listener.
        /// </summary>
        /// <returns>The gain.</returns>
        public float Gain
        {
            get
            {
                float g;
                AL.GetListener(ALListenerf.EfxMetersPerUnit, out g);
                return g;
            }
        }

        public override void Start()
        {
            MakeCurrent();

            Transform defT = gameElement.WorldTransform;
            Vector3f defPos = defT.Translation, defAt = defT.ForwardVector, defUp = defT.UpVector;

            AL.Listener(ALListener3f.Position, ref defPos);
            AL.Listener(ALListenerfv.Orientation, ref defAt, ref defUp);

            gameElement.LocalTransform.OnPositionChange += ((_old, _new) =>
            {
                Vector3f pos = gameElement.WorldTransform.Translation;
                AL.Listener(ALListener3f.Position, ref pos);
            });

            gameElement.LocalTransform.OnRotationChange += ((_old, _new) =>
            {
                Transform transform = gameElement.WorldTransform;
                Vector3f _forward = transform.ForwardVector,
                         _up = transform.UpVector;

                AL.Listener(ALListenerfv.Orientation, ref _forward, ref _up);
            });

            _lastPos = defPos;
        }

        public override void Update()
        {
            // Update Velocity
            Vector3f _newPos = gameElement.WorldTransform.Translation;
            Vector3f vel = (_newPos - _lastPos);
            AL.Listener(ALListener3f.Velocity, ref vel);
            _lastPos = _newPos;
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
        /// Changes the EFX meters per unit of this listener.
        /// </summary>
        /// <param name="efxMetersPerUnit">The new EFX meters per unit.</param>
        public void SetEfxMetersPerUnit(float efxMetersPerUnit)
        {
            AL.Listener(ALListenerf.EfxMetersPerUnit, EfxMetersPerUnit);
        }

        /// <summary>
        /// Changes the gain of this listener.
        /// </summary>
        /// <param name="gain">The new gain.</param>
        public void SetGain(float gain)
        {
            AL.Listener(ALListenerf.Gain, Gain);
        }
    }
}
