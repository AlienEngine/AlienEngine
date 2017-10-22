using System;
using System.Collections.Generic;

using AlienEngine;
using AlienEngine.Core.Graphics.OpenGL;

namespace AlienEngine.UI
{
    public static class UserInterface
    {
        #region Variables
        private static Matrix4f _projectionMatrix;

        private static Transform _transform;

        private static Matrix4f _uiCamera = Matrix4f.Look(Vector3f.UnitZ, Vector3f.UnitY);

        public static UIContainer UIWindow;

        private static uint uniqueID = 0;

        public static Dictionary<string, UIElement> Elements;

        internal static Matrix4f UIProjectionMatrix
        {
            get { return _projectionMatrix; }
            set
            {
                _projectionMatrix = value;
                Shaders.UpdateUIProjectionMatrix(_projectionMatrix);
            }
        }

        public static Transform Transform
        {
            get { return _transform; }
            set
            {
                _transform = value;
                _updateProjectionMatrix();
            }
        }

        public static UIElement Selection;

        public static bool Visible { get; set; }

        public static int Width { get; set; }

        public static int Height { get; set; }

        public static int MainThreadID { get; private set; }

        private static Stack<UIContainer> activeContainerStack = new Stack<UIContainer>();

        public static Stack<UIContainer> ActiveContainer
        {
            get { return activeContainerStack; }
        }
        #endregion

        #region Initialization and Adding/Removing Elements
        public static void InitUI(int width, int height)
        {
            if (Shaders.Init())
            {
                Elements = new Dictionary<string, UIElement>();
                Transform = new Transform();

                Transform.AddOnChangeEvent((o, n) => { _updateProjectionMatrix(); OnMouseMove((int)Input.MousePosition.X, (int)Input.MousePosition.Y); });

                // create the default top level screen container
                UIWindow = new UIContainer(new Point2i(0, 0), new Sizei(UserInterface.Width, UserInterface.Height), "TopLevel");
                UIWindow.RelativeTo = Corner.BottomLeft;
                Elements.Add("Screen", UIWindow);

                _updateProjectionMatrix();

                Visible = true;

                MainThreadID = System.Threading.Thread.CurrentThread.ManagedThreadId;

                OnResize(width, height);
            }
        }

        private static void _updateProjectionMatrix()
        {
            UIProjectionMatrix = Transform.GetTransformation() * Matrix4f.CreateTranslation(new Vector3f(-UserInterface.Width / 2, -UserInterface.Height / 2, 0)) * _uiCamera * Matrix4f.CreateOrthographic(UserInterface.Width, UserInterface.Height, 0, 1000);
        }

        public static void AddElement(UIElement Element)
        {
            UIWindow.AddElement(Element);
        }

        public static void RemoveElement(UIElement Element)
        {
            UIWindow.RemoveElement(Element);
        }

        public static void ClearElements()
        {
            UIWindow.ClearElements();
        }

        public static UIElement GetElement(string name)
        {
            UIElement element = null;
            Elements.TryGetValue(name, out element);
            return element;
        }
        #endregion

        #region Methods
        public static void Draw()
        {
            if (!Visible || UIWindow == null) return;

            bool depthTest = GL.GetBoolean(GetPName.DepthTest);
            bool blending = GL.GetBoolean(GetPName.Blend);
            if (depthTest)
            {
                GL.Disable(EnableCap.DepthTest);
                GL.DepthMask(false);
            }

            UIWindow.Draw();

            if (depthTest)
            {
                GL.DepthMask(true);
                GL.Enable(EnableCap.DepthTest);
            }
            if (blending) GL.Enable(EnableCap.Blend);
        }

        public static uint GetUniqueElementID()
        {
            return uniqueID++;
        }

        private static void Update(float delta)
        {
            UIWindow.Update();
        }

        public static void OnResize(int width, int height)
        {
            UserInterface.Width = width;
            UserInterface.Height = height;

            _updateProjectionMatrix();

            if (UIWindow == null) return;
            UIWindow.Size = new Sizei(UserInterface.Width, UserInterface.Height);
            UIWindow.OnResize();
        }

