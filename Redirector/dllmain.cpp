#include "Redirector.h"

BOOL APIENTRY DllMain(HMODULE hModule, DWORD fdwReason, LPVOID lpReserved)
{
    return aio_main(hModule, fdwReason, lpReserved);
}
