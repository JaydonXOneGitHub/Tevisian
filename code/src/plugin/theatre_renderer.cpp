#include "plugin/theatre_renderer.h"
#include "plugin/resource_manager.h"
#include "core/tevisian.h"
#include "resource/texture_resource.h"
#include "plugin/theatre_ui.h"



using namespace tev::plugin;



TheatreRenderer::TheatreRenderer(TheaterUI* tui)
{
	this->render_texture = new sf::RenderTexture(
		sf::Vector2u(2560, 1440),
		sf::ContextSettings()
	);

	this->tui = tui;
}

TheatreRenderer::~TheatreRenderer()
{
	delete this->render_texture;
}

sf::RenderTexture* TheatreRenderer::get_render_texture() const
{
	return this->render_texture;
}

void TheatreRenderer::finish_preparing_render_texture()
{
	this->render_texture->setSmooth(false);
	this->render_texture->setRepeated(false);
	this->render_texture->clear(sf::Color(0, 0, 0, 255));
	this->render_texture->display();
}

void TheatreRenderer::initialize()
{
	this->finish_preparing_render_texture();

	tev::plugin::ResourceManager* rm = static_cast<tev::plugin::ResourceManager*>(
		t->get_plugin(tev::default_names::RESMAN)
		);

	if (rm)
	{
		this->display_texture = rm->load<tev::resource::TextureResource>(
			"assets/images/tevisianlogo.png"
		);
	}
}

void TheatreRenderer::draw()
{
	this->render_texture->clear(sf::Color(0, 0, 0, 255));
	if (this->display_texture.expired())
	{
		return;
	}
	this->render_texture->display();
}