#pragma once

#include "resource/resource.h"
#include "SFML/Graphics/Texture.hpp"

namespace tev
{
	namespace resource
	{
		class TextureResource : public Resource
		{
		public:
			TextureResource(const std::string& path);
			~TextureResource() override;

			int get_width() const;
			int get_height() const;

			const unsigned char* get_data() const;

			sf::Texture* get_texture() const;

		private:
			void on_destroyed();

		private:
			int width;
			int height;

			unsigned char* data;

			sf::Texture* texture;
		};
	}
}