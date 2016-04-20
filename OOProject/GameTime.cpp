#include "stdafx.h"

#include "GameTime.h"

GameTime::GameTime(sf::Clock& sfml_clock, long delta_i)
{
	auto time = sfml_clock.getElapsedTime();

	total_microseconds = time.asMicroseconds();
	total_miliseconds = time.asMilliseconds();
	total_seconds = time.asSeconds();
	total_minutes = total_seconds / 60;

	minutes = total_minutes;
	seconds = total_seconds % 60;
	miliseconds = total_miliseconds % 1000;
	microseconds = total_microseconds % 1000;

	delta_time = delta_i / 1000.0 / 1000.0;
}
