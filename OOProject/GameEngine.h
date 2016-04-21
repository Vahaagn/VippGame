#pragma once

#include "GameTime.h"
#include <SFML/Graphics.hpp>

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

	bool fps_show_b_;

public:
	GameEngine();
	~GameEngine();

	void init();
	void start();

	void update(GameTime& game_time);
	void draw();

	void show_fps_counter();
	void hide_fps_counter();
};
