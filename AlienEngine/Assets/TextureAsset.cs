using AlienEngine.Core.Assets.Texture;
using System;
using System.IO;
using System.Text;
using AlienEngine.Core.Imaging.DevIL;
using AlienEngine.Core.Resources;
using ZeroFormatter;
using Image = AlienEngine.Imaging.Image;

namespace AlienEngine.Core.Assets
{
    [ZeroFormattable]
    public class TextureAsset : IAsset
    {
        private const string Ext = "aetexture";

        [Index(0)]
        public virtual string Source { get; protected set; }

        [Index(1)]
        public virtual TextureData Data { get; protected set; }

        [IgnoreFormat]
        public AssetTypes Type => AssetTypes.Texture;

        [IgnoreFormat]
        public string Extension => Ext;

        public TextureAsset()
        {
        }

        /// <summary>
        /// Checks if a file is a serialized <see cref="TextureAsset"/>.
        /// </summary>
        /// <param name="textureFile">The file to check.</param>
        /// <param name="asset">The result of the deserialization.</param>
        public static bool IsAsset(string textureFile, out IAsset asset)
        {
            asset = ZeroFormatterSerializer.Deserialize<IAsset>(File.ReadAllBytes(textureFile));
            return asset.Type == AssetTypes.Texture;
        }

        /// <summary>
        /// Create a <see cref="TextureAsset"/> instance from a file.
        /// </summary>
        /// <param name="textureFile">
        /// The texture file. Can be an AlienEngine Texture Asset file (.aetexture)
        /// or all other image file (.png, .dxt, .tga, etc...)
        /// </param>
        public static TextureAsset From(string textureFile)
        {
            if (textureFile.EndsWith($".{Ext}") && IsAsset(textureFile, out IAsset file))
                return file as TextureAsset;

            try
            {
                TextureAsset asset = new TextureAsset();
                asset.Source = textureFile;

                Image img = new Image(textureFile);

                ImageData imgData = img.DevilImage.GetImageData(0);

                asset.Data = TextureData.FromDevilImageData(imgData);

                return asset;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error parsing {textureFile}: {e.Message}");
                throw;
            }
        }

        public void Serialize(string filePath, bool force)
        {
            if (!filePath.EndsWith($".{Extension}"))
                filePath = filePath + $".{Extension}";

            var data = ZeroFormatterSerializer.Serialize<IAsset>(this);

            if (!File.Exists(filePath) || force)
            {
                File.WriteAllBytes(filePath, data);
            }
            else
            {
                throw new Exception($"The file at \"{filePath}\" already exists");
            }
        }

        public IResource ToResource()
        {
            return new AlienEngine.Imaging.Texture(new Image(Data.ToDevilImage()));
        }
    }
}