using System.Collections.Generic;
using System.Drawing;

namespace Chess
{
    public class ChessPieceImage
    {
        private int Type { get; set; }
        private int Color { get; set; }

        private static Bitmap chessPiecesImage = new Bitmap(@"C:\Users\Andreea Purta\source\repos\Sah\Sah\Resources\ChessPiecesArray.png");
        private static Dictionary<PieceEnum, Dictionary<ColorEnum, Bitmap>> instances;

        public ChessPieceImage()
        {
        }

        private static Bitmap CropImage(PieceEnum type, ColorEnum color)
        {
            Rectangle srcRect = new Rectangle((int)type * 60, (int)color * 60, 60, 60);
            return chessPiecesImage.Clone(srcRect, chessPiecesImage.PixelFormat);
        }

        public static Bitmap GetInstance(PieceEnum type, ColorEnum color)
        {
            if (instances == null)
            {
                instances = new Dictionary<PieceEnum, Dictionary<ColorEnum, Bitmap>>();
            }

            if (!instances.ContainsKey(type))
            {
                instances.Add(type, new Dictionary<ColorEnum, Bitmap>());
            }

            if (!instances[type].ContainsKey(color))
            {
                instances[type].Add(color, CropImage(type, color));
            }

            return instances[type][color];
        }
    }
}