#pragma once

namespace tev
{
    namespace core
    {



        enum class ErrorCode : long long
        {
            OK = 0,
            PLUGIN_NOT_ESTABLISHED = -100,
            PLUGIN_INIT_FAIL = -1,
            PLUGIN_SHUTDOWN_FAIL = -2,
            PLUGIN_REGISTER_FAIL = -3,
        };


    }
}