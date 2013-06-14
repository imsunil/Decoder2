// GraphAdjList.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "AGraph.h"


int _tmain(int argc, _TCHAR* argv[])
{

	AGraph *graph = new AGraph();

	// initialize Nodes
	ANode *nodeA = new ANode('A',10);
	ANode *nodeB = new ANode('B', 10);
	ANode *nodeC = new ANode('C', 10);
	ANode *nodeD = new ANode('D', 10);
	ANode *nodeE = new ANode('E', 10);


	// Add Edges
	nodeA->AddEdge('B',1);
	nodeA->AddEdge('D',1);

	nodeB->AddEdge('A',1);
	nodeB->AddEdge('D',1);
	nodeB->AddEdge('C',1);

	nodeC->AddEdge('B',1);
	nodeC->AddEdge('D',1);
	nodeC->AddEdge('E',1);

	nodeD->AddEdge('A',1);
	nodeD->AddEdge('C',1);

	nodeE->AddEdge('E',1);

	// Add Nodes to Graph
	graph->AddNode(nodeA);
	graph->AddNode(nodeB);
	graph->AddNode(nodeC);
	graph->AddNode(nodeD);
	graph->AddNode(nodeE);

	graph->BreadthFirstSearch('A');

	graph->BreadthFirstSearch('B');


	delete graph;
	return 0;
}

