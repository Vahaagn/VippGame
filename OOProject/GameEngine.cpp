
#include "stdafx.h"
#include "GameEngine.h"
#include "GameException.h"

GameEngine::GameEngine()
	: _isStarted(false), _exception_handler(ExceptionHandler::GetInstance()), _game_logger(GameLogger::GetInstance())
{
}

GameEngine::~GameEngine()
{
}

void GameEngine::Initialize()
{
	_game_logger.LogInfo("Initializing...");

	_isStarted = true;
}

void GameEngine::Start()
{
	_game_logger.LogInfo("Starting...");

	try
	{
		while(_isStarted)
		{
			Update();
			Draw();
		}
	}
	catch(std::exception& exception)
	{
		_exception_handler.Handle(exception);
	}
}

void GameEngine::Update()
{
	throw GameException("No elo exception!");
}

void GameEngine::Draw()
{
}
