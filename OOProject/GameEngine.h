#pragma once

#include "stdafx.h"
#include "Character.h"
#include "FpsCounter.h"

class GameEngine
{
private:
	sf::RenderWindow _window;
	bool _isStarted;

	// Objects
	Character* _character;
	FpsCounter* _fps_counter;

	// Helpers
	ExceptionHandler& _exception_handler;
	GameLogger& _game_logger;

public:
	GameEngine();
	~GameEngine();

	void Initialize();
	void Start();
	void Stop();
	void Close();

private:
	void Update(sf::Time elapsed_time);
	void Draw(sf::Time elapsed_time);

	void get_events();
};
