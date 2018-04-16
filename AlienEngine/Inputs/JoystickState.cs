namespace AlienEngine.Core.Inputs
{
    /// <summary>
    /// Describes the state of a joystick.
    /// </summary>
    public struct JoystickState
    {
        /// <summary>
        /// Defines if the joystick is connected or not.
        /// </summary>
        public readonly bool Connected;

        /// <summary>
        /// The name of the joystick.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The ID of the joystick.
        /// </summary>
        /// <remarks>
        /// This field can take values from 1 to 16.
        /// </remarks>
        public readonly int ID;

        /// <summary>
        /// The state of all buttons of the joystick.
        /// </summary>
        public readonly InputState[] Buttons;

        /// <summary>
        /// The state of all axes of the joystick.
        /// </summary>
        public readonly float[] Axes;

        /// <summary>
        /// Construct a new Joystick state.
        /// </summary>
        /// <param name="connected">The device connection state.</param>
        /// <param name="id">The joystick device id.</param>
        /// <param name="name">The joystick's name.</param>
        /// <param name="buttons">The state of all buttons on the joystick.</param>
        /// <param name="axes">The state of all axes on the joystick.</param>
        public JoystickState(bool connected, JoystickDevice id, string name, InputState[] buttons, float[] axes)
        {
            Connected = connected;
            ID = (int) id;
            Name = name;
            Buttons = buttons;
            Axes = axes;
        }

        /// <summary>
        /// Construct a new Joystick state.
        /// </summary>
        /// <param name="connected">The device connection state.</param>
        /// <param name="id">The joystick device id.</param>
        /// <param name="name">The joystick's name.</param>
        /// <param name="buttons">The state of all buttons on the joystick.</param>
        /// <param name="axes">The state of all axes on the joystick.</param>
        public JoystickState(bool connected, JoystickDevice id, string name, bool[] buttons, float[] axes)
        {
            Connected = connected;
            ID = (int)id;
            Name = name;
            Axes = axes;

            if (buttons == null)
            {
                Buttons = null;
                return;
            }

            InputState[] state = new InputState[buttons.Length];

            for (int i = 0, l = buttons.Length; i < l; i++)
                state[i] = buttons[i] ? InputState.Pressed : InputState.Released;

            Buttons = state;
        }

        /// <summary>
        /// Checks if a joystick button is held.
        /// </summary>
        /// <param name="button">The joystick button.</param>
        public bool Holding(JoystickButton button)
        {
            return Connected && Input.Holding((JoystickDevice)ID, button);
        }

        /// <summary>
        /// Checks if a joystick button is pressed.
        /// </summary>
        /// <param name="button">The joystick button.</param>
        public bool Pressed(JoystickButton button)
        {
            return Connected && Input.Pressed((JoystickDevice)ID, button);
        }

        /// <summary>
        /// Checks if a joystick button is released.
        /// </summary>
        /// <param name="button">The joystick button.</param>
        public bool Released(JoystickButton button)
        {
            return Connected && Input.Released((JoystickDevice)ID, button);
        }

        /// <summary>
        /// Returns the value of a joystick axis.
        /// </summary>
        /// <param name="axis">The joystick axis.</param>
        public float Axis(JoystickAxis axis)
        {
            return Connected ? Input.Axis((JoystickDevice)ID, axis) : 0f;
        }
    }
}