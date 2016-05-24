#pragma once

#include "stdafx.h"

class FontsManager
{
private:
	std::map<std::string, sf::Font*>* _fonts;

	FontsManager();

public:
	static FontsManager& getInstance();

	void loadFont(std::string name);
	sf::Font& getFont(std::string name);
	void unloadFonts();
};
