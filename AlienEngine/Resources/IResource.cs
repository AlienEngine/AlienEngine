using System;
using AlienEngine.Core.Assets;

namespace AlienEngine.Core.Resources
{
    /// <summary>
    /// Represents a game resource.
    /// </summary>
    public interface IResource: IDisposable
    {
        /// <summary>
        /// Loads the resource from a path.
        /// </summary>
        /// <param name="path">The path to the resource.</param>
        /// <returns><value>true</value> if the resource was successfuly loaded, <value>false</value> otherwise.</returns>
        bool Load(string path);
    }
}