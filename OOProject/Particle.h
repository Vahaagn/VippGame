#pragma once

#include <SFML/System/Vector2.hpp>
#include <SFML/System/Time.hpp>

struct Particle
{
	sf::Vector2f velocity;
	sf::Time lifetime;
};
