#pragma once

#include "stdafx.h"

class GameLogger
{
private:
	static GameLogger* _instance;

public:
	static GameLogger& GetInstance();

	void LogInfo(std::string info) const;
	void LogWarning(std::string warning) const;
	void LogError(std::string error) const;
};
