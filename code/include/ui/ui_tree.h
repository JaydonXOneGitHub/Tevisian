#pragma once

#include <vector>
#include "SFML/Graphics.hpp"
#include <unordered_map>



namespace tev
{
	namespace ui
	{
		class UIElement;

		using SceneCreationCallback = void(*)(UIElement*);

		class UITree
		{
		private:
			UIElement* root;

			std::unordered_map<std::string, SceneCreationCallback> creation_callbacks;

		public:
			UITree();
			~UITree();

			std::unordered_map<std::string, SceneCreationCallback>& get_creation_callbacks();

			UIElement* get_root() const;

			void draw();
			void update();
		};

		class UIElement
		{
		private:
			UIElement* parent;
			UITree* tree;

			std::vector<UIElement*> children;
			std::vector<UIElement*> add_queue;
			std::vector<UIElement*> remove_queue;

			sf::RectangleShape size;
			sf::Vector2f offset;
			sf::Vector2f global_offset;

		protected:
			virtual void internal_draw();
			virtual void internal_update();

			virtual void internal_add_child(UIElement* child);
			virtual void internal_remove_child(UIElement* child);

			virtual void on_destroyed();

		public:
			UIElement(UITree* tree);
			~UIElement();

			virtual void on_added_to_tree();
			virtual void on_removed_from_tree();

			void resize_children_capacity(size_t new_capacity);

			void add_child(UIElement* child);
			void remove_child(UIElement* child);

			void deferred_add_child(UIElement* child);
			void deferred_remove_child(UIElement* child);

			void process_queue();

			UITree* get_tree() const;

			UIElement* get_parent() const;
			const std::vector<UIElement*>& get_children() const;

			void set_parent(UIElement* parent);

			void draw();
			void update();

			sf::Vector2f get_offset() const;
			void set_offset(const sf::Vector2f& offset);

			sf::Vector2f get_global_offset() const;

			sf::RectangleShape& get_size();
		};
	}
}