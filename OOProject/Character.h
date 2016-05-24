#pragma once

#include "stdafx.h"

class Character : public sf::Drawable, public sf::Transformable
{
private:
	sf::RectangleShape _shape;
	bool _initialized;

public:
	Character();
	virtual ~Character();
	
	void initialize();

protected:
	void draw(sf::RenderTarget& target, sf::RenderStates states) const override;
};
