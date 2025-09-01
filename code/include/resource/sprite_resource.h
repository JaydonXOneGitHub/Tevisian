#pragma once

#include "resource/texture_resource.h"
#include "SFML/Graphics/Sprite.hpp"

namespace tev
{
	namespace resource
	{
		class SpriteResource : public Resource
		{
		private:
			TextureResource* texture;
			sf::Sprite* sprite;

		public:
			SpriteResource(const std::string& name);
			~SpriteResource();

			sf::Sprite* get_sprite() const;
			TextureResource* get_texture() const;
		};
	}
}