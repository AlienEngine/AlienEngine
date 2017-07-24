namespace AlienEngine
{
    /// <summary>
    /// <para>Keyboard keys.</para>
    /// 
    /// <para>These key codes are inspired by the USB HID Usage Tables v1.12 (p. 53-60), but
    /// re-arranged to map to 7-bit ASCII for printable keys(function keys are put in the 256+
    /// range).</para>
    /// </summary>
    public enum KeyCode : int
    {
        /// <summary>
        /// An unknown key.
        /// </summary>
        Unknown = -1,

        /// <summary>
        ///  
        /// </summary>
        Space = 32,

        /// <summary>
        /// '
        /// </summary>
        Apostrophe = 39,

        /// <summary>
        /// ,
        /// </summary>
        Comma = 44,

        /// <summary>
        /// -
        /// </summary>
        Minus = 45,

        /// <summary>
        /// .
        /// </summary>
        Period = 46,

        /// <summary>
        /// /
        /// </summary>
        Slash = 47,

        /// <summary>
        /// Alphabetical 0 key
        /// </summary>
        Alpha0 = 48,

        /// <summary>
        /// Alphabetical 1 key
        /// </summary>
        Alpha1 = 49,

        /// <summary>
        /// Alphabetical 2 key
        /// </summary>
        Alpha2 = 50,

        /// <summary>
        /// Alphabetical 3 key
        /// </summary>
        Alpha3 = 51,

        /// <summary>
        /// Alphabetical 4 key
        /// </summary>
        Alpha4 = 52,

        /// <summary>
        /// Alphabetical 5 key
        /// </summary>
        Alpha5 = 53,

        /// <summary>
        /// Alphabetical 6 key
        /// </summary>
        Alpha6 = 54,

        /// <summary>
        /// Alphabetical 7 key
        /// </summary>
        Alpha7 = 55,

        /// <summary>
        /// Alphabetical 8 key
        /// </summary>
        Alpha8 = 56,

        /// <summary>
        /// Alphabetical 9 key
        /// </summary>
        Alpha9 = 57,

        /// <summary>
        /// ;
        /// </summary>
        SemiColon = 59,

        /// <summary>
        /// =
        /// </summary>
        Equal = 61,

        /// <summary>
        /// A
        /// </summary>
        A = 65,

        /// <summary>
        /// B
        /// </summary>
        B = 66,

        /// <summary>
        /// C
        /// </summary>
        C = 67,

        /// <summary>
        /// D
        /// </summary>
        D = 68,

        /// <summary>
        /// E
        /// </summary>
        E = 69,

        /// <summary>
        /// F
        /// </summary>
        F = 70,

        /// <summary>
        /// G
        /// </summary>
        G = 71,

        /// <summary>
        /// H
        /// </summary>
        H = 72,

        /// <summary>
        /// I
        /// </summary>
        I = 73,

        /// <summary>
        /// J
        /// </summary>
        J = 74,

        /// <summary>
        /// K
        /// </summary>
        K = 75,

        /// <summary>
        /// L
        /// </summary>
        L = 76,

        /// <summary>
        /// M
        /// </summary>
        M = 77,

        /// <summary>
        /// N
        /// </summary>
        N = 78,

        /// <summary>
        /// O
        /// </summary>
        O = 79,

        /// <summary>
        /// P
        /// </summary>
        P = 80,

        /// <summary>
        /// Q
        /// </summary>
        Q = 81,

        /// <summary>
        /// R
        /// </summary>
        R = 82,

        /// <summary>
        /// S
        /// </summary>
        S = 83,

        /// <summary>
        /// T
        /// </summary>
        T = 84,

        /// <summary>
        /// U
        /// </summary>
        U = 85,

        /// <summary>
        /// V
        /// </summary>
        V = 86,

        /// <summary>
        /// W
        /// </summary>
        W = 87,

        /// <summary>
        /// X
        /// </summary>
        X = 88,

        /// <summary>
        /// Y
        /// </summary>
        Y = 89,

        /// <summary>
        /// Z
        /// </summary>
        Z = 90,

        /// <summary>
        /// [
        /// </summary>
        LeftBracket = 91,

        /// <summary>
        /// \
        /// </summary>
        Backslash = 92,

        /// <summary>
        /// ]
        /// </summary>
        RightBracket = 93,

        /// <summary>
        /// `
        /// </summary>
        GraveAccent = 96,

        /// <summary>
        /// Non-US #1
        /// </summary>
        World1 = 161,

        /// <summary>
        /// Non-US #2
        /// </summary>
        World2 = 162,

        /// <summary>
        /// Escape key
        /// </summary>
        Escape = 256,

        /// <summary>
        /// Enter key
        /// </summary>
        Enter = 257,

        /// <summary>
        /// Tab key
        /// </summary>
        Tab = 258,

        /// <summary>
        /// Backspace key
        /// </summary>
        Backspace = 259,

        /// <summary>
        /// Insert key
        /// </summary>
        Insert = 260,

        /// <summary>
        /// Delete key
        /// </summary>
        Delete = 261,

        /// <summary>
        /// Right arrow key
        /// </summary>
        Right = 262,

        /// <summary>
        /// Left arrow key
        /// </summary>
        Left = 263,

        /// <summary>
        /// Down arrow key
        /// </summary>
        Down = 264,

        /// <summary>
        /// Up arrow key
        /// </summary>
        Up = 265,

        /// <summary>
        /// Page up key
        /// </summary>
        PageUp = 266,

        /// <summary>
        /// Page down key
        /// </summary>
        PageDown = 267,

        /// <summary>
        /// Home key
        /// </summary>
        Home = 268,

        /// <summary>
        /// End key
        /// </summary>
        End = 269,

        /// <summary>
        /// Capslock key
        /// </summary>
        CapsLock = 280,

        /// <summary>
        /// Scroll lock key
        /// </summary>
        ScrollLock = 281,

        /// <summary>
        /// Num lock key
        /// </summary>
        NumLock = 282,

        /// <summary>
        /// Print screen key
        /// </summary>
        PrintScreen = 283,

        /// <summary>
        /// Pause key
        /// </summary>
        Pause = 284,

        /// <summary>
        /// F1
        /// </summary>
        F1 = 290,

        /// <summary>
        /// F2
        /// </summary>
        F2 = 291,

        /// <summary>
        /// F3
        /// </summary>
        F3 = 292,

        /// <summary>
        /// F4
        /// </summary>
        F4 = 293,

        /// <summary>
        /// F5
        /// </summary>
        F5 = 294,

        /// <summary>
        /// F6
        /// </summary>
        F6 = 295,

        /// <summary>
        /// F7
        /// </summary>
        F7 = 296,

        /// <summary>
        /// F8
        /// </summary>
        F8 = 297,

        /// <summary>
        /// F9
        /// </summary>
        F9 = 298,

        /// <summary>
        /// F10
        /// </summary>
        F10 = 299,

        /// <summary>
        /// F11
        /// </summary>
        F11 = 300,

        /// <summary>
        /// F12
        /// </summary>
        F12 = 301,

        /// <summary>
        /// F13
        /// </summary>
        F13 = 302,

        /// <summary>
        /// F14
        /// </summary>
        F14 = 303,

        /// <summary>
        /// F15
        /// </summary>
        F15 = 304,

        /// <summary>
        /// F16
        /// </summary>
        F16 = 305,

        /// <summary>
        /// F17
        /// </summary>
        F17 = 306,

        /// <summary>
        /// F18
        /// </summary>
        F18 = 307,

        /// <summary>
        /// F19
        /// </summary>
        F19 = 308,

        /// <summary>
        /// F20
        /// </summary>
        F20 = 309,

        /// <summary>
        /// F21
        /// </summary>
        F21 = 310,

        /// <summary>
        /// F22
        /// </summary>
        F22 = 311,

        /// <summary>
        /// F23
        /// </summary>
        F23 = 312,

        /// <summary>
        /// F24
        /// </summary>
        F24 = 313,

        /// <summary>
        /// F25
        /// </summary>
        F25 = 314,

        /// <summary>
        /// Numpad 0
        /// </summary>
        Numpad0 = 320,

        /// <summary>
        /// Numpad 1
        /// </summary>
        Numpad1 = 321,

        /// <summary>
        /// Numpad 2
        /// </summary>
        Numpad2 = 322,

        /// <summary>
        /// Numpad 3
        /// </summary>
        Numpad3 = 323,

        /// <summary>
        /// Numpad 4
        /// </summary>
        Numpad4 = 324,

        /// <summary>
        /// Numpad 5
        /// </summary>
        Numpad5 = 325,

        /// <summary>
        /// Numpad 6
        /// </summary>
        Numpad6 = 326,

        /// <summary>
        /// Numpad 7
        /// </summary>
        Numpad7 = 327,

        /// <summary>
        /// Numpad 8
        /// </summary>
        Numpad8 = 328,

        /// <summary>
        /// Numpad 9
        /// </summary>
        Numpad9 = 329,

        /// <summary>
        /// Numpad .
        /// </summary>
        NumpadDecimal = 330,

        /// <summary>
        /// Numpad /
        /// </summary>
        NumpadDivide = 331,

        /// <summary>
        /// Numpad *
        /// </summary>
        NumpadMultiply = 332,

        /// <summary>
        /// Numpad -
        /// </summary>
        NumpadSubtract = 333,

        /// <summary>
        /// Numpad +
        /// </summary>
        NumpadAdd = 334,

        /// <summary>
        /// Numpad Enter key
        /// </summary>
        NumpadEnter = 335,

        /// <summary>
        /// Numpad =
        /// </summary>
        NumpadEqual = 336,

        /// <summary>
        /// Left shift key
        /// </summary>
        LeftShift = 340,

        /// <summary>
        /// Left control key
        /// </summary>
        LeftControl = 341,

        /// <summary>
        /// Left alt key
        /// </summary>
        LeftAlt = 342,

        /// <summary>
        /// Numpad super key
        /// </summary>
        LeftSuper = 343,

        /// <summary>
        /// Right shift key
        /// </summary>
        RightShift = 344,

        /// <summary>
        /// Right control key
        /// </summary>
        RightControl = 345,

        /// <summary>
        /// Right alt key
        /// </summary>
        RightAlt = 346,

        /// <summary>
        /// Right super key
        /// </summary>
        RightSuper = 347,

        /// <summary>
        /// Menu key
        /// </summary>
        Menu = 348,

        /// <summary>
        /// All key
        /// </summary>
        All = int.MaxValue
    }
}
