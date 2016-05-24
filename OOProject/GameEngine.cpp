
#include "stdafx.h"
#include "GameEngine.h"
#include "GameException.h"

GameEngine::GameEngine()
	: _isStarted(false), _exception_handler(ExceptionHandler::GetInstance()), _game_logger(GameLogger::GetInstance())
{
}

GameEngine::~GameEngine()
{
	auto font_manager = FontsManager::getInstance();
	font_manager.unloadFonts();
}

void GameEngine::Initialize()
{
	_game_logger.LogInfo("Initializing...");

	_window.create(sf::VideoMode(800, 600, 24), "Test");
	_window.setFramerateLimit(60);

	auto font_manager = FontsManager::getInstance();
	font_manager.loadFont("consola");

	_fps_counter = new FpsCounter();
	_character = new Character();

	try
	{
		_fps_counter->initialize();		
		_character->initialize();
	}
	catch(std::exception& exception)
	{
		_exception_handler.Handle(exception);
	}

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

void GameEngine::Stop()
{
	_isStarted = false;
}


void GameEngine::Close()
{
	Stop();
	_window.close();
}

void GameEngine::Update(sf::Time elapsed_time)
{
	//throw GameException(GAME_EXIT, "No elo exception!");

	get_events();

	if (sf::Keyboard::isKeyPressed(sf::Keyboard::Escape)) Close();

	_fps_counter->update(elapsed_time);
}

void GameEngine::Draw(sf::Time elapsed_time)
{
	_window.clear(sf::Color::Black);

	_window.draw(*_fps_counter);
	_window.draw(*_character);

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
			Close();
			break;
		case sf::Event::Resized: break;
		case sf::Event::LostFocus: break;
		case sf::Event::GainedFocus: break;
		case sf::Event::TextEntered: break;
		case sf::Event::KeyPressed: break;
		case sf::Event::KeyReleased: break;
		case sf::Event::MouseWheelMoved: break;
		case sf::Event::MouseWheelScrolled: break;
		case sf::Event::MouseButtonPressed: break;
		case sf::Event::MouseButtonReleased: break;
		case sf::Event::MouseMoved: break;
		case sf::Event::MouseEntered: break;
		case sf::Event::MouseLeft: break;
		case sf::Event::JoystickButtonPressed: break;
		case sf::Event::JoystickButtonReleased: break;
		case sf::Event::JoystickMoved: break;
		case sf::Event::JoystickConnected: break;
		case sf::Event::JoystickDisconnected: break;
		case sf::Event::TouchBegan: break;
		case sf::Event::TouchMoved: break;
		case sf::Event::TouchEnded: break;
		case sf::Event::SensorChanged: break;
		case sf::Event::Count: break;
		default: break;
		}
	}
}
