#include "core/linux_interface.h"

#ifdef LINUX

#endif // LINUX



static void* x11_handle = nullptr;
static void* terminal_handle = nullptr;



namespace tev
{
	namespace interface
	{
		void initialize()
		{
#ifdef LINUX
			// Linux-specific initialization code goes here.
#else

#endif
		}

		void* get_x11_handle()
		{
			return x11_handle;
		}

		void* get_terminal_handle()
		{
			return terminal_handle;
		}
	}
}