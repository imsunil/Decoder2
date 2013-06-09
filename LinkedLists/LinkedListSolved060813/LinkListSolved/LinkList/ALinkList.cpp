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

ALinkList::AListNode * ALinkList::Reverse(ALinkList::AListNode * node)
{

	if(!node || !node->Next)
	{
		return node;
	}

	AListNode *back = NULL;
	AListNode *mid = node;
	AListNode *front = node->Next;

	while(1)
	{
		mid->Next = back;
		if(!front)
			break;
		back = mid;
		mid = front;
		front = front->Next;
	}
	node = mid;
	return node;
}

void ALinkList::ZipList()
{
	// if list is empty or only one node
	if(!mHead || !mHead->Next)
		return ;
		// find middle of the list
	AListNode *back = mHead;
	AListNode *front = mHead;
	bool bSwitch = true;
	while(front)
	{
		if(bSwitch)
		{
			front = front->Next;
			bSwitch = false;
		}
		else
		{
			front = front->Next;
			back = back->Next;
			bSwitch = true;
		}
	}

	// break the loop now
	AListNode *temp = back->Next;
	back->Next = NULL;
	
	// reverse the last part 
	temp = Reverse(temp);
	back = mHead;
	mHead = ZipMerge(back, temp, true);

}

ALinkList::AListNode * ALinkList::ZipMerge(AListNode *node1, AListNode *node2, bool bSwitch)
{
	ALinkList::AListNode *result = NULL;

	if(!node1)
	return node2;
	if(!node2)
	return node1;
	if(bSwitch)
	{
		result = node1;
		result->Next = SortedMerge(node1->Next, node2);
		bSwitch = false;
	}
	else
	{
		result = node2;
		result->Next = SortedMerge(node1, node2->Next);
		bSwitch = true;
	}

	return result;
}


bool ALinkList::IsPalindrome()
{
	bool bPalindrome = true; 

	// if list is empty or only one node
	if(!mHead || !mHead->Next)
		return bPalindrome;

	// find middle of the list
	AListNode *back = mHead;
	AListNode *front = mHead;
	bool bSwitch = true;
	while(front)
	{
		if(bSwitch)
		{
			front = front->Next;
			bSwitch = false;
		}
		else
		{
			front = front->Next;
			back = back->Next;
			bSwitch = true;
		}
	}

	// break the loop now
	AListNode *temp = back->Next;
	back->Next = NULL;

	// reverse the last part and store 
	//the node for reversing again
	// make front as head
	temp = Reverse(temp);
	AListNode *temp1 = temp;
	front = mHead;


	// compare both link list
	while(front)
	{
		if(front->data != temp->data)
		{
			bPalindrome = false;
			break;
		}
		front = front->Next;
		temp = temp->Next;
	}

	// reverse the broken part again
	temp = Reverse(temp1);
	while(front->Next != NULL)
		front = front->Next;
	front->Next = temp;

	return bPalindrome;
}


void ALinkList::Reverse()
{
	// Check if the list is NULL or there is just one element
	if(!mHead || !mHead->Next)
		return;

	// Declare 3 pointers back middle and front
	// Back should point to NULL, Middle to head
	// and Front to mHead->Next
	AListNode *Back = NULL;

	AListNode *Middle = mHead;

	AListNode *Front = mHead->Next;
	
	// Loop and do pointer manipulations
	// till front is reached to NULL
	while(1)
	{

		Middle->Next = Back;
		if(!Front)
			break;
		Back = Middle;
		Middle = Front;
		Front = Front->Next;

	}
	// Make Head of List to Middle Pointer
	mHead = Middle;

}

bool ALinkList::IsCyclic()
{
	// Get Head Node for the list
	AListNode *node = mHead;

	// If List is null or there is just one node then 
	// list is not cyclic.
	if(!node || !node->Next)
		return false;
	// Declare 2 nodes (Slow and Fast)  and both point to head node. 
	AListNode *Slow = node;
	AListNode * Fast = node;
	// Loop 
	while(1)
	{
		// If Fast Node has reached NULL or Fast->Next is NULL
		// there is no cycle, return false;
		if(!Fast || Fast->Next)
			return false;
		// If Fast Node == Slow or Fast->Next = Slow there is cycle
		// return true.
		else if(Fast == Slow || Fast->Next == Slow)
			return true;
		// Move slow Node by one and Fast Node by 2.
		else
		{
			Slow = Slow->Next;
			Fast = Fast->Next->Next;
		}
	}

}

