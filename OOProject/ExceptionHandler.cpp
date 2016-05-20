#include "stdafx.h"
#include "ExceptionHandler.h"

ExceptionHandler* ExceptionHandler::_instance = nullptr;

ExceptionHandler& ExceptionHandler::GetInstance()
{
	if (_instance == nullptr)
	{
		_instance = new ExceptionHandler();
	}

	return *_instance;
}

void ExceptionHandler::Handle(std::exception& exception)
{
	auto type = getExceptionType(exception);

	switch(type)
	{
	case GAME_UNKNOWN:
		print(exception);
		break;
	case EXCEPTION:
		print(exception);
		break;
	case UNKNOWN:
		throw;
		break;
	default:
		throw new std::exception("Not implemented Exception!");
		break;
	}
}

void ExceptionHandler::print(std::exception& exception) const
{
	std::cout << exception.what() << std::endl;
}

ExceptionTypeEnum ExceptionHandler::getExceptionType(std::exception& exception)
{
	auto exception_name = typeid(exception).name();

	if (exception_name == "GameException")
	{
		return GAME_UNKNOWN;
	}
	if (exception_name == "exception")
	{
		return EXCEPTION;
	}
	return UNKNOWN;
}
