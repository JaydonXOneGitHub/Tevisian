#pragma once

#include "ui/ui_tree.h"

namespace tev
{
	namespace ui
	{
		class SelectableUIElement : public UIElement
		{
		public:
			SelectableUIElement(UITree* tree);

			virtual void on_select_entered();
			virtual void on_select_exited();
			virtual void on_selected();
		};
	}
}