        public static bool Pick(Point2i Location)
        {
            if (UIWindow == null) return false;

            if ((Selection = UIWindow.PickChildren(new Point2i(Location.X, UserInterface.Height - Location.Y))) != null)
            {
                if (Selection == UIWindow) return false;
                else return true;
            }

            return false;
        }

        public static void Dispose()
        {
            Shaders.Dispose();

            List<UIElement> elements = new List<UIElement>();
            foreach (var item in Elements)
                elements.Add(item.Value);

            for (int i = elements.Count - 1; i >= 0; i--)
                elements[i].Dispose();

            Elements.Clear();
            elements.Clear();
            elements = null;
        }
        #endregion

        #region Mouse Callbacks
        private static UIElement currentSelection = null, activeSelection = null;

        private static Click mousePosition, lmousePosition;            // the current and previous mouse position and button

        /// <summary>
        /// The current mouse state (position and button press).
        /// </summary>
        public static Click MousePosition
        {
            get { return mousePosition; }
            set { lmousePosition = mousePosition; mousePosition = value; }
        }

        /// <summary>
        /// The previous state of the mouse (position and button press).
        /// </summary>
        public static Click LastMousePosition
        {
            get { return lmousePosition; }
            set { lmousePosition = value; }
        }

        /// <summary>
        /// The current object that has focus (the last object clicked).
        /// </summary>
        public static IMouseInput Focus 
        { 
            get; 
            set; 
        }

        public static bool OnMouseMove(int x, int y)
        {
            UIElement lastSelection = currentSelection;
            MousePosition = new Click((int)(x - UserInterface.Transform.Position.X), (int)(y + UserInterface.Transform.Position.Y), false, false, false, false);
            Point2i position = new Point2i(MousePosition.X, MousePosition.Y);

            if (currentSelection != null && currentSelection.OnMouseMove != null) currentSelection.OnMouseMove(null, new MouseEventArgs(MousePosition, LastMousePosition));

            if (UserInterface.Pick(position))
                currentSelection = UserInterface.Selection;
            else currentSelection = null;

            if (currentSelection != lastSelection)
            {
                if (lastSelection != null && lastSelection.OnMouseLeave != null) lastSelection.OnMouseLeave(null, new MouseEventArgs(MousePosition, LastMousePosition));
                if (currentSelection != null && currentSelection.OnMouseEnter != null) currentSelection.OnMouseEnter(null, new MouseEventArgs(MousePosition, LastMousePosition));
            }

            return (currentSelection != null);
        }

        public static bool OnMouseClick(Input.MouseButton button, Input.InputState state, int x, int y)
        {
            MousePosition = new Click((int)(x - UserInterface.Transform.Position.X), (int)(y + UserInterface.Transform.Position.Y), button, state);

            // call OnLoseFocus if a control lost focus
            if (MousePosition.State == Input.InputState.Press)
            {
                if (Focus != null && currentSelection != Focus && Focus.OnLoseFocus != null) Focus.OnLoseFocus(null, currentSelection);
                Focus = currentSelection;
            }

            if (activeSelection != null && MousePosition.State == Input.InputState.Release)
            {
                // if mouseup while a pickable object is active
                if (activeSelection.OnMouseUp != null) activeSelection.OnMouseUp(null, new MouseEventArgs(MousePosition, LastMousePosition));
                activeSelection = null;
            }
            else if (currentSelection != null && !(currentSelection is UIContainer))
            {
                // if the mouse is current over a pickable object and clicks
                if (MousePosition.State == Input.InputState.Press)
                {
                    if (currentSelection.OnMouseDown != null) currentSelection.OnMouseDown(null, new MouseEventArgs(MousePosition, LastMousePosition));
                    activeSelection = currentSelection;
                }
                else
                {
                    if (currentSelection.OnMouseUp != null) currentSelection.OnMouseUp(null, new MouseEventArgs(MousePosition, LastMousePosition));
                    activeSelection = null;
                }
                if (currentSelection.OnMouseClick != null) currentSelection.OnMouseClick(null, new MouseEventArgs(MousePosition, LastMousePosition));
            }

            return (activeSelection != null);
        }
        #endregion

        #region Keyboard Callbacks
        #endregion
    }
}
