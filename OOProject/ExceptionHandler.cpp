#include "stdafx.h"
#include "ExceptionHandler.h"
#include "GameException.h"

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

	switch (type)
	{
	case GAME_UNKNOWN:
		print(exception);
		break;
	case EXCEPTION:
		print(exception);
		break;
	case GAME_EXIT:
		//
		break;
	case UNKNOWN:
		throw;
		break;
	default:
		throw new std::exception("Not implemented Exception!");
		break;
	}
}

void ExceptionHandler::print(const std::exception& exception) const
{
	std::cout << exception.what() << std::endl;
}


bool ExceptionHandler::is_struct_or_class(const std::string name, const std::exception& exception)
{
	std::string exception_name = typeid(exception).name();

	bool result = "struct " + name == exception_name ||
		"class " + name == exception_name;

	return result;
}

ExceptionTypeEnum ExceptionHandler::getExceptionType(std::exception& exception)
{
	std::string exception_name = typeid(exception).name();

	if (is_struct_or_class("GameException", exception))
	{
		auto game_exception = static_cast<GameException&>(exception);

		return game_exception.GetType();
	}
	if (is_struct_or_class("exception", exception))
	{
		return EXCEPTION;
	}
	return UNKNOWN;
}
