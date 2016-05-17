#pragma once

#include "stdafx.h"

class GameEngine
{
private:
	sf::Window _window;
	bool _isStarted;

public:
	GameEngine();
	~GameEngine();

	void Initialize();
	void Start();

private:
	void Update();
	void Draw();
};
