#include "plugin/resource_manager.h"
#include "core/tevisian.h"
#include "resource/texture_resource.h"
#include "plugin/theatre_ui.h"
#include "core/plugin_names.h"
#include <iostream>



using namespace tev::plugin;




void TheatreRenderer::set_ui(TheatreUI* tui)
{
	this->tui = tui;

	this->tui->get_window()->setView(
		sf::View(
			sf::FloatRect(
				sf::Vector2f(0, 0),
				sf::Vector2f(2560, 1440)
			)
		)
	);

#ifndef LINUX
	this->tui->get_window()->setFramerateLimit(9000);

	this->tui->get_window()->setSize(sf::Vector2u(640, 480));
#endif
}

void TheatreRenderer::initialize()
{
	/*tev::plugin::ResourceManager* rm = static_cast<tev::plugin::ResourceManager*>(
		tev::core::Tevisian::get_singleton()->get_plugin(tev::default_names::RESMAN)
	);

	if (rm)
	{
		this->display_texture = rm->load<tev::resource::TextureResource>(
			"assets/images/scaletest.png"
		);
	}*/
}

void TheatreRenderer::draw()
{
	/*if (this->display_texture.expired())
	{
		std::cout << "WARNING: display texture expired!\n";
		return;
	}

	std::shared_ptr<tev::resource::TextureResource> tex = this->display_texture.lock();

	if (!tex)
	{
		std::cout << "WARNING: display texture is null!\n";
		return;
	}

	sf::Sprite sprite = sf::Sprite(*(tex.get()->get_texture()));

	sprite.setPosition(
		sf::Vector2f(0, 0)
	);

	sprite.setScale(sf::Vector2f(1, 1));

	this->tui->get_window()->draw(sprite);*/
}