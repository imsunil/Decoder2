#include "stdafx.h"
#include "AEdge.h"

AEdge::AEdge(char start, char end, int weight)
{
	cStart = start;
	cEnd = end;
	iWeight = weight;
}
AEdge::~AEdge()
{
	
}
char AEdge::GetStart()
{
	return cStart;
}

char AEdge::GetEnd()
{
	return cEnd;
}