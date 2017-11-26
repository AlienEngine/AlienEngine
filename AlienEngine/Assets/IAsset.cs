using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroFormatter;

namespace AlienEngine.Core.Assets
{
    /// <summary>
    /// Provide access to shared assets methods.
    /// </summary>
    [CLSCompliant(false)]
    [Union(typeof(MeshAsset))]
    public interface IAsset
    {
        /// <summary>
        /// The type of data handled by this asset.
        /// </summary>
        [UnionKey]
        AssetTypes Type { get; }

        /// <summary>
        /// The source file of this asset.
        /// </summary>
        string Source { get; }

        /// <summary>
        /// The file extension handled by this asset.
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// Serialize an asset data in a file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="force">Define if we have to force the serialization.</param>
        void Serialize(string filePath, bool force);
    }
}
