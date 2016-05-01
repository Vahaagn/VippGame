using OpenTK.Graphics.OpenGL;

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
    }
}