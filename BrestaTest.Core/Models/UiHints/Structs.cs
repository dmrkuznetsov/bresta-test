using BrestaTest.Core.Models.Enums;
using System.Drawing;

namespace BrestaTest.Core.Models.UiHints
{
    public struct ColorWithPosition
    {
        public Color Color1;
        public Color Color2;
        public UiPosition Position;
    }
    public struct LineCoord
    {
        public Point P1;
        public Point P2;
    }
    public struct LineInfo
    {
        public LineCoord Coords;
        public Color Color;
        public float Thickness;
    }
    public struct Indentation
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
