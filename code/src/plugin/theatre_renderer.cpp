#include "plugin/theatre_renderer.h"



using namespace tev::plugin;



TheatreRenderer::TheatreRenderer()
{
	this->render_texture = new sf::RenderTexture(
		sf::Vector2u(2560, 1440),
		sf::ContextSettings()
	);
}

TheatreRenderer::~TheatreRenderer()
{
	delete this->render_texture;
}

sf::RenderTexture* TheatreRenderer::get_render_texture() const
{
	return this->render_texture;
}