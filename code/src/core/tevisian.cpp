#include "core/tevisian.h"
#include <random>
#include <climits>
#include "core/plugin_names.h"
#include <iostream>


using namespace tev::core;




static Tevisian* singleton_instance = nullptr;






bool Tevisian::is_running() const
{
    return this->running;
}

Tevisian::Tevisian()
{
    this->plugins = new std::unordered_map<std::string, tev::plugin::Plugin*>();
}

Tevisian::~Tevisian()
{
    for (auto it = this->plugins->begin(); it != this->plugins->end(); it++)
    {
        tev::plugin::Plugin* p = it->second;

        p->shutdown();

        delete p;
    }

    delete this->plugins;
}

void Tevisian::register_plugin(tev::plugin::Plugin* plugin)
{
    if (!plugin)
    {
        tev::plugin::Plugin* ui = this->get_plugin(tev::default_names::UI_PLUGIN);

        if (ui)
        {
            // Display an error.
        }
        else
        {
            std::cout << "ERROR: plugin is null!\n";
        }

        return;
    }

    if (this->get_plugin(plugin->get_name()))
    {
        tev::plugin::Plugin* ui = this->get_plugin(tev::default_names::UI_PLUGIN);

        if (ui)
        {
            // Display an error.
        }
        else
        {
            std::cout << "ERROR: plugin is already attached!\n";
        }
        return;
    }

    this->plugins->insert({ plugin->get_name(), plugin });
}


void Tevisian::intialize()
{
    for (auto it = this->plugins->begin(); it != this->plugins->end(); it++)
    {
        it->second->initialize();
    }
}


tev::plugin::Plugin* Tevisian::get_plugin(const std::string& name) const
{
    auto it = this->plugins->find(name);

    tev::plugin::Plugin* res = nullptr;

    if (it != this->plugins->end())
    {
        res = it->second;
    }

    return res;
}

void Tevisian::update()
{
    for (auto it = this->plugins->begin(); it != this->plugins->end(); it++)
    {
        it->second->update();
    }
}

void Tevisian::draw()
{
    for (auto it = this->plugins->begin(); it != this->plugins->end(); it++)
    {
        it->second->draw();
    }
}



void Tevisian::set_singleton(Tevisian* instance)
{
    singleton_instance = instance;
}

Tevisian* Tevisian::get_singleton()
{
    return singleton_instance;
}

int Tevisian::terminate()
{
    if (!singleton_instance)
    {
        return -1;
    }

    singleton_instance->running = false;

    delete singleton_instance;

    singleton_instance = nullptr;

    return 0;
}