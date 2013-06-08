// LinkList.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "ALinkList.h"


int _tmain(int argc, _TCHAR* argv[])
{
	ALinkList *list = new ALinkList();
	list->AddHead(1);
	list->AddTail(2);
	list->AddTail(3);
	printf("Number of nodes = %d\r\n", list->GetLength());
	delete list;
	return 0;
}

