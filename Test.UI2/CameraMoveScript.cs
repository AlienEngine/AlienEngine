using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienEngine;

namespace Test.UI
{
    class CameraMoveScript : Component
    {
        Camera _camera;

        public bool InvertY = false;
        public bool InvertX = false;
        public float MouseSensitivity = 1f;
        public float MaxRollAngle = 60f;
        public float MinRollAngle = -30f;

        public override void Start()
        {
            _camera = GetComponent<Camera>();
        }

        public override void Update()
        {
            float _internalMinRollAngle = MathHelper.Deg2Rad(MinRollAngle);
            float _internalMaxRollAngle = MathHelper.Deg2Rad(MaxRollAngle);

            float movSpeed = (float)(50f * Time.DeltaTime);
            float rotSpeed = (float)(MathHelper.PiOver4 * Time.DeltaTime);

            if (Input.Holding(KeyCode.Numpad8))
            {
                gameElement.LocalTransform.Move(_camera.Backward, movSpeed);
            }
            if (Input.Holding(KeyCode.Numpad5))
            {
                gameElement.LocalTransform.Move(_camera.Forward, movSpeed);
            }
            if (Input.Holding(KeyCode.Numpad4))
            {
                gameElement.LocalTransform.Move(_camera.Left, movSpeed);
            }
            if (Input.Holding(KeyCode.Numpad6))
            {
                gameElement.LocalTransform.Move(_camera.Right, movSpeed);
            }
            if (Input.Holding(KeyCode.Numpad7))
            {
                gameElement.LocalTransform.Move(_camera.Up, movSpeed);
            }
            if (Input.Holding(KeyCode.Numpad9))
            {
                gameElement.LocalTransform.Move(_camera.Down, movSpeed);
            }
            if (Input.Holding(KeyCode.A))
            {
                _camera.Pitch(rotSpeed);
            }
            if (Input.Holding(KeyCode.D))
            {
                _camera.Pitch(-rotSpeed);
            }
            if (Input.Holding(KeyCode.W))
            {
                _camera.Roll(rotSpeed);
            }
            if (Input.Holding(KeyCode.S))
            {
                _camera.Roll(-rotSpeed);
            }
            if (Input.Holding(KeyCode.Q))
            {
                _camera.Yaw(rotSpeed);
            }
            if (Input.Holding(KeyCode.E))
            {
                _camera.Yaw(-rotSpeed);
            }
            if (Input.Pressed(KeyCode.P))
            {
                if (_camera.ProjectionType == Camera.ProjectionTypes.Orthogonal)
                    _camera.ProjectionType = Camera.ProjectionTypes.Perspective;
                else
                    _camera.ProjectionType = Camera.ProjectionTypes.Orthogonal;
            }
            if (Input.Pressed(KeyCode.C))
            {
                if (_camera.ClearScreenType == Camera.ClearScreenTypes.Color)
                    _camera.ClearScreenType = Camera.ClearScreenTypes.Cubemap;
                else
                    _camera.ClearScreenType = Camera.ClearScreenTypes.Color;
            }

            if (Input.Pressed(MouseButton.LeftClick))
            {
                if (Input.GetCursorState() != CursorState.Grabbed)
                    Input.GrabMouse(true);
                else
                    Input.GrabMouse(false);
            }

            if (Input.GetCursorState() == CursorState.Grabbed)
            {
                if (InvertX)
                    _camera.Pitch((Input.MousePosition.X - Input.PreviousMousePosition.X) * MouseSensitivity * Time.DeltaTime);
                else
                    _camera.Pitch((Input.PreviousMousePosition.X - Input.MousePosition.X) * MouseSensitivity * Time.DeltaTime);

                if (InvertY)
                {
                    float angle = (float)((Input.MousePosition.Y - Input.PreviousMousePosition.Y) * MouseSensitivity * Time.DeltaTime);
                    if (MathHelper.Between(_camera.RollPicthYaw.X + angle, _internalMinRollAngle, _internalMaxRollAngle))
                        _camera.Roll(angle);
                    else
                        _camera.SetRoll(MathHelper.Clamp(_camera.RollPicthYaw.X + angle, _internalMinRollAngle, _internalMaxRollAngle));
                }
                else
                {
                    float angle = (float)((Input.PreviousMousePosition.Y - Input.MousePosition.Y) * MouseSensitivity * Time.DeltaTime);
                    if (MathHelper.Between(_camera.RollPicthYaw.X + angle, _internalMinRollAngle, _internalMaxRollAngle))
                        _camera.Roll(angle);
                    else
                        _camera.SetRoll(MathHelper.Clamp(_camera.RollPicthYaw.X + angle, MathHelper.Deg2Rad(MinRollAngle), MathHelper.Deg2Rad(MaxRollAngle)));
                }
            }
        }
    }
}
