using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using VippGame.Core;
using VippGame.GLObjects;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace VippGame.Shapes
{
    public class Plane
    {
        private readonly GlVertex[] _vertices;
        private readonly uint[] _indices;

        public Vector3 Position { get; set; }
        public float Size { get; set; }
        public float Angle { get; set; }
        public Vector3 Rotation { get; set; }
        public Color4 Color { get; set; }

        private ShaderProgram _shaderProgram;

        public int Texture;
        public string TextureName;

        public Plane(Color4? color = null, string texture = "test1.jpg", float size = 50f)
        {
            _vertices = new GlVertex[4];
            _indices = new uint[] { 0, 1, 2, 3 };

            Color = color ?? Color4.Magenta;
            Size = size;

            CreateShaders();
            var bitmap = new Bitmap(texture);
            CreateTexture(out Texture, bitmap);
            BindTexture(ref Texture, TextureUnit.Texture0, "MyTexture0");

            Init();
        }

        public void Draw()
        {
            GL.PushMatrix();

            GL.Rotate(Angle, Rotation);
            GL.Color4(Color);
            GL.BindTexture(TextureTarget.Texture2D, Texture);

            GL.Enable(EnableCap.VertexArray);
            GL.Begin(PrimitiveType.Quads);

            for (uint i = 0; i < _indices.Length; i++)
            {
                GL.TexCoord2(_vertices[_indices[i]].TexCoord);
                //GL.Normal3(_vertices[_indices[i]].Normal);
                GL.Vertex3(_vertices[_indices[i]].Position);
                //GL.Color4(_vertices[_indices[i]].Color);
            }
            //GL.DrawElements(PrimitiveType.TriangleStrip, _indices.Length, DrawElementsType.UnsignedInt, _indices);

            GL.End();
            GL.Disable(EnableCap.VertexArray);

            GL.PopMatrix();
        }

        public void Update(GameTime gameTime)
        {

        }

        private void Init()
        {
            _vertices[0].Position = new Vector3(-1 * Size, -1 * Size, -1 * Size); // create a new Vector and copy it to Position.
            _vertices[0].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[0].TexCoord.X = 0; // the Vectors are structs, so the new keyword is not required.
            _vertices[0].TexCoord.Y = 1;
            _vertices[0].Color = Color;

            _vertices[1].Position = new Vector3(-1 * Size, 1 * Size, -1 * Size); // create a new Vector and copy it to Position.
            _vertices[1].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[1].TexCoord.X = 1; // the Vectors are structs, so the new keyword is not required.
            _vertices[1].TexCoord.Y = 1;
            _vertices[1].Color = Color;

            _vertices[2].Position = new Vector3(1 * Size, 1 * Size, -1 * Size); // create a new Vector and copy it to Position.
            _vertices[2].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[2].TexCoord.X = 1; // the Vectors are structs, so the new keyword is not required.
            _vertices[2].TexCoord.Y = 0;
            _vertices[2].Color = Color;

            _vertices[3].Position = new Vector3(1 * Size, -1 * Size, -1 * Size); // create a new Vector and copy it to Position.
            _vertices[3].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[3].TexCoord.X = 0; // the Vectors are structs, so the new keyword is not required.
            _vertices[3].TexCoord.Y = 0;
            _vertices[3].Color = Color;
        }

        private void CreateTexture(out int texture, Bitmap bitmap)
        {
            // load texture 
            GL.GenTextures(1, out texture);

            //Still required else TexImage2D will be applyed on the last bound texture
            GL.BindTexture(TextureTarget.Texture2D, texture);

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);

            bitmap.UnlockBits(data);
        }

        private void BindTexture(ref int textureId, TextureUnit textureUnit, string uniformName)
        {
            GL.ActiveTexture(textureUnit);
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.Uniform1(GL.GetUniformLocation(_shaderProgram.Handle, uniformName), textureUnit - TextureUnit.Texture0);
        }

        void CreateShaders()
        {
            _shaderProgram = new ShaderProgram(ShaderType.FragmentShader, fragmentShaderSource);
            _shaderProgram.Use();
        }

        #region [ Shaders ]
        string fragmentShaderSource = @"
#version 150
uniform sampler2D MyTexture0;
 
void main(void)
{
  gl_FragColor = texture2D( MyTexture0, gl_TexCoord[0].st );  
  gl_FragColor[1] = gl_FragColor[1] * 0.90;
}";
        #endregion
    }
}