#include "stdafx.h"
#ifndef _AEDGE
#define _AEDGE

class AEdge
{
public:
	AEdge(char start, char end, int weight);
	~AEdge();
	char GetStart();
	char GetEnd();
private:
	char cStart;
	char cEnd;
	int iWeight;

};

#endif