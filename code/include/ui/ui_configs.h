#pragma once

namespace tev
{
	namespace ui
	{
		// Forward declaration
		class UIElement;
	}
}

// I know this looks weird to put here,
// but I'd imageine that Lua
// may not be the best fit for this.
// Plus, this is the best solution I could
// come up with to avoid having random
// hardcoding all over the place.

void instantiate_home_screen(tev::ui::UIElement* root);