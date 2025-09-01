#include "ui/ui_tree.h"
#include <algorithm>

using namespace tev::ui;

UIElement::UIElement(UITree* tree) : tree(tree), parent(nullptr) {}

UIElement::~UIElement() 
{
	this->on_destroyed();

	this->set_parent(nullptr);

	for (UIElement* child : this->children)
	{
		delete child;
	}

	this->children.clear();
}

void UIElement::on_added_to_tree() {}
void UIElement::on_removed_from_tree() {}

void UIElement::resize_children_capacity(size_t new_capacity)
{
	this->children.reserve(new_capacity);
}

void UIElement::add_child(UIElement* child) 
{
	if (child == this)
	{
		return;
	}

	if (child->get_parent() == this)
	{
		return;
	}

	auto it = std::find(
		this->children.begin(),
		this->children.end(),
		child
	);

	if (it == this->children.end())
	{
		this->children.emplace_back((*it));

		child->parent = this;

		child->on_added_to_tree();

		this->internal_add_child(child);
	}
}

void UIElement::remove_child(UIElement* child) 
{
	if (child == this)
	{
		return;
	}

	if (child->get_parent() != this)
	{
		return;
	}

	auto it = std::find(
		this->children.begin(),
		this->children.end(),
		child
	);

	if (it != this->children.end())
	{
		this->children.erase(it);

		child->parent = nullptr;

		child->on_removed_from_tree();

		this->internal_remove_child(child);
	}
}

UIElement* UIElement::get_parent() const 
{
	return this->parent;
}

const std::vector<UIElement*>& UIElement::get_children() const 
{
	return this->children;
}

void UIElement::set_parent(UIElement* parent) 
{
	if (parent == this)
	{
		return;
	}

	if (this->parent == parent)
	{
		return;
	}

	if (this->parent)
	{
		this->parent->remove_child(this);
	}

	if (parent)
	{
		parent->add_child(this);
	}
}

void UIElement::internal_draw() {}
void UIElement::internal_update() {}

void UIElement::draw() 
{
	for (UIElement* child : this->children)
	{
		child->draw();
	}

	this->internal_draw();
}

void UIElement::update()
{
	this->process_queue();

	if (this->parent)
	{
		this->global_offset = this->offset + this->parent->get_global_offset();
	}
	else
	{
		this->global_offset = this->offset;
	}

	for (UIElement* child : this->children)
	{
		child->update();
	}

	this->internal_update();
}

void UIElement::internal_add_child(UIElement* child) {}
void UIElement::internal_remove_child(UIElement* child) {}

void UIElement::on_destroyed() {}

sf::Vector2f UIElement::get_offset() const
{
	return this->offset;
}
void UIElement::set_offset(const sf::Vector2f& offset)
{
	this->offset = offset;
}

sf::Vector2f UIElement::get_global_offset() const
{
	return this->global_offset;
}

sf::RectangleShape& UIElement::get_size()
{
	return this->size;
}
void UIElement::deferred_add_child(UIElement* child) 
{
	auto it = std::find(
		this->add_queue.begin(),
		this->add_queue.end(),
		child
	);

	if (it != this->add_queue.end())
	{
		return;
	}

	this->add_queue.emplace_back(child);
}

void UIElement::deferred_remove_child(UIElement* child) 
{
	auto it = std::find(
		this->remove_queue.begin(),
		this->remove_queue.end(),
		child
	);

	if (it != this->remove_queue.end())
	{
		return;
	}

	this->remove_queue.emplace_back(child);
}

void UIElement::process_queue()
{
	for (UIElement* to_be_added : this->remove_queue)
	{
		auto it = std::find(
			this->children.begin(),
			this->children.end(),
			to_be_added
		);

		if (it != this->children.end())
		{
			this->children.erase(it);
		}
	}

	for (UIElement* to_be_added : this->add_queue)
	{
		auto it = std::find(
			this->children.begin(),
			this->children.end(),
			to_be_added
		);

		if (it == this->children.end())
		{
			this->children.emplace_back(to_be_added);
		}
	}

	this->remove_queue.clear();
	this->add_queue.clear();
}

UITree* UIElement::get_tree() const
{
	return this->tree;
}