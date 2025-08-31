#include "plugin/theatre_ui.h"
#include "core/tevisian.h"

using namespace tev::plugin;


TheatreUI::TheatreUI() 
{
#ifdef LINUX
	this->window = new sf::RenderWindow(
		sf::VideoMode::getDesktopMode(),
		sf::String("Tevisian"),
		sf::State::Fullscreen,
		sf::ContextSettings()
	);
#else
	this->window = new sf::RenderWindow(
		sf::VideoMode(sf::Vector2u(1280, 720)),
		sf::String("Tevisian Prototype"),
		sf::State::Windowed,
		sf::ContextSettings()
	);
#endif

	this->renderer = new TheatreRenderer();

	this->renderer->set_ui(this);
}

TheatreUI::~TheatreUI() 
{
	delete this->renderer;
	delete this->window;
}

tev::core::ErrorCode TheatreUI::initialize() 
{
	this->renderer->initialize();
	return tev::core::ErrorCode::OK;
}

void TheatreUI::draw()
{
	this->window->display();
	this->window->clear(sf::Color(0, 0, 0, 255));
}

void TheatreUI::update() 
{
	this->window->handleEvents(
		// NOTE TO SELF: Pass in this for the lambdas.
		[this](const sf::Event::Closed&){}
	);

	this->renderer->draw();
}

std::string TheatreUI::get_name()
{
	return "THEATREUI";
}

sf::RenderWindow* TheatreUI::get_window() const
{
	return this->window;
}

TheatreRenderer* TheatreUI::get_renderer() const
{
	return this->renderer;
}