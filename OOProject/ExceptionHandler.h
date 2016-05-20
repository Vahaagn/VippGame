#pragma once

#include "stdafx.h"

class ExceptionHandler
{
private:
	static ExceptionHandler* _instance;
	
public:
	static ExceptionHandler& GetInstance();
	void Handle(std::exception &exception);

private:
	ExceptionTypeEnum getExceptionType(std::exception &exception);
	void print(std::exception &exception) const;
};
