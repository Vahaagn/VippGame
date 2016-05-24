#include "stdafx.h"
#include "FpsCounter.h"

FpsCounter::FpsCounter() : _frames(0), _initialized(false)
{	
	_text.setString("FPS");
}

FpsCounter::~FpsCounter()
{
}

void FpsCounter::initialize()
{
	auto fonts_manager = FontsManager::getInstance();
	_font = fonts_manager.getFont("consola");

	_text.setFont(_font);
	_text.setCharacterSize(12);
	_text.setColor(sf::Color::Magenta);

	_initialized = true;
}

void FpsCounter::update(sf::Time elapsed_time)
{
	_elapsed += elapsed_time;
	++_frames;

	if (_elapsed.asMilliseconds() >= 1000)
	{
		_elapsed = sf::Time::Zero;
		_text.setString("FPS: " + _frames);
		_frames = 0;
	}
}

void FpsCounter::draw(sf::RenderTarget& target, sf::RenderStates states) const
{
	if (!_initialized) return;

	target.draw(_text, states);
}
