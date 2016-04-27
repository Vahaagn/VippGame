using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using VippGame.GLObjects;
using Time = SFML.System.Time;

namespace VippGame.Shapes
{
    public class Cube
    {
        private readonly GlVertex[] _vertices;
        private readonly uint[] _indices;

        public Cube()
        {
            _vertices = new GlVertex[8];
            _indices = new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 7, 5, 1, 3, 2, 0, 6, 2, 4 };

            Init();
        }

        public void Draw()
        {
            GL.Enable(EnableCap.VertexArray);
            GL.Begin(PrimitiveType.Points);

            for (uint i = 0; i < _indices.Length; i++)
            {
                GL.TexCoord2(_vertices[_indices[i]].TexCoord);
                GL.Normal3(_vertices[_indices[i]].Normal);
                GL.Vertex3(_vertices[_indices[i]].Position);
                GL.Color4(_vertices[_indices[i]].Color);
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
            _vertices[1].Color = Color4.Red;

            _vertices[2].Position = new Vector3(-50f, -50f, 50f); // create a new Vector and copy it to Position.
            _vertices[2].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[2].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[2].TexCoord.Y = 1f;
            _vertices[2].Color = Color4.Green;

            _vertices[3].Position = new Vector3(-50f, 50f, 50f); // create a new Vector and copy it to Position.
            _vertices[3].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[3].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[3].TexCoord.Y = 1f;
            _vertices[3].Color = Color4.Blue;

            _vertices[4].Position = new Vector3(50f, -50f, 50f); // create a new Vector and copy it to Position.
            _vertices[4].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[4].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[4].TexCoord.Y = 1f;
            _vertices[4].Color = Color4.Yellow;

            _vertices[5].Position = new Vector3(50f, 50f, 50f); // create a new Vector and copy it to Position.
            _vertices[5].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[5].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[5].TexCoord.Y = 1f;
            _vertices[5].Color = Color4.White;

            _vertices[6].Position = new Vector3(50f, -50f, -50f); // create a new Vector and copy it to Position.
            _vertices[6].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[6].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[6].TexCoord.Y = 1f;
            _vertices[6].Color = Color4.Cyan;

            _vertices[7].Position = new Vector3(50f, 50f, -50f); // create a new Vector and copy it to Position.
            _vertices[7].Normal = Vector3.UnitX; // this will copy Vector3.UnitX into the Normal Vector.
            _vertices[7].TexCoord.X = 0.5f; // the Vectors are structs, so the new keyword is not required.
            _vertices[7].TexCoord.Y = 1f;
            _vertices[7].Color = Color4.Magenta;
        }
    }
}