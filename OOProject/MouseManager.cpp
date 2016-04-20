#include "stdafx.h"

#include "MouseManager.h"
#include <SFML/Window/Mouse.hpp>

MouseManager::MouseManager(sf::Window& relative_window)
{
	this->relative_window = &relative_window;
}

void MouseManager::update()
{
	moveCursor();
}

sf::Vector2i MouseManager::getPosition() const
{
	return sf::Mouse::getPosition(*relative_window);
}

void MouseManager::assignCursor(sf::CircleShape& cursor)
{
	m_cursor = &cursor;
}

void MouseManager::moveCursor()
{
	sf::Vector2i mousePosition = getPosition();

	m_cursor->setPosition(mousePosition.x, mousePosition.y);
}
