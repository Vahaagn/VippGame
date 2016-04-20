#include "stdafx.h"

#include "InputManager.h"

InputManager::InputManager(sf::Window& relative_window)
{
	mouseManager = new MouseManager(relative_window);
}

MouseManager& InputManager::getMouseManager() const
{
	return *mouseManager;
}
