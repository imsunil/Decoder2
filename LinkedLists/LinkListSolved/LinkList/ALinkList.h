#include "stdafx.h"
class ALinkList
{
public:
	ALinkList();
	~ALinkList();
	void DeleteList();
	void AddHead(int data);
	void AddTail(int data);
	int  GetLength();
	
private:
	struct AListNode
	{
		int data;
		AListNode *Next;
	};
	
	AListNode *mHead;

};