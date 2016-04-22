#include "stdafx.h"

#include "FpsCounter.h"
#include <sstream>

FpsCounter::FpsCounter(sf::Font& font)
{
	frames = 0;
	this->fps_font = &font;

	init();
}

void FpsCounter::update()
{
	if (fps_clock.getElapsedTime().asMilliseconds() > 1000)
	{
		std::stringstream fps;
		fps << "FPS: " << frames;
		fps_text->setString(fps.str());

		frames = 0;
		fps_clock.restart();
	}
	else
	{
		++frames;
	}
}

void FpsCounter::display(sf::RenderWindow& window)
{
	window.draw(*fps_text);
}

void FpsCounter::init()
{
	fps_text = new sf::Text("FPS: 0", *fps_font);
	fps_text->setCharacterSize(14);
	fps_text->setColor(sf::Color::Magenta);
	fps_text->setStyle(sf::Text::Bold);
}
