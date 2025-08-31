#pragma once

#include "plugin/plugin.h"
#include "SFML/Graphics.hpp"
#include "SFML/Window.hpp"
#include "resource/texture_resource.h"
#include <memory>


namespace tev
{
	namespace plugin
	{



		class TheatreUI;
		class TheatreRenderer;






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

			tev::core::ErrorCode initialize() override;
		};




		class TheatreRenderer
		{
		private:
			TheatreUI* tui;
			std::weak_ptr<resource::TextureResource> display_texture;

		public:
			void set_ui(TheatreUI* tui);

			void initialize();

			void draw();
		};



	}
}