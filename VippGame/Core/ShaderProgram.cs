using System;
using System.Diagnostics;
using OpenTK.Graphics.OpenGL;

namespace VippGame.Core
{
    public class ShaderProgram
    {
        public int Handle { get; private set; }

        public ShaderProgram(params Shader[] shaders)
        {
            CreateAndLink(shaders);
        }

        public ShaderProgram(ShaderType type, string code)
        {
            var shader = new Shader(type, code);
            CreateAndLink(shader);
        }

        public ShaderProgram(string vertexCode, string fragmentCode)
        {
            var vertex = new Shader(ShaderType.VertexShader, vertexCode);
            var fragment = new Shader(ShaderType.FragmentShader, fragmentCode);
            CreateAndLink(vertex, fragment);
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        private void CreateAndLink(params Shader[] shaders)
        {
            Handle = GL.CreateProgram();

            foreach (var shader in shaders)
            {
                GL.AttachShader(Handle, shader.Handle);
            }

            GL.LinkProgram(Handle);
            
            foreach (var shader in shaders)
            {
                string programInfoLog;
                GL.GetProgramInfoLog(shader.Handle, out programInfoLog);
                Console.WriteLine(programInfoLog);

                GL.DetachShader(Handle, shader.Handle);
            }
        }
    }
}