#pragma once

#include "core/error_code.h"
#include <string>

namespace tev
{
    namespace plugin
    {




        class Plugin
        {
        public:
            virtual tev::core::ErrorCode initialize();
            virtual tev::core::ErrorCode shutdown();
            virtual ~Plugin() = default;
            virtual std::string get_name();
            virtual void update();
            virtual void draw();
        };



    }
}
