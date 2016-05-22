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
	bool is_struct_or_class(const std::string name, const std::exception& exception);
	void print(const std::exception &exception) const;
};
