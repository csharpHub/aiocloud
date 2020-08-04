#include "Redirector.h"

BOOL aio_main(HMODULE hModule, DWORD fdwReason, LPVOID lpReserved)
{
    /*
    switch (fdwReason)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    */

    return TRUE;
}

#ifdef __cplusplus
extern "C"
{
#endif
    DLLEXPORT BOOL aio_init()
    {
        return TRUE;
    }

    DLLEXPORT BOOL aio_dial(int name, LPSTR value)
    {
        switch (name)
        {
        case TYPE_TCPHost:
        case TYPE_TCPPort:
        case TYPE_TCPPass:
        case TYPE_TCPMeth:
        case TYPE_UDPHost:
        case TYPE_UDPPort:
        case TYPE_UDPPass:
        case TYPE_UDPMeth:
            return TRUE;
        default:
            return FALSE;
        }
    }

    DLLEXPORT BOOL aio_load()
    {
        return TRUE;
    }

    DLLEXPORT BOOL aio_free()
    {
        return TRUE;
    }
#ifdef __cplusplus
}
#endif
