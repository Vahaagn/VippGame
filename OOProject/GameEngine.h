#pragma once

#include "GameTime.h"
#include <SFML/Graphics.hpp>

#include "FpsCounter.h"

class GameEngine
{
private:
	sf::RenderWindow* render_window_;
	FpsCounter* fps_counter_;
	sf::Clock update_clock_;
	sf::Font font;

public:
	GameEngine();
	~GameEngine();

	void init();
	void start();

	void update(GameTime& game_time);
	void draw();
};
