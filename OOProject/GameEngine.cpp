#include "stdafx.h"

#include "GameEngine.h"

GameEngine::GameEngine()
{
	//init();
}

GameEngine::~GameEngine()
{
	delete render_window_;
	render_window_ = nullptr;
}

void GameEngine::init()
{
	render_window_ = new sf::RenderWindow(sf::VideoMode(800, 600), "SFML works!");

	if (!font.loadFromFile("consola.ttf"))
	{
		// error...
	}

	fps_counter_ = new FpsCounter(font);
}

void GameEngine::start()
{
	particles = new ParticleSystem(100);
	text_1_ = new TextObject(200, 200, font, "No elo xD", *render_window_);
	text_1_->onHoverAction = [](sf::Mouse& mouse, TextObject& object)->void
	{
		object.setColor(sf::Color::Yellow);
		object.setStyle(sf::Text::Style::Underlined);
	};
	text_1_->onLeaveAction = [](sf::Mouse& mouse, TextObject& object)->void
	{
		object.setColor(sf::Color::White);
		object.setStyle(sf::Text::Style::Regular);
	};
	
	while (render_window_->isOpen())
	{
		sf::Time elapsed_time = update_clock_.restart();

		sf::Event event;
		while (render_window_->pollEvent(event))
		{
			if (event.type == sf::Event::Closed)
				render_window_->close();
		}

		render_window_->clear(sf::Color::Black);

		GameTime game_time(elapsed_time);

		update(game_time);
		draw();

		render_window_->display();
	}
}

void GameEngine::update(GameTime& game_time)
{
	sf::Vector2i mouse = sf::Mouse::getPosition(*render_window_);

	int random_x = rand() % 800;
	int random_y = rand() % 600;
	sf::Vector2f pos(random_x, random_y);

	particles->setEmitter(pos);
	particles->update(game_time.time_);

	text_1_->update();

	if (fps_show_b_ == true)
	{
		fps_counter_->update();
	}
}

void GameEngine::draw()
{
	render_window_->draw(*particles);
	render_window_->draw(*text_1_);

	if (fps_show_b_ == true)
	{
		fps_counter_->display(*render_window_);
	}
}

void GameEngine::show_fps_counter()
{
	fps_show_b_ = true;
}

void GameEngine::hide_fps_counter()
{
	fps_show_b_ = false;
}
