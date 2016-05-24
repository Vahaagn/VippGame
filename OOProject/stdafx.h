// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#define TRUE 1
#define FALSE 0
#define DEBUG FALSE

#include "targetver.h"

#include <iostream>
#include <stdio.h>
#include <tchar.h>
#include <functional>
#include <typeinfo>

#include <SFML/OpenGL.hpp>
#include <SFML/Graphics.hpp>
#include <SFML/System.hpp>
#include <SFML/Window.hpp>
#include <SFML/Network.hpp>
#include <SFML/Audio.hpp>

#include "ExceptionTypeEnum.h"
#include "GameException.h"

#include "ExceptionHandler.h"
#include "GameLogger.h"

#include "FontsManager.h"
