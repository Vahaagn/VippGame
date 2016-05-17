#include "stdafx.h"

#include "ExceptionHandler.h"

void ExceptionHandler::Handle(std::exception& exception)
{
	auto type = getExceptionType(exception);

	switch(type)
	{
		
	}
}

void ExceptionHandler::print(std::exception& exception)
{

}

ExceptionTypeEnum ExceptionHandler::getExceptionType(std::exception& exception)
{
	auto exception_name = typeid(exception).name();

	if (exception_name == "MyException")
	{
		return GAME_UNKNOWN;
	}
	if (exception_name == "exception")
	{
		return EXCEPTION;
	}
	return UNKNOWN;
}
