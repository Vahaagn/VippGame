#pragma once

class FpsCounter
{
	sf::Text* fps_text;
	sf::Font* fps_font;
	sf::Clock fps_clock;
	int frames;

public:
	FpsCounter(sf::Font& font);

	/// <summary>
	/// Counting frames every GameEngine update() method
	/// </summary>
	void update();
	void display(sf::RenderWindow& window);

private:
	void init();
};
