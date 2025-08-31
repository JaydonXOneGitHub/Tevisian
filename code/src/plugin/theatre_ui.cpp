#include "plugin/theatre_ui.h"
#include "core/tevisian.h"

using namespace tev::plugin;


TheatreUI::TheatreUI() 
{
	this->window = new sf::RenderWindow(
		sf::VideoMode::getDesktopMode(),
		sf::String("Tevisian Prototype"),
		sf::State::Windowed,
		sf::ContextSettings()
	);

	this->renderer = new TheatreRenderer(this);
}

TheatreUI::~TheatreUI() 
{
	delete this->renderer;
	delete this->window;
}

void TheatreUI::draw()
{
	this->window->display();
}

void TheatreUI::update() 
{
	this->window->handleEvents(
		// NOTE TO SELF: Pass in this for the lambdas.
		[this](const sf::Event::Closed&){}
	);
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