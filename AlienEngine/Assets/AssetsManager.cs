using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Assets
{
    /// <summary>
    /// Load and manage game assets.
    /// </summary>
    public class AssetsManager
    {
        /// <summary>
        /// Initialize the Assets Manager.
        /// </summary>
        internal static void Initialize()
        {
            ZeroFormatter.Formatters.Formatter.AppendDynamicUnionResolver((unionType, resolver) =>
            {
                //can be easily extended to reflection based scan if library consumer wants it
                if (unionType == typeof(IAsset))
                {
                    resolver.RegisterUnionKeyType(typeof(AssetTypes));
                    resolver.RegisterSubType(key: AssetTypes.Mesh, subType: typeof(MeshAsset));
                }
            });
        }
    }
}
