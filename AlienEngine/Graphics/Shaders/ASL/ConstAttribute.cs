namespace AlienEngine.ASL
{
    public abstract partial class ASLShader
    {
        [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
        public sealed class ConstAttribute : System.Attribute
        { }
    }
}