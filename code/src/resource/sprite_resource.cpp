#include "resource/sprite_resource.h"

using namespace tev::resource;

SpriteResource::SpriteResource(const std::string& path) : Resource(path)
{
	this->texture = new TextureResource(path);
	this->sprite = new sf::Sprite(*this->texture->get_texture());
}

SpriteResource::~SpriteResource()
{
	if (this->sprite)
	{
		delete this->sprite;
		this->sprite = nullptr;
	}

	if (this->texture)
	{
		delete this->texture;
		this->texture = nullptr;
	}
}

sf::Sprite* SpriteResource::get_sprite() const 
{
	return this->sprite;
}

TextureResource* SpriteResource::get_texture() const 
{
	return this->texture;
}