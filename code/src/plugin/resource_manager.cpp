#include "plugin/resource_manager.h"
#include "core/plugin_names.h"

using namespace tev::plugin;



ResourceManager::ResourceManager()
{
	this->resources = new ResourceCollection();
}

ResourceManager::~ResourceManager()
{
	delete this->resources;
}

void ResourceManager::unload(const std::string& path)
{
	auto it = this->resources->find(path);

	if (it == this->resources->end())
	{
		return;
	}

	true_unload(it);
}

void ResourceManager::unload_all()
{
	for (auto it = this->resources->begin(); it != this->resources->end(); it++)
	{
		this->true_unload(it);
	}
}

void ResourceManager::true_unload(const ResourceIterator& it)
{
	it->second.reset();

	this->resources->erase(it->first);
}

std::string ResourceManager::get_name()
{
	return tev::default_names::RESMAN;
}