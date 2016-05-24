// OOProject.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "GameEngine.h"

int main()
{
	GameEngine game_engine;
	game_engine.Initialize();
	game_engine.Start();

	//InputManager input_manager(window);
	//MouseManager& mouse_manager = input_manager.getMouseManager();
	//sf::CircleShape shape(10.f);
	//shape.setFillColor(sf::Color::Green);
	//shape.setPosition((window.getSize().x / 2) - shape.getRadius(), (window.getSize().y / 2) - shape.getRadius());
	//mouse_manager.assignCursor(shape);

#if DEBUG
	system("PAUSE");
#endif DEBUG

	return 0;
}

