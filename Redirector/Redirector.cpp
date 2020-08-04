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

    DLLEXPORT BOOL aio_dial(int name, LPCSTR value)
    {
        switch (name)
        {
        case TYPE_TCPHost:
            break;
        case TYPE_TCPPort:
            break;
        case TYPE_TCPPass:
            break;
        case TYPE_TCPMeth:
            break;
        case TYPE_UDPHost:
            break;
        case TYPE_UDPPort:
            break;
        case TYPE_UDPPass:
            break;
        case TYPE_UDPMeth:
            break;
        default:
            break;
        }
    }

    DLLEXPORT BOOL aio_load()
    {

    }

    DLLEXPORT BOOL aio_free()
    {

    }
#ifdef __cplusplus
}
#endif
