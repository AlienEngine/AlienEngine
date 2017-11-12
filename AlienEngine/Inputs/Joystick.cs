﻿using System;
using System.Collections.Generic;
using AlienEngine.Core.Graphics.GLFW;

namespace AlienEngine.Core.Inputs
{
    internal static class Joystick
    {
        /// <summary>
        /// The list of joystick states.
        /// </summary>
        private static List<JoystickState> _joystickStates;

        /// <summary>
        /// An array of joysticks.
        /// </summary>
        private static Array _allJoysticks;

        /// <summary>
        /// Initialize the joystick manager.
        /// </summary>
        static Joystick()
        {
            _allJoysticks = Enum.GetValues(typeof(JoystickDevice));
            _joystickStates = new List<JoystickState>();
        }

        /// <summary>
        /// Updates Joystick input manager on each frames.
        /// </summary>
        public static void Update()
        {
            _joystickStates.Clear();
            foreach (JoystickDevice i in _allJoysticks)
            {
                JoystickState state = new JoystickState(
                    IsPresent(i),
                    i,
                    GetName(i),
                    GLFW.GetJoystickButtons(i),
                    GLFW.GetJoystickAxes(i)
                );

                _joystickStates.Add(state);
            }
        }

        /// <summary>
        /// Checks if a joystick button is held.
        /// </summary>
        /// <param name="joystick">The joystick device.</param>
        /// <param name="button">The button.</param>
        public static bool GetButton(JoystickDevice joystick, int button)
        {
            if (button <= 0)
                throw new ArgumentOutOfRangeException(nameof(button), "The value must be positive and greater than 0.");

            var states = GLFW.GetJoystickButtons(joystick);

            return states[button - 1];
        }

        /// <summary>
        /// Checks if a joystick button is held.
        /// </summary>
        /// <param name="joystick">The joystick device.</param>
        /// <param name="button">The button.</param>
        public static bool GetButtonDown(JoystickDevice joystick, int button)
        {
            if (button <= 0)
                throw new ArgumentOutOfRangeException(nameof(button), "The value must be positive and greater than 0.");

            return GetButton(joystick, button)
                && _joystickStates.Count > (int)joystick
                && _joystickStates[(int)joystick].Buttons != null
                && _joystickStates[(int)joystick].Buttons[button - 1] == InputState.Released;
        }

        /// <summary>
        /// Checks if a joystick button is held.
        /// </summary>
        /// <param name="joystick">The joystick device.</param>
        /// <param name="button">The button.</param>
        public static bool GetButtonUp(JoystickDevice joystick, int button)
        {
            if (button <= 0)
                throw new ArgumentOutOfRangeException(nameof(button), "The value must be positive and greater than 0.");

            return !GetButton(joystick, button)
                && _joystickStates.Count > (int)joystick
                && _joystickStates[(int)joystick].Buttons != null
                && _joystickStates[(int)joystick].Buttons[button - 1] == InputState.Pressed;
        }

        /// <summary>
        /// Returns the value of an axis.
        /// </summary>
        /// <param name="joystick">The joystick device.</param>
        /// <param name="axis">The axis.</param>
        public static float GetAxis(JoystickDevice joystick, int axis)
        {
            if (axis <= 0)
                throw new ArgumentOutOfRangeException(nameof(axis), "The value must be positive and greater than 0.");

            var states = GLFW.GetJoystickAxes(joystick);

            return states[axis - 1];
        }

        /// <summary>
        /// Returns the state of the given joystick device.
        /// </summary>
        /// <param name="joystick">The joystick device.</param>
        public static JoystickState GetJoystickState(JoystickDevice joystick)
        {
            if (_joystickStates.Count <= (int)joystick)
                return new JoystickState();

            return _joystickStates[(int)joystick];
        }

        /// <summary>
        /// Checks if the given <paramref name="joystick"/> is connected.
        /// </summary>
        /// <param name="joystick">The joystick devive.</param>
        public static bool IsPresent(JoystickDevice joystick) => GLFW.JoystickPresent(joystick);

        /// <summary>
        /// Returns the name of the given <paramref name="joystick"/>.
        /// </summary>
        /// <param name="joystick">The joystick device.</param>
        /// <returns>The <paramref name="joystick"/>'s name if it's connected and an empty string otherwise.</returns>
        public static string GetName(JoystickDevice joystick) => GLFW.GetJoystickName(joystick);
    }
}
