#pragma once
#include <string>

class FileManager
{
	std::string* _settings;
public:
	FileManager();
	FileManager(const FileManager& orig);
	~FileManager();

	void LoadSettings(std::string fileName);
	void ShowFiles() const;

	// getters
	// setters

private:
	std::string* getFileNames();
};
