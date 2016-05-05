#version 150

in vec4 position;
in vec2 texture_coord;
out vec2 texture_coord_vshader;

uniform vec4 Model;
uniform vec4 Position;
uniform vec4 Projection;

void main() {
	gl_Position = Projection * View * Model * position;
	texture_coord_vshader = texture_coord;
}