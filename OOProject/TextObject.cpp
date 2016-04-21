#include "stdafx.h"

#include "TextObject.h"

TextObject::TextObject(int x, int y, sf::Font& font, std::string text, sf::Window& window) 
	: font_(font), text_(text), x(x), y(y), window_(window)
{
	object_text_.setFont(font_);
	object_text_.setString(text);
	object_text_.setPosition(x, y);
	object_text_.setColor(sf::Color::White);
	object_text_.setCharacterSize(20);
}

TextObject::~TextObject()
{
}

void TextObject::update()
{
	onMouseHover();
	onMouseLeave();
}

void TextObject::setText(std::string text)
{
	object_text_.setString(text);
}

void TextObject::setColor(sf::Color color)
{
	object_text_.setColor(color);
}

void TextObject::setStyle(sf::Text::Style style)
{
	object_text_.setStyle(style);
}

void TextObject::onMouseHover()
{
	sf::Mouse mouse;
	auto position = mouse.getPosition(window_);
	auto bounds = object_text_.getGlobalBounds();

	if (position.x >= bounds.left &&
		position.x <= bounds.left + bounds.width &&
		position.y >= bounds.top &&
		position.y <= bounds.top + bounds.height)
	{
		onHoverAction(mouse, *this);
	}
}

void TextObject::onMouseLeave()
{
	sf::Mouse mouse;
	auto position = mouse.getPosition(window_);
	auto bounds = object_text_.getGlobalBounds();

	if (position.x < bounds.left ||
		position.x > bounds.left + bounds.width ||
		position.y < bounds.top ||
		position.y > bounds.top + bounds.height)
	{
		onLeaveAction(mouse, *this);
	}
}

void TextObject::draw(sf::RenderTarget& target, sf::RenderStates states) const
{
	states.transform *= getTransform();
	states.texture = nullptr;

	target.draw(object_text_, states);
}