int ALinkList::FindCycleStart()
{
		// Get Head Node for the list
	AListNode *node = mHead;

	// If List is null or there is just one node then 
	// list is not cyclic.
	if(!node || !node->Next)
		throw new std::string("There is no cycle in this list");
	// Declare 2 nodes (Slow and Fast)  and both point to head node. 
	AListNode *Slow = node;
	AListNode * Fast = node;
	// Loop 
	while(1)
	{
		// If Fast Node has reached NULL or Fast->Next is NULL
		// there is no cycle, return false;
		if(!Fast || Fast->Next)
			throw new std::string("There is no cycle in this list");
		// If Fast Node == Slow  there is cycle
		// return true.
		else if(Fast == Slow )
			break;
		// Move slow Node by one and Fast Node by 2.
		else
		{
			Slow = Slow->Next;
			Fast = Fast->Next->Next;
		}
	}

	// move slow to head and keep moving both of them one node at a time
	Slow = mHead;
	while(Slow != Fast)
	{
		Slow = Slow->Next;
		Fast = Fast->Next;
	}
	return Fast->data;
}

ALinkList::AListNode * ALinkList::GetHeadNode()
{
	return mHead;
}
ALinkList::AListNode *GetIntersection(ALinkList *list1, ALinkList *list2)
{
	ALinkList::AListNode *intersection = NULL;

	int len1 = list1->GetLength();
	int len2 = list2->GetLength();

	ALinkList::AListNode * node1 = list1->GetHeadNode();
	ALinkList::AListNode * node2 = list2->GetHeadNode();

	if(len1 >len2)
	{
		for(int i = 0 ; i < len1-len2; i ++)
			node1 = node1->Next;
	}
	if(len2 > len1)
	{
		for(int i = 0; i < len2-len1; i ++)
			node2 = node2->Next;
	}

	while(node1)
	{
		if(node1 == node2)
		{
			intersection = node1;
			break;
		}
		node1 = node1->Next;
		node2 = node2->Next;
	}
	
	return intersection;

}

ALinkList::AListNode *SortedMerge(ALinkList::AListNode *node1, ALinkList::AListNode *node2)
{
	ALinkList::AListNode *result = NULL;

	if(!node1)
	return node2;
	if(!node2)
	return node1;
	if(node1->data < node2->data)
	{
		result = node1;
		result->Next = SortedMerge(node1->Next, node2);
	}

	else
	{
		result = node2;
		result->Next = SortedMerge(node1, node2->Next);
	}

	return result;

}

ALinkList * AddTwoLists(ALinkList::AListNode *node1, ALinkList::AListNode *node2)
{
	if(!node1 || !node2)
		return NULL;
	ALinkList *list3 = new ALinkList;
	int carry = 0;
	int addValue = 0;
	ALinkList::AListNode *temp1 = node1;
	ALinkList::AListNode *temp2 = node2;

	while(temp1->Next || temp2->Next)
	{

		int value = carry;
		if(temp1)
			value = value + temp1->data;
		if(temp2)
			value = value + temp2->data;

		addValue = value%10;

		if(value > 10)
			carry = 1;
		else
			carry = 0;

		list3->AddTail(addValue);

	}
	return list3;
}

void ALinkList::RetainMDeleteN(int m, int n)
{
	if( m<1 || n< 1)
		return;

	AListNode *temp = mHead;
	bool bFirst = true;
	while(temp)
	{
		// for retaining m array
		for(int i = 0 ; i < m ; i ++)
		{
			if(!temp)
				break;
			if(i == m-1 && bFirst)
			{
				bFirst = false;
				break;
			}
			temp = temp->Next;
		}
		if(!temp)
			break;
		// delete n nodes
		for(int i = 0 ; i < n; i ++)
		{
			AListNode *delNode = temp->Next;
			temp->Next = temp->Next->Next;
			delete delNode;
			if(!temp->Next)
				break;
		}
	}
}

void ALinkList::RemoveDuplicatesNoBuffer()
{
	if(!mHead)
		return;
	AListNode *current =mHead;
	while(current)
	{
		// remove all the nodes which have same value as current.
		AListNode *temp = current;
		while(temp->Next)
		{
			if(temp->Next->data == current->data)
			{
				AListNode *del = temp->Next;
				temp->Next = temp->Next->Next;
				delete del;
			}
			temp = temp->Next;
		}
		current = current->Next;
	}
}

void ALinkList::ReverseEveryKElements(int k)
{
	if ( k < 1)
		return;
	AListNode *tail = mHead;
	AListNode *temp = mHead;
	// switch for reversing
	bool bReverse = true;
	int iCount = 0;
	while(temp)
	{
		
		if(bReverse)
		{
			// create a stack and push k elements in it.
			iCount = 0;
			std::stack<int> *sReverse = new std::stack<int>();

			while(( iCount < k) && (temp) )
			{
				sReverse->push(temp->data);
				iCount ++;
				temp = temp->Next;
			}
			// Now pop the stack and add the elements 
			// from the tail and increase tail
			while(!sReverse->empty())
			{
				tail->data = sReverse->top();
				sReverse->pop();
				tail = tail ->Next;
			}
			bReverse = false;
		}
		else
		{
			// advance the list by k elements.
			iCount = 0;
			while(temp && iCount < k)
			{
				temp = temp->Next;
				iCount ++;
			}
			tail = temp;
			bReverse = true;
		}
	}
}