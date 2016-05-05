using OpenTK.Graphics.OpenGL;
using System.Text;

namespace VippGame.Core
{
    public sealed class Shader
    {
        public int Handle { get; private set; }

        public Shader(ShaderType type, string code)
        {
            Handle = GL.CreateShader(type);

            GL.ShaderSource(Handle, code);
            GL.CompileShader(Handle);
        }

        public Shader(ShaderType type, byte[] file)
        {
            var code = Encoding.UTF8.GetString(file);

            Handle = GL.CreateShader(type);

            GL.ShaderSource(Handle, code);
            GL.CompileShader(Handle);
        }
    }
}