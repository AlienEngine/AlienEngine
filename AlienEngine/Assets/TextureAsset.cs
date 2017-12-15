using AlienEngine.Core.Assets.Texture;
using System;
using System.IO;
using System.Text;
using AlienEngine.Core.Graphics.DevIL;
using ZeroFormatter;
using Image = AlienEngine.Imaging.Image;

namespace AlienEngine.Core.Assets
{
    [ZeroFormattable]
    public class TextureAsset : IAsset
    {
        [Index(0)]
        public virtual string Source { get; protected set; }

        [Index(1)]
        public virtual TextureData Data { get; protected set; }

        [IgnoreFormat]
        public AssetTypes Type => AssetTypes.Texture;

        [IgnoreFormat]
        public string Extension => "aetexture";

        public TextureAsset()
        { }

        /// <summary>
        /// Checks if a file is a serialized <see cref="TextureAsset"/>.
        /// </summary>
        /// <param name="textureFile">The file to check.</param>
        public static bool IsAsset(string textureFile)
        {
            // TODO: Use Zeroformatter to retrieve and compare the union type
            return false;
        }

        private static TextureAsset _fromAsset(string asset)
        {
            // TODO: Compute data from asset
            return new TextureAsset();
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
            if (IsAsset(textureFile))
            {
                // Extract data from mesh file
                return _fromAsset(textureFile);
            }


            try
            {
                TextureAsset asset = new TextureAsset();

                Image img = new Image(textureFile);

                ImageData imgData = img.DevilImage.GetImageData(0);

                asset.Data = new TextureData
                {
                    BitsPerPixel = imgData.BitsPerPixel,
                    BytesPerPixel = imgData.BytesPerPixel,
                    ChannelCount = imgData.ChannelCount,
                    CompressedData = imgData.CompressedData,
                    CubeFace = imgData.CubeFace,
                    Data = imgData.Data,
                    DataType = imgData.DataType,
                    Depth = imgData.Depth,
                    Duration = imgData.Duration,
                    DxtcFormat = imgData.DxtcFormat,
                    Format = imgData.Format,
                    HasDxtcData = imgData.HasDXTCData,
                    HasPaletteData = imgData.HasPaletteData,
                    Height = imgData.Height,
                    IsCubeMap = imgData.IsCubeMap,
                    IsSphereMap = imgData.IsSphereMap,
                    OffsetX = imgData.OffsetX,
                    OffsetY = imgData.OffsetY,
                    Origin = imgData.Origin,
                    PaletteBaseType = imgData.PaletteBaseType,
                    PaletteBytesPerPixel = imgData.PaletteBytesPerPixel,
                    PaletteColumnCount = imgData.PaletteColumnCount,
                    PaletteData = imgData.PaletteData,
                    PaletteType = imgData.PaletteType,
                    PlaneSize = imgData.PlaneSize,
                    SizeOfData = imgData.SizeOfData,
                    Width = imgData.Width
                };

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

            var data = ZeroFormatterSerializer.Serialize(this);

            var test = ZeroFormatterSerializer.Deserialize<TextureAsset>(data);

            if (!File.Exists(filePath) || force)
            {
                File.WriteAllBytes(filePath, data);
            }
            else
            {
                throw new Exception($"The file at \"{filePath}\" already exists");
            }
        }
    }
}
