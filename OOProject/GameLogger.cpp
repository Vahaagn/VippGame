#include "stdafx.h"
#include "GameLogger.h"

GameLogger* GameLogger::_instance = nullptr;

GameLogger& GameLogger::GetInstance()
{
	if (_instance == nullptr)
	{
		_instance = new GameLogger();
	}

	return *_instance;
}

void GameLogger::LogInfo(std::string info) const
{
	std::clog << info << std::endl;
}

void GameLogger::LogWarning(std::string warning) const
{
	std::clog << warning << std::endl;
}

void GameLogger::LogError(std::string error) const
{
	std::cerr << error << std::endl;
}
