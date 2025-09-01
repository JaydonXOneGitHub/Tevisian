#include "ui/ui_configs.h"
#include "ui/ui_tree.h"
#include "ui/selectable_grid_element.h"

using namespace tev::ui;

void instantiate_home_screen(UIElement* root)
{
	SelectableGridElement* sge = new SelectableGridElement(root->get_tree());

	root->deferred_add_child(sge);
}