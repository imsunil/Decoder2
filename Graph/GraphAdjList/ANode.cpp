#include "stdafx.h"
#include "ANode.h"

ANode::ANode(char ID, int data)
{
	m_ID = ID;
	m_data = data;
	m_Visited = false;
}

ANode::~ANode()
{
	// delete the node 
	// delete all the edges
	for(int i = 0 ; i < m_edges.size(); i ++)
	{
		AEdge *edge = 	m_edges.back();
		delete edge;
		m_edges.pop_back();
	}
}

void ANode::AddEdge(char cEnd, int weight)
{
	AEdge *edge = new AEdge(m_ID, cEnd, weight);
	m_edges.push_back(edge);
}
void ANode::DeleteEdge(char cEnd)
{
	for(int i = 0 ; i < m_edges.size(); i ++)
	{
		AEdge *edge = m_edges.at(i);
		if(edge->GetEnd() == cEnd)
		{
			m_edges.erase(m_edges.begin() + i);
			break;
		}
	}
}

char ANode::GetID()
{
	return m_ID;
}


std::vector<char> ANode::GetNeighbours()
{
	std::vector<char> neighbours;
	for(int i = 0 ; i < m_edges.size(); i ++)
	{
		neighbours.push_back(m_edges[i]->GetEnd());
	}
	return neighbours;
}

bool ANode::IsVisited()
{
	return m_Visited;
}
void ANode::SetVisited(bool visited)
{
	m_Visited = visited;
}

int ANode::GetNumEdges()
{
	return m_edges.size();
}