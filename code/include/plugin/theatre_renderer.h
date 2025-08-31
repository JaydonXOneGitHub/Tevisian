#pragma once

#include "SFML/Graphics.hpp"
#include <memory>

namespace tev
{
	namespace resource
	{
		class TextureResource;// Forward declaration
	}

	namespace plugin
	{
		class TheaterUI;// Forward declaration

		class TheatreRenderer final
		{
		private:
			sf::RenderTexture* render_texture;
			TheaterUI* tui;
			std::weak_ptr<resource::TextureResource> display_texture;

		private:
			void finish_preparing_render_texture();

		public:
			TheatreRenderer(TheaterUI* tui);
			~TheatreRenderer();

			void initialize();

			void draw();

			sf::RenderTexture* get_render_texture() const;
		};

	}
}