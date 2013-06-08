#include "stdafx.h"
#include "ALinkList.h"


ALinkList::ALinkList()
{
	mHead = NULL;
}

ALinkList::~ALinkList()
{
	DeleteList();
}

void ALinkList::DeleteList()
{
	if(!mHead)
	{
		return ;
	}
	AListNode *temp ;
	while(mHead)
	{
		temp = mHead;
		mHead = mHead->Next;
		delete temp;
	}

}

void ALinkList::AddHead(int data)
{
	AListNode *add = new AListNode();
	add->Next = NULL;
	add->data = data;

	if(!mHead)
	{
		mHead = add;
		return;
	}
	add->Next = mHead;
	mHead = add;
}

void ALinkList::AddTail(int data)
{
	AListNode *add = new AListNode();
	add->Next = NULL;
	add->data = data;

	if(!mHead)
	{
		mHead = add;
		return;
	}

	AListNode *temp = mHead;

	while(temp->Next != NULL)
	{
		temp = temp->Next;
	}

	temp->Next = add;
}

int ALinkList::GetLength()
{
	int iCount = 0;
	
	if(!mHead)
	{
		return iCount;
	}
	AListNode *temp = mHead;
	iCount++;

	while(temp)
	{
		temp = temp->Next;
		iCount++;
	}
	return iCount;

}
