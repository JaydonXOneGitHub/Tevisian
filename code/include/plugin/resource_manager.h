#pragma once

#include "plugin/plugin.h"
#include "resource/resource.h"
#include <unordered_map>
#include <memory>


namespace tev 
{
	namespace plugin 
	{
		using ResourceCollection = std::unordered_map<std::string, std::shared_ptr<tev::resource::Resource>>;
		using ResourceIterator = ResourceCollection::iterator;

		class ResourceManager : public Plugin
		{
		private:
			ResourceCollection* resources;

		private:
			void true_unload(const ResourceIterator& it);

		public:

			template<typename T>
			std::weak_ptr<T> load(const std::string& path);

			void unload(const std::string& path);

			void unload_all();

			std::string get_name() override;

			ResourceManager();
			~ResourceManager();
		};


	}
}

template<typename T>
std::weak_ptr<T> tev::plugin::ResourceManager::load(const std::string& path)
{
	auto it = this->resources->find(path);

	if (it != this->resources->end())
	{
		return dynamic_cast<T*>(it->second);
	}

	std::unique_ptr<T> t = std::make_shared<T>(path);

	this->resources->insert({ path, t });

	return t;
}