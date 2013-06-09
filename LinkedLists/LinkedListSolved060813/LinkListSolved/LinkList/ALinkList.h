#include "stdafx.h"
#include <iostream>
#include <stack>

class ALinkList
{
public:
	ALinkList();
	~ALinkList();
	void DeleteList();
	void AddHead(int data);
	void AddTail(int data);
	int  GetLength();
	bool IsPalindrome();
	void Reverse();
	bool IsCyclic();
	int FindCycleStart();
	void RetainMDeleteN(int m, int n);
	void RemoveDuplicatesNoBuffer();
	void ReverseEveryKElements(int k);

	void ZipList();
	
	struct AListNode
	{
		int data;
		AListNode *Next;
	};	
	AListNode *GetHeadNode();
	AListNode *ZipMerge(AListNode *node1, AListNode *node2, bool bSwitch);
	
private:
	
	AListNode *mHead;
	AListNode * Reverse(AListNode *node);

};

ALinkList::AListNode *GetIntersection(ALinkList *list1, ALinkList *list2);
ALinkList::AListNode *SortedMerge(ALinkList::AListNode *node1, ALinkList::AListNode *node2);

ALinkList * AddTwoLists(ALinkList::AListNode *node1, ALinkList::AListNode *node2);