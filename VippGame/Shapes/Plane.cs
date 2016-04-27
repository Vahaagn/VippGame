using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using VippGame.GLObjects;
using Time = SFML.System.Time;

namespace VippGame.Shapes
{
    public class Plane
    {
        private readonly GlVertex[] _vertices;
        private readonly uint[] _indices;

        public Color4 Color { get; set; }

        public Plane(Color4? color = null)
        {
            _vertices = new GlVertex[4];
            _indices = new uint[] { 0, 1, 2, 3 };

            Color = color ?? Color4.Magenta;

            Init();
        }

        public void Draw()
        {
            GL.Color4(Color);

            GL.Enable(EnableCap.VertexArray);
            GL.Begin(PrimitiveType.Points);

            for (uint i = 0; i < _indices.Length; i++)
            {
                GL.TexCoord2(_vertices[_indices[i]].TexCoord);
                GL.Normal3(_vertices[_indices[i]].Normal);
                GL.Vertex3(_vertices[_indices[i]].Position);
            }

            GL.DrawElements(PrimitiveType.TriangleStrip, _indices.Length, DrawElementsType.UnsignedInt, _indices);

            GL.End();
            GL.Disable(EnableCap.VertexArray);
        }

        public void Update(Time gameTime)
        {

        }

        private void Init()
        {
            _vertices[0].Position = new Vector3(-50f, -50f, -50f); // create a new Vector and copy it to Position.
            _vertices[0].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[0].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[0].TexCoord.Y = 1f;
            _vertices[0].Color = Color4.Aqua;

            _vertices[1].Position = new Vector3(-50f, 50f, -50f); // create a new Vector and copy it to Position.
            _vertices[1].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[1].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[1].TexCoord.Y = 1f;
            _vertices[0].Color = Color4.Red;

            _vertices[2].Position = new Vector3(-50f, -50f, 50f); // create a new Vector and copy it to Position.
            _vertices[2].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[2].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[2].TexCoord.Y = 1f;
            _vertices[0].Color = Color4.Green;

            _vertices[3].Position = new Vector3(-50f, 50f, 50f); // create a new Vector and copy it to Position.
            _vertices[3].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[3].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[3].TexCoord.Y = 1f;
            _vertices[0].Color = Color4.Blue;

            _vertices[4].Position = new Vector3(50f, -50f, 50f); // create a new Vector and copy it to Position.
            _vertices[4].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[4].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[4].TexCoord.Y = 1f;
            _vertices[0].Color = Color4.Yellow;

            _vertices[5].Position = new Vector3(50f, 50f, 50f); // create a new Vector and copy it to Position.
            _vertices[5].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[5].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[5].TexCoord.Y = 1f;
            _vertices[0].Color = Color4.White;

            _vertices[6].Position = new Vector3(50f, -50f, -50f); // create a new Vector and copy it to Position.
            _vertices[6].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[6].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[6].TexCoord.Y = 1f;
            _vertices[0].Color = Color4.Cyan;

            _vertices[7].Position = new Vector3(50f, 50f, -50f); // create a new Vector and copy it to Position.
            _vertices[7].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[7].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[7].TexCoord.Y = 1f;
            _vertices[0].Color = Color4.Magenta;
        }
    }
}