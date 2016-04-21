#pragma once

#include <SFML/Graphics.hpp>

class FpsCounter
{
	sf::Text* fps_text;
	sf::Font* fps_font;
	sf::Clock fps_clock;
	int frames = 0;

public:
	FpsCounter(sf::Font& font);

	void update();
	void display(sf::RenderWindow& window);

private:
	void init();
};
