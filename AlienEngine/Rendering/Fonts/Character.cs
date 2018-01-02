using System;
using AlienEngine.Core.Resources;
using AlienEngine.Imaging;

namespace AlienEngine.Core.Rendering.Fonts
{
    /// <summary>
    /// Describe a character glyph.
    /// </summary>
    public class Character : IDisposable
    {
        /// <summary>
        /// The <see cref="Imaging.Texture"/> used by the glyph.
        /// </summary>
        public Texture Texture;

        /// <summary>
        /// The size of the glyph.
        /// </summary>
        public Sizef Size;

        /// <summary>
        /// The character's bearing.
        /// </summary>
        public Vector2f Bearing;

        /// <summary>
        /// The number of unit to advance before render the next character.
        /// </summary>
        public uint Advance;

        /// <summary>
        /// Create a new character descriptor.
        /// </summary>
        public Character()
        {
            ResourcesManager.AddDisposableResource(this);
        }
        
        /// <summary>
        /// Dispose ressources.
        /// </summary>
        public void Dispose()
        {
            Texture?.Dispose();
        }
    }
}