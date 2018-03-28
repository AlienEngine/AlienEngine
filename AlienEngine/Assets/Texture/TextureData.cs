using AlienEngine.Core.Imaging.DevIL;
using DevilImage = AlienEngine.Core.Imaging.DevIL.Image;
using AlienEngine.Core.Imaging.DevIL.Unmanaged;
using AlienEngine.Imaging;
using ZeroFormatter;

namespace AlienEngine.Core.Assets.Texture
{
    [ZeroFormattable]
    public class TextureData
    {
        [Index(0)]
        public virtual byte[] Data { get; set; }

        [Index(1)]
        public virtual byte[] CompressedData { get; set; }

        [Index(2)]
        public virtual byte[] PaletteData { get; set; }

        [Index(3)]
        public virtual PaletteType PaletteType { get; set; }

        [Index(4)]
        public virtual DataFormat PaletteBaseType { get; set; }

        [Index(5)]
        public virtual CubeMapFace CubeFace { get; set; }

        [Index(6)]
        public virtual OriginLocation Origin { get; set; }

        [Index(7)]
        public virtual DataFormat Format { get; set; }

        [Index(8)]
        public virtual CompressedDataFormat DxtcFormat { get; set; }

        [Index(9)]
        public virtual DataType DataType { get; set; }

        [Index(10)]
        public virtual bool HasDxtcData { get; set; }

        [Index(11)]
        public virtual int BytesPerPixel { get; set; }

        [Index(12)]
        public virtual int ChannelCount { get; set; }

        [Index(13)]
        public virtual int Duration { get; set; }

        [Index(14)]
        public virtual int SizeOfData { get; set; }

        [Index(15)]
        public virtual int OffsetX { get; set; }

        [Index(16)]
        public virtual int OffsetY { get; set; }

        [Index(17)]
        public virtual int PlaneSize { get; set; }

        [Index(18)]
        public virtual int PaletteBytesPerPixel { get; set; }

        [Index(19)]
        public virtual int PaletteColumnCount { get; set; }

        [Index(20)]
        public virtual int Width { get; set; }

        [Index(21)]
        public virtual int Height { get; set; }

        [Index(22)]
        public virtual int Depth { get; set; }

        [Index(23)]
        public virtual int BitsPerPixel { get; set; }

        [Index(24)]
        public virtual bool HasPaletteData { get; set; }

        [Index(25)]
        public virtual bool IsCubeMap { get; set; }

        [Index(26)]
        public virtual bool IsSphereMap { get; set; }

        public TextureData()
        {
        }

        internal static TextureData FromDevilImageData(ImageData imgData)
        {
            return new TextureData
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
        }
        
        internal DevilImage ToDevilImage()
        {
            var id = IL.GenerateImage();
            
            IL.BindImage(id);
            IL.SetDxtcFormat(DxtcFormat);
            IL.SetOriginLocation(Origin);
            IL.SetDuration(Duration);
            IL.SetPixels(OffsetX, OffsetY, 0, Width, Height, Depth, Format, DataType, Data);
                
            return new DevilImage(id);
        }

    }
}