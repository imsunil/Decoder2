#include "stdafx.h"
#include "ANode.h"
#ifndef _AGRAPH
#define _AGRAPH
class AGraph
{
public : 
	AGraph();
	~AGraph();
	void AddNode( ANode *node);
	ANode * GetNode(char ID);
	char GetStartNode();
	void SetStartNode(char c);
	void ResetVisited();
	void BreadthFirstSearch(char cStart);
private :
	std::vector<ANode *> m_Nodes;
	char m_StartNode;


};
#endif


