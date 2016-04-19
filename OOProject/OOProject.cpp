// OOProject.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <sstream>
#include <SFML/Graphics.hpp>

int getRandomNumber()
{
	return rand() % 100 + 1;
}

sf::Color getRandomColor()
{
	sf::Color color;

	int rand = getRandomNumber() % 3;
	switch (rand)
	{
	case 1:
		color = sf::Color::Red;
		break;
	case 2:
		color = sf::Color::Blue;
		break;
	case 3:
		color = sf::Color::Green;
		break;
	case 4:
		color = sf::Color::Yellow;
		break;
	case 5:
		color = sf::Color::Cyan;
		break;
	default:
		color = sf::Color::Black;
		break;
	}

	return color;
}

void CountAndDisplayFPS(sf::Clock& fpsClock, int& frames, sf::Text& text)
{
	if (fpsClock.getElapsedTime().asMilliseconds() > 1000)
	{
		std::stringstream fps;
		fps << "FPS: " << frames;
		text.setString(fps.str());

		frames = 0;
		fpsClock.restart();
	}
	else
	{
		++frames;
	}
}

int main()
{
	sf::RenderWindow window(sf::VideoMode(800, 600), "SFML works!");
	sf::CircleShape shape(100.f);
	shape.setFillColor(sf::Color::Green);
	shape.setPosition((window.getSize().x / 2) - shape.getRadius(), (window.getSize().y / 2) - shape.getRadius());

	sf::Font font;

	if (!font.loadFromFile("consola.ttf"))
	{
		// error...
	}
	sf::Text text;
	text.setFont(font);
	text.setCharacterSize(12);
	text.setColor(sf::Color::Magenta);
	text.setStyle(sf::Text::Bold | sf::Text::Underlined);

	sf::Clock time;
	sf::Clock fpsClock;
	int frames = 0;

	while (window.isOpen())
	{
		sf::Event event;
		while (window.pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
				window.close();
		}

		window.clear(sf::Color::Black);

		window.draw(shape);
		window.draw(text);

		window.display();

		CountAndDisplayFPS(fpsClock, frames, text);
		time.restart();
	}

	return 0;
}

