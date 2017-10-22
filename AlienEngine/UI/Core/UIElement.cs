using System;
using System.Collections;

using AlienEngine.Graphics;
using AlienEngine.Core.Graphics.OpenGL;
using AlienEngine.Graphics.Shaders;

namespace AlienEngine.UI
{
    public interface IMouseInput
    {
        #region Interface Properties
        OnMouse OnMouseClick { get; set; }

        OnMouse OnMouseEnter { get; set; }

        OnMouse OnMouseLeave { get; set; }

        OnMouse OnMouseDown { get; set; }

        OnMouse OnMouseUp { get; set; }

        OnMouse OnMouseMove { get; set; }

        OnMouse OnMouseRepeat { get; set; }

        OnFocus OnLoseFocus { get; set; }
        #endregion
    }

    #region Enumerations
    public enum Corner
    {
        BottomLeft,
        BottomRight,
        TopLeft,
        TopRight,
        CenterBottom,
        CenterTop,
        Fill,
        Center,
        CenterLeft,
        CenterRight
    };

    public enum Orientation
    {
        Horizontal,
        Vertical
    };
    #endregion

    #region Structures
    public struct Invokable
    {
        public OnInvoke Method;
        public object Parameter;

        public Invokable(OnInvoke Method, object arg)
        {
            this.Method = Method;
            this.Parameter = arg;
        }
    }
    #endregion

    #region Delegates
    public delegate void OnChanged(object sender, EventArgs e);

    public delegate void OnInvoke(object arg);

    public delegate void OnMouse(object sender, MouseEventArgs e);

    public delegate void OnFocus(object sender, IMouseInput newFocus);
    #endregion

    public interface IUserInterface : IDisposable
    {
        #region Interface Properties
        float Alpha { get; set; }

        Point2i Position { get; set; }

        Sizei Size { get; set; }

        Sizei MinSize { get; set; }

        Sizei MaxSize { get; set; }

        Corner RelativeTo { get; set; }

        UIContainer Parent { get; set; }

        ShaderProgram Program { get; }

        string Name { get; set; }

        void Draw();

        void OnResize();

        void Update();

        void Invalidate();

        void Invoke(OnInvoke Method, object arg);
        #endregion
    }

    public abstract class UIElement : IUserInterface, IMouseInput
    {
        #region Interface Overrides
        public float Alpha { get; set; }

