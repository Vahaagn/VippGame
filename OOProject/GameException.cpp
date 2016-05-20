#include "stdafx.h"
#include "GameException.h"

GameException::GameException(std::string message) 
	: _type(GAME_UNKNOWN), _message(message)
{
}

GameException::GameException(ExceptionTypeEnum type, std::string message) 
	: _type(type), _message(message)
{
}

GameException::~GameException()
{
}

const char* GameException::what() const throw()
{
	return _message.c_str();
}

ExceptionTypeEnum GameException::GetType() const
{
	return _type;
}

std::string GameException::GetMessageW() const
{
	return _message;
}
