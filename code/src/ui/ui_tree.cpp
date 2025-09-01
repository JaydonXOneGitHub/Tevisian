#include "ui/ui_tree.h"
#include "ui/ui_configs.h"

#define NAMEOF(x) #x

using namespace tev::ui;

UITree::UITree()
{
	this->root = new UIElement(this);

	creation_callbacks.insert({
		NAMEOF(instantiate_home_screen),
		instantiate_home_screen
	});
}

UITree::~UITree()
{
	delete this->root;
}

UIElement* UITree::get_root() const
{
	return this->root;
}

void UITree::draw()
{
	this->root->draw();
}

void UITree::update()
{
	this->root->update();
}

std::unordered_map<std::string, SceneCreationCallback>& UITree::get_creation_callbacks()
{
	return this->creation_callbacks;
}