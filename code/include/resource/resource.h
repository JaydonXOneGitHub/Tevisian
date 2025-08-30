#pragma once

#include <string>

namespace tev
{
	namespace resource
	{
		class Resource
		{
		public:
			Resource(const std::string& path) = delete;
			virtual ~Resource() = default;
		};
	}
}