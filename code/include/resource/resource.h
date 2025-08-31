#pragma once

#include <string>

namespace tev
{
	namespace resource
	{
		class Resource
		{
		public:
			Resource(const std::string& path);
			virtual ~Resource() = default;
		};
	}
}