using System;
using AlienEngine.Core.Resources;
using AlienEngine.Imaging;

namespace AlienEngine.Core.Rendering.Fonts
{
    public class Character : IDisposable
    {
        public Texture Texture;

        public Sizef Size;

        public Vector2f Bearing;

        public uint Advance;

        public Character()
        {
            ResourcesManager.AddDisposableResource(this);
        }
        
        public void Dispose()
        {
            Texture?.Dispose();
        }
    }
}