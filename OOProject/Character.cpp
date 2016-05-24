#include "stdafx.h"
#include "Character.h"

Character::Character() : _initialized(false)
{
	
}

Character::~Character()
{
}

void Character::initialize()
{
	_shape = sf::RectangleShape(sf::Vector2f(50, 50));
	_shape.setPosition(50, 50);
	_shape.setFillColor(sf::Color::Cyan);

	_initialized = true;
}

void Character::draw(sf::RenderTarget& target, sf::RenderStates states) const
{
	if (!_initialized) return;

	states.transform *= getTransform();
	//states.texture = ;
	//states.shader = ;
	//states.blendMode = ;

	target.draw(_shape, states);
}
