#pragma once

#include <SFML/Graphics.hpp>
#include <functional>

class TextObject : public sf::Drawable, public sf::Transformable
{
private:
	sf::Window& window_;
	sf::Font& font_;
	sf::Text object_text_;
	std::string& text_;
	int x;
	int y;

public:
	TextObject(int x, int y, sf::Font& font, std::string text, sf::Window& window);
	~TextObject();

	void update();

	void setText(std::string text);
	void setColor(sf::Color color);
	void setStyle(sf::Text::Style style);
	void onMouseHover();
	void onMouseLeave();

	// events
	std::function<void(sf::Mouse&, TextObject&)> onHoverAction;
	std::function<void(sf::Mouse&, TextObject&)> onLeaveAction;

private:
	virtual void draw(sf::RenderTarget& target, sf::RenderStates states) const;
};
