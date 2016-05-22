
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

	_window.create(sf::VideoMode(800, 600, 24), "Test");
	_window.setFramerateLimit(60);

	_isStarted = true;
}

void GameEngine::Start()
{
	_game_logger.LogInfo("Starting...");

	sf::Clock clock;

	try
	{
		while(_isStarted)
		{
			try
			{
				auto elapsed = clock.restart();

				Update(elapsed);
				Draw(elapsed);
			}
			catch(std::exception& exception)
			{
				_exception_handler.Handle(exception);
			}
		}
	}
	catch(std::exception& exception)
	{
		_exception_handler.Handle(exception);
	}
}

void GameEngine::Update(sf::Time elapsed_time)
{
	//throw GameException(GAME_EXIT, "No elo exception!");

	get_events();
}

void GameEngine::Draw(sf::Time elapsed_time)
{
	_window.clear(sf::Color::Blue);



	_window.display();
}

void GameEngine::get_events()
{
	sf::Event event;
	while (_window.pollEvent(event))
	{
		switch(event.type)
		{
		case sf::Event::Closed:
			_isStarted = false;
			_window.close();
			break;
		}
	}
}
