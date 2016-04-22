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

	// STILL NOT WORK AS I WANT
	std::string vert = "void main()\
					   {\
					   gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;\
					   gl_TexCoord[0] = gl_TextureMatrix[0] * gl_MultiTexCoord0;\
					   gl_FrontColor = gl_Color;\
					   }";
	std::string frag = "uniform sampler2D texture;\
					   void main()\
					   {\
					   vec4 pixel = texture2D(texture, gl_TexCoord[0].xy);\
					   gl_FragColor = gl_Color * pixel;\
					   }";

	test_shader.setParameter("texture", sf::Shader::CurrentTexture);

	if (!test_shader.isAvailable())
	{
		std::cout << "Shader not available!" << std::endl;
	}
	if(!test_shader.loadFromMemory(vert, sf::Shader::Vertex))
	{
		std::cout << "Shader Vertex not loaded!" << std::endl;
	}
	if(!test_shader.loadFromMemory(frag, sf::Shader::Fragment))
	{
		std::cout << "Shader Fragment not loaded!" << std::endl;
	}
	// :(

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
	sf::Shader::bind(&test_shader);

	render_window_->draw(*particles);
	render_window_->draw(*text_1_, &test_shader);

	sf::CircleShape circle(100);
	circle.setFillColor(sf::Color::Green);
	render_window_->draw(circle, &test_shader);

	sf::VertexArray triangle(sf::Triangles, 3);

	// define the position of the triangle's points
	triangle[0].position = sf::Vector2f(10, 10);
	triangle[1].position = sf::Vector2f(100, 10);
	triangle[2].position = sf::Vector2f(100, 100);

	// define the color of the triangle's points
	triangle[0].color = sf::Color::Red;
	triangle[1].color = sf::Color::Blue;
	triangle[2].color = sf::Color::Green;
	render_window_->draw(triangle, &test_shader);

	// create a quad
	sf::VertexArray quad(sf::Quads, 4);

	// define it as a rectangle, located at (10, 10) and with size 100x100
	quad[0].position = sf::Vector2f(10, 10);
	quad[1].position = sf::Vector2f(110, 10);
	quad[2].position = sf::Vector2f(110, 110);
	quad[3].position = sf::Vector2f(10, 110);

	// define its texture area to be a 25x50 rectangle starting at (0, 0)
	quad[0].texCoords = sf::Vector2f(0, 0);
	quad[1].texCoords = sf::Vector2f(25, 0);
	quad[2].texCoords = sf::Vector2f(25, 50);
	quad[3].texCoords = sf::Vector2f(0, 50);
	render_window_->draw(quad, &test_shader);

	sf::Shader::bind(NULL);

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
