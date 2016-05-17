
#include "stdafx.h"

#include "GameEngine.h"

GameEngine::GameEngine()
{
	std::cout<<"Elo"<<std::endl;
}

GameEngine::~GameEngine()
{
}

void GameEngine::Initialize()
{
	_isStarted = true;
}

void GameEngine::Start()
{
	while(_isStarted)
	{
		Update();
		Draw();
	}
}

void GameEngine::Update()
{
}

void GameEngine::Draw()
{
}
