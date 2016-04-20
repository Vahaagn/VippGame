#pragma once

#include "MouseManager.h"

class InputManager
{
private:
	MouseManager* mouseManager;

public:
	InputManager(sf::Window& relative_window);

	MouseManager& getMouseManager() const;
};
