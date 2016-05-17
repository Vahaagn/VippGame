#pragma once

#include "stdafx.h"

class ExceptionHandler
{
private:
	
public:
	void Handle(std::exception &exception);

private:
	ExceptionTypeEnum getExceptionType(std::exception &exception);
	void print(std::exception &exception);
};
