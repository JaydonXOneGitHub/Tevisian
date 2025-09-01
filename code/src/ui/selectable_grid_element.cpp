#include "ui/selectable_grid_element.h"
#include "plugin/theatre_ui.h"
#include "core/tevisian.h"
#include "core/plugin_names.h"
#include <iostream>

using namespace tev::ui;

static tev::plugin::TheatreUI* tui;

SelectableGridElement::SelectableGridElement(UITree* tree) 
	: UIElement(tree)
{
	if (tui)
	{
		return;
	}

	tev::plugin::Plugin* p = tev::core::Tevisian::get_singleton()->get_plugin(
		tev::default_names::THEATREUI
	);

	if (!p)
	{
		return;
	}

	tui = dynamic_cast<tev::plugin::TheatreUI*>(p);

	if (!tui)
	{
		return;
	}

	tui->add_command_listener(
		[this](const tev::plugin::TheatreUI::Commands& command)
		{
			using Commands = tev::plugin::TheatreUI::Commands;

			std::cout << "Command recieved!\n";

			switch (command)
			{
			case Commands::Left: {
				std::cout << "They pressed left!\n";
				break;
			}
			case Commands::Right: {
				std::cout << "They pressed right!\n";
				break;
			}
			case Commands::Up: {
				std::cout << "They pressed up!\n";
				break;
			}
			case Commands::Down: {
				std::cout << "They pressed down!\n";
				break;
			}
			default: {
				std::cout << "Unknown command!\n";
				break;
			}
			}
		}
	);
}

void SelectableGridElement::on_destroyed()
{
	tui->add_command_listener(std::function<void(const tev::plugin::TheatreUI::Commands&)>(nullptr));
}

UIElementGrid& SelectableGridElement::get_grid()
{
	return this->grid;
}

void SelectableGridElement::internal_update()
{

}