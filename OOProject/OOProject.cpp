// OOProject.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <SFML/Graphics.hpp>
#include "GameEngine.h"

int getRandomNumber()
{
	return rand() % 100 + 1;
}

sf::Color getRandomColor()
{
	sf::Color color;

	int rand = getRandomNumber() % 3;
	switch (rand)
	{
	case 1:
		color = sf::Color::Red;
		break;
	case 2:
		color = sf::Color::Blue;
		break;
	case 3:
		color = sf::Color::Green;
		break;
	case 4:
		color = sf::Color::Yellow;
		break;
	case 5:
		color = sf::Color::Cyan;
		break;
	default:
		color = sf::Color::Black;
		break;
	}

	return color;
}

int main()
{
	GameEngine game_engine;
	game_engine.init();
	game_engine.start();

	//InputManager input_manager(window);
	//MouseManager& mouse_manager = input_manager.getMouseManager();
	//sf::CircleShape shape(10.f);
	//shape.setFillColor(sf::Color::Green);
	//shape.setPosition((window.getSize().x / 2) - shape.getRadius(), (window.getSize().y / 2) - shape.getRadius());
	//mouse_manager.assignCursor(shape);


	return 0;
}

