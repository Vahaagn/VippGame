#pragma once

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
	sf::Time time_;

	//
	GameTime(sf::Time& elapsed_time);
};
