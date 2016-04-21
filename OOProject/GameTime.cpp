#include "stdafx.h"

#include "GameTime.h"

GameTime::GameTime(sf::Time& elapsed_time)
{
	total_microseconds = elapsed_time.asMicroseconds();
	total_miliseconds = elapsed_time.asMilliseconds();
	total_seconds = elapsed_time.asSeconds();
	total_minutes = total_seconds / 60;

	minutes = total_minutes;
	seconds = total_seconds % 60;
	miliseconds = total_miliseconds % 1000;
	microseconds = total_microseconds % 1000;

	delta_time = total_microseconds / 1000.0 / 1000.0;
	time_ = elapsed_time;
}
