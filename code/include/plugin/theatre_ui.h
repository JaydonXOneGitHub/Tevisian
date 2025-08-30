#pragma once

#include "plugin/plugin.h"
#include "SFML/Graphics.hpp"
#include "SFML/Window.hpp"
#include "plugin/theatre_renderer.h"

namespace tev
{
	namespace plugin
	{





		class TheatreUI : public Plugin
		{
		private:
			sf::RenderWindow* window;
			TheatreRenderer* renderer;

		public:
			TheatreUI();
			~TheatreUI() override;

			void draw() override;
			void update() override;

			std::string get_name() override;

			sf::RenderWindow* get_window() const;

			TheatreRenderer* get_renderer() const;
		};



	}
}