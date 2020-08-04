#ifndef FRAMEWORK_H
#define FRAMEWORK_H
#define WIN32_LEAN_AND_MEAN
#include <Windows.h>

#include <nfdriver.h>
#include <nfevents.h>
#include <nfapi.h>

#define DLLEXPORT __declspec(dllexport)
#define DLLIMPORT __declspec(dllimport)

enum {
	TYPE_TCPHost,
	TYPE_TCPPort,
	TYPE_TCPPass,
	TYPE_TCPMeth,

	TYPE_UDPHost,
	TYPE_UDPPort,
	TYPE_UDPPass,
	TYPE_UDPMeth
};

#endif
