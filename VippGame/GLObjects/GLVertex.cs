using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;

namespace VippGame.GLObjects
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GlVertex
    {
        public Vector2 TexCoord;
        public Vector3 Normal;
        public Vector3 Position;
        public Color4 Color;
    }
}