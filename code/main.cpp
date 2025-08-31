#include "core/tevisian.h"

#include "plugin/theatre_ui.h"
#include "plugin/resource_manager.h"

#include "resource/texture_resource.h"

#include "core/plugin_names.h"
#include <iostream>



using namespace tev::core;




static void register_plugins(tev::core::Tevisian* t)
{
    t->register_plugin(new tev::plugin::TheatreUI());
    t->register_plugin(new tev::plugin::ResourceManager());
}


int main(int argc, char** argv)
{
    tev::core::Tevisian::set_singleton(new tev::core::Tevisian());

    tev::core::Tevisian* t = tev::core::Tevisian::get_singleton();

    register_plugins(t);

    t->intialize();

    while (t->is_running())
    {
        t->update();
        t->draw();
    }

    return tev::core::Tevisian::terminate();
}