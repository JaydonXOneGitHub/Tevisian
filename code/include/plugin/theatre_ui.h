#pragma once

#include "plugin/plugin.h"
#include "SFML/Graphics.hpp"
#include "SFML/Window.hpp"
#include "resource/texture_resource.h"
#include <memory>
#include "ui/ui_tree.h"
#include <functional>


namespace tev
{
	namespace plugin
	{



		class TheatreUI;
		class TheatreRenderer;






		class TheatreUI : public Plugin
		{
		public:
			enum class Commands
			{
				Left,
				Right,
				Up,
				Down,
				Select,
				Back,
				Submenu,
				Home
			};

		private:
			sf::RenderWindow* window;
			TheatreRenderer* renderer;
			tev::ui::UITree* ui_tree;

			std::function<void(const Commands&)> command_listener;

		private:
			void try_send_signal(const Commands& command);

		public:
			TheatreUI();
			~TheatreUI() override;

			void draw() override;
			void update() override;

			std::string get_name() override;

			sf::RenderWindow* get_window() const;

			TheatreRenderer* get_renderer() const;

			tev::ui::UITree* get_ui_tree() const;

			tev::core::ErrorCode initialize() override;

			void add_command_listener(const std::function<void(const Commands&)>& listener);
			
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