#pragma once

#include "stdafx.h"

class GameEngine
{
private:
	sf::RenderWindow _window;
	bool _isStarted;

	// Helpers
	ExceptionHandler& _exception_handler;
	GameLogger& _game_logger;

public:
	GameEngine();
	~GameEngine();

	void Initialize();
	void Start();

private:
	void Update(sf::Time elapsed_time);
	void Draw(sf::Time elapsed_time);

	void get_events();
};
