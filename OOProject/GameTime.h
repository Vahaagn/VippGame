#pragma once

#include <SFML/System.hpp>

class GameTime
{
public:
	long microseconds;
	long miliseconds;
	long seconds;
	long minutes;

	long total_microseconds;
	long total_miliseconds;
	long total_seconds;
	long total_minutes;

	double delta_time;

	/// [WiP] Do not use yet
	time_t time;

	//
	GameTime(sf::Time& elapsed_time);
};
