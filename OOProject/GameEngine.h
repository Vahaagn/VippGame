#pragma once

#include "GameTime.h"
#include "FpsCounter.h"
#include "ParticleSystem.h"
#include "TextObject.h"

class GameEngine
{
private:
	sf::RenderWindow* render_window_;
	FpsCounter* fps_counter_;
	sf::Clock update_clock_;
	sf::Font font;

	ParticleSystem* particles;
	TextObject* text_1_;
	sf::Color text_color;
	sf::Shader test_shader;

	bool fps_show_b_;

public:
	GameEngine();
	~GameEngine();

	/// <summary>
	/// Initialize the GameEngine. Use it only once!
	/// </summary>
	void init();
	/// <summary>
	/// Starting the GameEngine and begin counting. Use it only once!
	/// </summary>
	void start();

	/// <summary>
	/// Update loop is being used automatically.
	/// Do not use it if not needed!
	/// <param name="game_time">object with time and delta time</param>
	/// </summary>
	void update(GameTime& game_time);
	/// <summary>
	/// Draw objects there.
	/// </summary>
	void draw();

	/// <summary>
	/// Enable FPS counter.
	/// </summary>
	void show_fps_counter();
	/// <summary>
	/// Disable FPS counter.
	/// </summary>
	void hide_fps_counter();
};
