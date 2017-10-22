using AlienEngine.Core.Physics.PositionUpdating;
using AlienEngine.Core.Physics.CollisionShapes;
using AlienEngine.Core.Physics.Entities;
using AlienEngine.Core.Physics.EntityStateManagement;

namespace AlienEngine
{
    // [RequireComponent(typeof(Collider))]
    public class RigidBody : Component
    {
        private bool _shouldUpdate;
        private Entity _innerRigidBody;
        private MotionState _motionState;
        private EntityShape _collisionShape;
        private float _mass;

        private Vector3f _lastTranslate;
        private Vector3f _lastRotate;
        
        private Collider _geCollider
        {
            get
            {
                return GetComponent<Collider>();
            }
        }

        private Matrix4f _rbWorldTransfom
        {
            get
            {
                return (Matrix4f)_innerRigidBody.WorldTransform;
            }
        }

        public float Mass
        {
            get { return _mass; }
            set { _mass = value; }
        }

        internal Entity InnerRigidBody
        {
            get { return _innerRigidBody; }
        }

        public RigidBody()
        {
            _lastRotate = Vector3f.Zero;
            _lastTranslate = Vector3f.Zero;
            _shouldUpdate = false;
        }

        public override void Start()
        {
            if (HasComponent<Collider>())
            {
                Collider c = _geCollider;
                _collisionShape = c.Shape;

                Transform t = gameElement.WorldTransform;

                _motionState = new MotionState
                {
                    Position = t.Translation,
                    Orientation = Quaternion.FromEulerAngles(t.Rotation.Z, t.Rotation.Y, t.Rotation.X)
                };

                _innerRigidBody = new Entity(_collisionShape, _mass)
                {
                    MotionState = _motionState
                };

                _innerRigidBody.PositionUpdateMode = PositionUpdateMode.Discrete;

                _innerRigidBody.PositionUpdated += _positionUpdated;

                _innerRigidBody.Tag = gameElement.Tag;
                _innerRigidBody.CollisionInformation.Tag = gameElement.Tag;

                gameElement.LocalTransform.OnPositionChange += ((_old, _new) =>
                {
                    if (!_shouldUpdate)
                    {
                        Transform _t = gameElement.WorldTransform;
                        _innerRigidBody.Position += (_t.Translation - _lastTranslate);

                        _lastTranslate = _t.Translation;
                    }
                    // Keep the rigidbody active while moving
                    //if (!_innerRigidBody.IsActive)
                    //{
                    //    _innerRigidBody.ClearForces();
                    //    _innerRigidBody.ProceedToTransform((Matrix)gameElement.WorldTransform.GetTransformation());
                    //}
                });

                gameElement.LocalTransform.OnRotationChange += ((_old, _new) =>
                {
                    if (!_shouldUpdate)
                    {
                        Transform _t = gameElement.WorldTransform;
                        Quaternion _q = Quaternion.FromEulerAngles(t.Rotation.X, t.Rotation.Y, t.Rotation.Z);
                        _innerRigidBody.Orientation = _q;
                        _innerRigidBody.AngularVelocity += (_t.Rotation - _lastRotate);

                        _lastRotate = _t.Rotation;
                    }
                });

                gameElement.ParentScene.RegisterRigidBody(gameElement);

                _lastTranslate = t.Translation;
                _lastRotate = t.Rotation;
            }
        }

        private void _positionUpdated(Entity obj)
        {
            _shouldUpdate = true;
        }

        public override void Update()
        {
            if (_innerRigidBody != null && _shouldUpdate)
            {
                Collider c = _geCollider;
                Transform t = gameElement.WorldTransform;
                // _innerRigidBody.MotionState.WorldTransform = (Matrix)t.GetTransformation();
                // .ActivationState == ActivationState.ActiveTag ? activeColor : passiveColor
                Matrix4f transform = _rbWorldTransfom;
                //gameElement.LocalTransform.Move(transform.GetTranslate());
                //gameElement.LocalTransform.Rotate(transform.GetEulerAngles());

                Vector3f
                    newT = transform.GetTranslate(),
                    newR = transform.GetEulerAngles(),
                    deltaT = newT - _lastTranslate,
                    deltaR = newR - _lastRotate;

                gameElement.LocalTransform.SetTranslation(newT);
                gameElement.LocalTransform.SetRotation(newR);

                _lastRotate = newR;
                _lastTranslate = newT;

                _shouldUpdate = false;
            }
        }

        public override void Stop()
        {
            gameElement.ParentScene.UnregisterRigidBody(gameElement);
        }

        private void _updateMotionState(Transform t)
        {
            _motionState = new MotionState
            {
                Position = t.Translation,
                Orientation = Quaternion.FromEulerAngles(t.Rotation.Z, t.Rotation.Y, t.Rotation.X)
            };
        }
    }
}
