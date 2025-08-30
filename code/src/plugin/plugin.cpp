#include "plugin/plugin.h"

using namespace tev::plugin;
using namespace tev::core;

ErrorCode Plugin::initialize()
{
    return ErrorCode::PLUGIN_NOT_ESTABLISHED;
}

ErrorCode Plugin::shutdown()
{
    return ErrorCode::PLUGIN_NOT_ESTABLISHED;
}

std::string Plugin::get_name()
{
    return "GENERIC_PLUGIN_FOR_TEVISIAN";
}

void Plugin::update() { }
void Plugin::draw() { }