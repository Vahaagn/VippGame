using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace VippGame.Core
{
    public class TextGL
    {
        private Bitmap _bitmap;
        private int _texture;

        public string Text { get; set; }
        public Font Font { get; set; }

        public TextGL()
        {
            _bitmap = new Bitmap(100, 50);
            _texture = GL.GenTexture();

            Text = "Test";
            Font = new Font("consola", 12);

            Init();
        }

        private void Init()
        {
            GL.BindTexture(TextureTarget.Texture2D, _texture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _bitmap.Width, _bitmap.Height, 0, PixelFormat.Bgra,
                PixelType.UnsignedByte, IntPtr.Zero);
        }

        public void Draw()
        {
            using (Graphics gfx = Graphics.FromImage(_bitmap))
            {
                gfx.Clear(Color.Transparent);
                gfx.DrawString(Text, Font, Brushes.Magenta, 0, 0);
            }

            BitmapData data = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _bitmap.Width, _bitmap.Height, 0, PixelFormat.Bgra,
                PixelType.UnsignedByte, data.Scan0);
            _bitmap.UnlockBits(data);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(0, _bitmap.Width, _bitmap.Height, 0, -1, 1);

            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);
            GL.BindTexture(TextureTarget.Texture2D, _texture);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 1f); GL.Vertex2(0f, 0f);
            GL.TexCoord2(1f, 1f); GL.Vertex2(1f, 0f);
            GL.TexCoord2(1f, 0f); GL.Vertex2(1f, 1f);
            GL.TexCoord2(0f, 0f); GL.Vertex2(0f, 1f);
            GL.End();

            // Swap buffers
        }

        public void Update()
        {

        }
    }
}