        public Point2i Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _updateCorrectedPositionFromCorner();
            }
        }

        private Sizei _size;
        public Sizei Size
        {
            get { return _size; }
            set
            {
                if (MaxSize.X == 0 || MaxSize.Y == 0) MaxSize = new Sizei(int.MaxValue, int.MaxValue);
                _size = Sizei.Max(MinSize, Sizei.Min(MaxSize, value));
                _updateCorrectedPositionFromCorner();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_uiQuad != null)
            {
                _uiQuad.DisposeChildren = true;
                _uiQuad.Dispose();
                _uiQuad = null;
            }

            if (Parent == null)
                UserInterface.RemoveElement(this);
            else
                Parent.RemoveElement(this);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Sizei MinSize { get; set; }

        public Sizei MaxSize { get; set; }

        public Point2i CorrectedPosition { get; set; }

        public Corner RelativeTo
        {
            get { return _relativeTo; }
            set
            {
                _relativeTo = value;
                _updateCorrectedPositionFromCorner();
            }
        }

        public string Name { get; set; }

        public OnMouse OnMouseClick { get; set; }

        public OnMouse OnMouseEnter { get; set; }

        public OnMouse OnMouseLeave { get; set; }

        public OnMouse OnMouseDown { get; set; }

        public OnMouse OnMouseUp { get; set; }

        public OnMouse OnMouseMove { get; set; }

        public OnMouse OnMouseRepeat { get; set; }

        public OnFocus OnLoseFocus { get; set; }

        public UIContainer Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
                _updateCorrectedPositionFromCorner();
            }
        }

        public bool DisablePicking { get; set; }

        public ShaderProgram Program { get; protected set; }

        private bool visible = true;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public virtual void Draw()
        {
            DoInvoke();

            if (BackgroundTexture != null) DrawQuadTextured();
            else DrawQuadColored();
        }

        public virtual void OnResize()
        {
            _updateCorrectedPositionFromCorner();

            if (BackgroundColor != Color4.Transparent || BackgroundTexture != null)
            {
                if (_uiQuad != null)
                {
                    _uiQuad.DisposeChildren = true;
                    _uiQuad.Dispose();
                }
                _uiQuad = Geometry.CreateQuad(Shaders.SolidUIShader, Vector2f.Zero, new Vector2f(Size.Width, Size.Height), Vector2f.Zero, Vector2f.One);
            }

            Invalidate();
        }

        private void _updateCorrectedPositionFromCorner()
        {
            if (Parent == null)
            {
                switch (RelativeTo)
                {
                    case Corner.BottomLeft:
                        CorrectedPosition = Position;
                        break;
                    case Corner.BottomRight:
                        CorrectedPosition = new Point2i(UserInterface.Width - Position.X - Size.Width, Position.Y);
                        break;
                    case Corner.TopLeft:
                        CorrectedPosition = new Point2i(Position.X, UserInterface.Height - Position.Y - Size.Height);
                        break;
                    case Corner.TopRight:
                        CorrectedPosition = new Point2i(UserInterface.Width - Position.X - Size.Width, UserInterface.Height - Position.Y - Size.Height);
                        break;
                    case Corner.CenterBottom:
                        CorrectedPosition = new Point2i(UserInterface.Width / 2 - Size.Width / 2 + Position.X, Position.Y);
                        break;
                    case Corner.CenterTop:
                        CorrectedPosition = new Point2i(UserInterface.Width / 2 - Size.Width / 2 + Position.X, UserInterface.Height - Position.Y - Size.Height);
                        break;
                    case Corner.Fill:
                        CorrectedPosition = new Point2i(0, 0);
                        _size = new Sizei(UserInterface.Width, UserInterface.Height);
                        break;
                    case Corner.Center:
                        CorrectedPosition = new Point2i(UserInterface.Width / 2 - Size.Width / 2 + Position.X, UserInterface.Height / 2 - Size.Height / 2 + Position.Y);
                        break;
                    case Corner.CenterLeft:
                        CorrectedPosition = new Point2i(Position.X, UserInterface.Height / 2 - Size.Height / 2 + Position.Y);
                        break;
                    case Corner.CenterRight:
                        CorrectedPosition = new Point2i(UserInterface.Width - Position.X - Size.Width, UserInterface.Height / 2 - Size.Height / 2 + Position.Y);
                        break;
                }
            }
            else
            {
                switch (RelativeTo)
                {
                    case Corner.BottomLeft:
                        CorrectedPosition = Position;
                        break;
                    case Corner.BottomRight:
                        CorrectedPosition = new Point2i(Parent.Size.Width - Position.X - Size.Width, Position.Y);
                        break;
                    case Corner.TopLeft:
                        CorrectedPosition = new Point2i(Position.X, Parent.Size.Height - Position.Y - Size.Height);
                        break;
                    case Corner.TopRight:
                        CorrectedPosition = new Point2i(Parent.Size.Width - Position.X - Size.Width, Parent.Size.Height - Position.Y - Size.Height);
                        break;
                    case Corner.CenterBottom:
                        CorrectedPosition = new Point2i(Parent.Size.Width / 2 - Size.Width / 2 + Position.X, Position.Y);
                        break;
                    case Corner.CenterTop:
                        CorrectedPosition = new Point2i(Parent.Size.Width / 2 - Size.Width / 2 + Position.X, Parent.Size.Height - Position.Y - Size.Height);
                        break;
                    case Corner.Fill:
                        CorrectedPosition = new Point2i(0, 0);
                        _size = Parent.Size;
                        break;
                    case Corner.Center:
                        CorrectedPosition = new Point2i(Parent.Size.Width / 2 - Size.Width / 2 + Position.X, Parent.Size.Height / 2 - Size.Height / 2 + Position.Y);
                        break;
                    case Corner.CenterLeft:
                        CorrectedPosition = new Point2i(Position.X, Parent.Size.Height / 2 - Size.Height / 2 + Position.Y);
                        break;
                    case Corner.CenterRight:
                        CorrectedPosition = new Point2i(Parent.Size.Width - Position.X - Size.Width, Parent.Size.Height / 2 - Size.Height / 2 + Position.Y);
                        break;
                }
                CorrectedPosition += Parent.CorrectedPosition;
            }
        }

        public virtual void Update() { }

        public virtual bool Pick(Point2i Location)
        {
            if (DisablePicking) return false;
            return (Location.X >= CorrectedPosition.X && Location.X <= CorrectedPosition.X + Size.Width &&
                Location.Y >= CorrectedPosition.Y && Location.Y <= CorrectedPosition.Y + Size.Height);
        }

        public virtual void Invalidate() { }
        #endregion

        #region Invoke Methods
        private Queue InvokeQueue = null;

        /// <summary>
        /// Adds a method to the invoke queue, which will be called by the thread that owns this object.
        /// </summary>
        /// <param name="Method">Since argument method to call.</param>
        /// <param name="arg">Argument for the method.</param>
        public void Invoke(OnInvoke Method, object arg)
        {
            if (InvokeQueue == null) InvokeQueue = new Queue();
            Queue.Synchronized(InvokeQueue).Enqueue(new Invokable(Method, arg));
        }

        /// <summary>
        /// Calls all the methods that have been invoked by pulling them off the thread-safe queue.
        /// </summary>
        public virtual void DoInvoke()
        {
            if (InvokeQueue == null || InvokeQueue.Count == 0) return;

            for (int i = 0; i < Queue.Synchronized(InvokeQueue).Count; i++)
            {
                Invokable pInvoke = (Invokable)Queue.Synchronized(InvokeQueue).Dequeue();
                pInvoke.Method(pInvoke.Parameter);
            }
        }
        #endregion

        #region Methods
        public static bool Intersects(Point2i Position, Sizei Size, Point2i Location)
        {
            return (Location.X >= Position.X && Location.X <= Position.X + Size.Width &&
                Location.Y >= Position.Y && Location.Y <= Position.Y + Size.Height);
        }
        #endregion

        #region Draw Methods
        private VAO _uiQuad;
        private Corner _relativeTo;
        private UIContainer _parent;
        private Point2i _position;

        public Texture BackgroundTexture { get; set; }

        public Color4 BackgroundColor { get; set; }

        public void DrawQuadTextured()
        {
            if (BackgroundTexture == null) return;

            if (_uiQuad == null)
                _uiQuad = Geometry.CreateQuad(Shaders.SolidUIShader, Vector2f.Zero, new Vector2f(Size.Width, Size.Height), Vector2f.Zero, Vector2f.One);

            GL.Enable(EnableCap.Blend);
            GL.ActiveTexture(0);
            GL.BindTexture(BackgroundTexture);

            Shaders.TexturedUIShader.Bind();
            Shaders.TexturedUIShader.SetUniform("position", new Vector3f(CorrectedPosition.X, CorrectedPosition.Y, 0));
            _uiQuad.DrawProgram(Shaders.TexturedUIShader);

            GL.Disable(EnableCap.Blend);
        }

        public void DrawQuadColored()
        {
            if (BackgroundColor == Color4.Transparent) return;

            DrawQuadColored(BackgroundColor);
        }

        public void DrawQuadColored(Color4 color)
        {
            if (_uiQuad == null) _uiQuad = Geometry.CreateQuad(Shaders.SolidUIShader, Vector2f.Zero, new Vector2f(Size.Width, Size.Height), Vector2f.Zero, Vector2f.One);

            GL.Enable(EnableCap.Blend);

            Shaders.SolidUIShader.Bind();
            Shaders.SolidUIShader.SetUniform("position", new Vector3f(CorrectedPosition.X, CorrectedPosition.Y, 0));
            Shaders.SolidUIShader.SetUniform("color", color);
            _uiQuad.Draw();

            GL.Disable(EnableCap.Blend);
        }
        #endregion
    }
}
