#ifndef REDIRECTOR_H
#define REDIRECTOR_H
#include "framework.h"

BOOL aio_main(HMODULE hModule, DWORD fdwReason, LPVOID lpReserved);

#ifdef __cplusplus
extern "C"
{
#endif
	DLLEXPORT BOOL aio_init();
	DLLEXPORT BOOL aio_dial(LPCSTR name, LPCSTR value);
	DLLEXPORT BOOL aio_load();
	DLLEXPORT BOOL aio_free();
#ifdef __cplusplus
}
#endif

#endif
