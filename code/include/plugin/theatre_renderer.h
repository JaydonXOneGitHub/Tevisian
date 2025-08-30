#pragma once

#include "SFML/Graphics.hpp"

namespace tev
{
	namespace plugin
	{


		class TheatreRenderer final
		{
		private:
			sf::RenderTexture* render_texture;

		public:
			TheatreRenderer();
			~TheatreRenderer();

			sf::RenderTexture* get_render_texture() const;
		};

	}
}