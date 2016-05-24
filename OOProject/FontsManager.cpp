#include "stdafx.h"
#include "FontsManager.h"

FontsManager::FontsManager()
{
	_fonts = new std::map<std::string, sf::Font*>();
}

FontsManager& FontsManager::getInstance()
{
	static FontsManager instance;

	return instance;
}

void FontsManager::loadFont(std::string name)
{
	auto logger = GameLogger::GetInstance();

	sf::Font* font = new sf::Font();
	if (!font->loadFromFile(name + ".ttf"))
	{
		logger.LogWarning("Could not load font '" + name + "'!");
		return;
	}

	auto it = _fonts->find(name);
	if (it != _fonts->end())
	{
		logger.LogWarning("Tried to load twice the font '" + name + "'!");
		return;
	}

	_fonts->insert(std::pair<std::string, sf::Font*>(name, font));
	//_fonts[name] = font;
}

sf::Font& FontsManager::getFont(std::string name)
{
	auto it = _fonts->find(name);
	if (it == _fonts->end())
	{
		throw GameException(FONT_NOT_LOADED, "Could not found font with name '" + name + "'!");
	}

	return *it->second;
}

void FontsManager::unloadFonts()
{
	for(auto font: *_fonts)
	{
		delete font.second;
	}

	delete _fonts;
}
