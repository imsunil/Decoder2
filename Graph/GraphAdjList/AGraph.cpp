#include "stdafx.h"
#include "AGraph.h"


AGraph::AGraph()
{
	m_StartNode = '\0';
}
AGraph::~AGraph()
{
	for(int i = 0 ; i < m_Nodes.size(); i ++)
	{
		ANode *node = 	m_Nodes.back();
		delete node;
		m_Nodes.pop_back();
	}
}

void AGraph::AddNode(ANode *node)
{
	m_Nodes.push_back(node);
}

ANode * AGraph::GetNode(char ID)
{
	for(int i = 0 ; i < m_Nodes.size(); i ++)
	{
		ANode *node = m_Nodes.at(i);
		if(node->GetID() == ID)
		{
			return node;
		}		
	}
	return NULL;
}

char AGraph::GetStartNode()
{
	return m_StartNode;
}
void AGraph::SetStartNode(char c)
{
	m_StartNode = c;
}

void AGraph::BreadthFirstSearch(char cStart)
{
	SetStartNode(cStart);
	if(m_StartNode == '\0')
	{
		printf("Graph is empty\r\n");
		return ;
	}
	ResetVisited();
	
	
	ANode * startNode = GetNode(cStart);

	if(startNode == NULL)
	{
		printf("Start node does not exist\r\n");
		return ;
	}
		
	printf("Starting fron Node %c \r\n",cStart);

	queue<ANode *> queueNodes;
	queueNodes.push(startNode);
	startNode->SetVisited(true);
	while(! queueNodes.empty())
	{
		ANode *node = queueNodes.front();
		queueNodes.pop();
		if(! node->IsVisited() )
		{
			printf("Visiting Node %c\r\n", node->GetID());
			node->SetVisited(true);
		}
		std::vector<char> neighbours = node->GetNeighbours();
		
		for(int i = 0 ; i < neighbours.size(); i ++)
		{
			ANode *node = GetNode(neighbours[i]);
			if(! node->IsVisited() )
			{
				printf("Visiting Node %c\r\n", node->GetID());
				node->SetVisited(true);
				queueNodes.push(node);
			}
		}

	}
}

void AGraph::ResetVisited()
{
	for(int i = 0 ; i < m_Nodes.size(); i ++)
	{
		ANode *node = m_Nodes.at(i);
		node->SetVisited(false);
	}
}

