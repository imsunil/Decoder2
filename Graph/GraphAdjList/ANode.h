#include "stdafx.h"
#include "AEdge.h"
#ifndef _ANODE
#define _ANODE


class ANode
{
public:
	ANode(char ID, int data);
	~ANode();
	void AddEdge( char cEnd, int weight);
	void DeleteEdge(char cEnd); 
	char GetID();
	std::vector<char> GetNeighbours();
	bool IsVisited();
	void SetVisited(bool visited);
	int GetNumEdges();

private:

	char m_ID;
	int m_data;
	std::vector<AEdge *> m_edges;
	bool m_Visited;
};

#endif