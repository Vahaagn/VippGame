#pragma once

#include "stdafx.h"

struct GameException : public std::exception
{
private:
	ExceptionTypeEnum _type;
	std::string _message;

public:
	GameException(std::string message);
	GameException(ExceptionTypeEnum type, std::string message);
	virtual ~GameException();

	const char* what() const throw() override;
	ExceptionTypeEnum GetType() const;
	std::string GetMessage() const;
};
