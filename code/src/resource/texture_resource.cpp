#include "resource/texture_resource.h"
#include "SFML/Graphics.hpp"

using namespace tev::resource;

TextureResource::TextureResource(const std::string& path) : Resource(path)
{
	this->texture = new sf::Texture();

	if (!this->texture->loadFromFile(path))
	{
		delete this->texture;
		this->texture = nullptr;
		this->width = 0;
		this->height = 0;
		this->data = nullptr;
	}
	else
	{
		this->width = this->texture->getSize().x;
		this->height = this->texture->getSize().y;

		sf::Image img = this->texture->copyToImage();

		const uint8_t* pixels = img.getPixelsPtr();

		size_t size = this->width * this->height * 4; // RGBA

		this->data = new unsigned char[size];

		std::memcpy(this->data, pixels, size);
	}
}

TextureResource::~TextureResource()
{
	this->on_destroyed();
}

void TextureResource::on_destroyed()
{
	if (this->data)
	{
		delete[] this->data;
		this->data = nullptr;
	}

	if (this->texture)
	{
		delete this->texture;
		this->texture = nullptr;
	}

	this->width = 0;
	this->height = 0;
}

int TextureResource::get_width() const
{
	return this->width;
}

int TextureResource::get_height() const
{
	return this->height;
}

const unsigned char* TextureResource::get_data() const
{
	return this->data;
}

sf::Texture* TextureResource::get_texture() const
{
	return this->texture;
}