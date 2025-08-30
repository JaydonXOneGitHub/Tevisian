#pragma once

#include "plugin/plugin.h"
#include "unordered_map"

namespace tev 
{
    namespace core
    {




        class Tevisian final
        {
        private:
            bool running = true;

            std::unordered_map<std::string, plugin::Plugin*>* plugins;

        public:
            bool is_running() const;

            ~Tevisian();
            Tevisian();

            void register_plugin(plugin::Plugin*);

            void intialize();

            plugin::Plugin* get_plugin(const std::string& name) const;

            void update();
            void draw();

        public:
            static void set_singleton(Tevisian* instance);

            static Tevisian* get_singleton();

            static int terminate();
        };




    }
}