#pragma once

class MouseManager
{
private:
	sf::CircleShape* m_cursor;
	sf::Window* relative_window;

public:
	MouseManager(sf::Window& relative_window);

	void update();

	sf::Vector2i getPosition() const;
	void assignCursor(sf::CircleShape& cursor);
	void moveCursor();
};
