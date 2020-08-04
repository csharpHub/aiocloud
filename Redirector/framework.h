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
	TYPE_TCPHOST,
	TYPE_TCPPORT,
	TYPE_TCPPASS,
	TYPE_TCPCIPH,

	TYPE_UDPHOST,
	TYPE_UDPPORT,
	TYPE_UDPPASS,
	TYPE_UDPCIPH,

	TYPE_ADDNAME,
	TYPE_CLRNAME
};

#endif
