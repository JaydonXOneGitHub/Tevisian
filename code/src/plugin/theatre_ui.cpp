#include "plugin/theatre_ui.h"
#include "core/tevisian.h"
#include <iostream>
#include "SFML/Window/Joystick.hpp"
#include "core/sf_joypad.h"

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

	this->ui_tree = new tev::ui::UITree();

	// Make space for at least 16 children in the root UI element.
	this->ui_tree->get_root()->resize_children_capacity(16);
}

TheatreUI::~TheatreUI() 
{
	delete this->renderer;
	delete this->window;
}

tev::core::ErrorCode TheatreUI::initialize() 
{
	this->renderer->initialize();

	auto it = this->ui_tree->get_creation_callbacks().find("instantiate_home_screen");

	if (it != this->ui_tree->get_creation_callbacks().end())
	{
		it->second(this->ui_tree->get_root());
	}
	else
	{
		return tev::core::ErrorCode::PLUGIN_INIT_FAIL;
	}

	return tev::core::ErrorCode::OK;
}

void TheatreUI::draw()
{
	this->ui_tree->draw();

	this->window->display();
	this->window->clear(sf::Color(0, 0, 0, 255));
}

void TheatreUI::update() 
{
	this->window->handleEvents(
		// NOTE TO SELF: Pass in this for the lambdas.
		[this](const sf::Event::Closed&){},
		[this](const sf::Event::KeyPressed& key)
		{
			switch (key.scancode)
			{
			case sf::Keyboard::Scancode::Left: {
				this->try_send_signal(Commands::Left);
				break;
			}
			case sf::Keyboard::Scancode::Right: {
				this->try_send_signal(Commands::Right);
				break;
			}
			case sf::Keyboard::Scancode::Up: {
				this->try_send_signal(Commands::Up);
				break;
			}
			case sf::Keyboard::Scancode::Down: {
				this->try_send_signal(Commands::Down);
				break;
			}
			default: {
				break;
			}
			}
		},
		[this](const sf::Event::JoystickButtonPressed& joy_button)
		{
			if (!sf::Joystick::isConnected(joy_button.joystickId))
			{
				std::cout << "Joypad of ID " << joy_button.joystickId << " not connected.\n";
			}

			sf::Joystick::Control c = (sf::Joystick::Control)joy_button.button;

			std::cout << "Button pressed: " << joy_button.button << "\n";

			switch (c)
			{
			case sf::Joystick::Control::Left: {
				this->try_send_signal(Commands::Left);
				break;
			}
			case sf::Joystick::Control::Right: {
				this->try_send_signal(Commands::Right);
				break;
			}
			case sf::Joystick::Control::Up: {
				this->try_send_signal(Commands::Up);
				break;
			}
			case sf::Joystick::Control::Down: {
				this->try_send_signal(Commands::Down);
				break;
			}
			default: {
				break;
			}
			}
		}
	);

	this->ui_tree->update();

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

tev::ui::UITree* TheatreUI::get_ui_tree() const
{
	return this->ui_tree;
}

void TheatreUI::add_command_listener(const std::function<void(const Commands&)>& listener)
{
	this->command_listener = listener;
}

void TheatreUI::try_send_signal(const Commands& command)
{
	if (this->command_listener)
	{
		this->command_listener(command);
	}
	else
	{
		std::cout << "No command listener connected!\n";
	}
}