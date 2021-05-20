using System.Collections.Generic;
using System.Drawing;

namespace Chess
{
    public sealed class ChessPieceImage
    {
        private int Type { get; set; }
        private int Color { get; set; }

        private static Bitmap chessPiecesImage = new Bitmap(Properties.Resources.pieces);
        private static Dictionary<PieceEnum, Dictionary<ColorEnum, Bitmap>> instances;

        private ChessPieceImage()
        {
        }

        private static Bitmap CropImage(PieceEnum type, ColorEnum color)
        {
            int x = 0, y = 0;
            switch (type)
            {
                case PieceEnum.LeftQueen:
                    {
                        x = 0;
                        break;
                    }
                case PieceEnum.RightQueen:
                    {
                        x = 0;
                        break;
                    }
                case PieceEnum.LeftKing:
                    {
                        x = 60;
                        break;
                    }
                case PieceEnum.RightKing:
                    {
                        x = 60;
                        break;
                    }
                case PieceEnum.Rook:
                    {
                        x = 120;
                        break;
                    }
                case PieceEnum.Knight:
                    {
                        x = 180;
                        break;
                    }
                case PieceEnum.Bishop:
                    {
                        x = 240;
                        break;
                    }
                case PieceEnum.Pawn:
                    {
                        x = 300;
                        break;
                    }
            }
            switch (color)
            {
                case ColorEnum.White:
                    {
                        y = 60;
                        break;
                    }

                case ColorEnum.Black:
                    {
                        y = 0;
                        break;
                    }
            }
            Bitmap bitmap = new Bitmap(60, 60);
            Graphics g = Graphics.FromImage(bitmap);
            Rectangle srcRect = new Rectangle(x, y, 60, 60);
            Rectangle destRect = new Rectangle(0, 0, 60, 60);

            g.DrawImage(chessPiecesImage, destRect, srcRect, GraphicsUnit.Pixel);
            return bitmap;
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