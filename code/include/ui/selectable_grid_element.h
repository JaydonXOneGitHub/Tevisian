#pragma once

#include "ui/ui_tree.h"
#include <vector>

namespace tev
{
	namespace ui
	{
		using UIElementGrid = std::vector<std::vector<UIElement*>>;

		class SelectableGridElement : public UIElement
		{
		private:
			UIElementGrid grid;

		public:
			UIElementGrid& get_grid();

			SelectableGridElement(UITree* tree);
			
		protected:
			void on_destroyed() override;
			void internal_update() override;
		};
	}
}