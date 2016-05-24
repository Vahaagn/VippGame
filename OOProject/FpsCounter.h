#pragma once

#include "stdafx.h"

class FpsCounter : public sf::Drawable, public sf::Transformable
{
private:
	sf::Text _text;
	sf::Font _font;
	sf::Time _elapsed;
	int _frames;
	bool _initialized;

public:
	FpsCounter();
	virtual ~FpsCounter();
	
	void initialize();
	void update(sf::Time elapsed_time);

protected:
	void draw(sf::RenderTarget& target, sf::RenderStates states) const override;
};
