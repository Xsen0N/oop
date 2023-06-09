# include <iostream>
using namespace std;

struct list
{
	int value;
	list* next = nullptr;
};

struct stack
{
	int value;
	stack* previous = nullptr;
};

struct queue
{
	int value;
	queue* previous = nullptr;
};

list spisokSmezhnosti[10];

int spisokReber[10][2] =
{
	{ 1, 5 },
	{ 2, 7 },
	{ 2, 8 },
	{ 7, 8 },
	{ 3, 8 },
	{ 5, 6 },
	{ 4, 6 },
	{ 4, 9 },
	{ 6, 9 },
	{ 9, 10 }
};

bool matricaSmezhnosti[10][10] =
{
	{ 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},//1
	{ 0, 0, 0, 0, 0, 0, 1, 1, 0, 0},//2
	{ 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},//3
	{ 0, 0, 0, 0, 0, 1, 0, 0, 1, 0},//4
	{ 1, 0, 0, 0, 0, 1, 0, 0, 0, 0},//5
	{ 1, 0, 0, 1, 1, 0, 0, 0, 1, 0},//6
	{ 0, 1, 0, 0, 0, 0, 0, 1, 0, 0},//7
	{ 0, 1, 1, 0, 0, 0, 1, 0, 0, 0},//8
	{ 0, 0, 0, 1, 0, 1, 0, 0, 0, 1},//9
	{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},//10
};

void addVertex(int vertex, int number) //добавляет вершину vertex в список вершины number
{
	list* listPtr = new list;
	*listPtr = { vertex };
	list tempList = spisokSmezhnosti[number];
	while (tempList.next != nullptr) tempList = *(tempList.next);
	tempList.next = listPtr;
}

void pushToStack(stack** pointer, int vertex)
{
	stack* newVertex = new stack;
	*newVertex = { vertex, *pointer };
	*pointer = newVertex;
}
void popFromStack(stack** pointer)
{
	stack* tempPtr = *pointer;
	*pointer = (*pointer)->previous;
	delete tempPtr;
}

bool notVisitedOrInStack(stack* ptrVisited, stack* ptrStack, int value)
{
	do
	{
		if (ptrVisited->value == value) return 0;
		else if (ptrVisited->previous == nullptr) break;
		else ptrVisited = ptrVisited->previous;
	} while (ptrVisited->value != 0);
	do
	{
		if (ptrStack->value == value) return 0;
		else if (ptrStack->previous == nullptr) break;
		else ptrStack = ptrStack->previous;
	} while (ptrStack->value != 0);
	return 1;
}

void DFS(int currentVertex, int destination)
{
	stack* stackPointer = new stack;
	stackPointer->value = { 0 };
	stack* visitedPointer = new stack;
	visitedPointer->value = { 0 };
	while (currentVertex != destination)
	{
		stack* temp = new stack;
		*temp = { currentVertex, visitedPointer };
		visitedPointer = temp;
		for (int i = 0; i < 10; i++)
		{
			if (spisokReber[i][0] == currentVertex && notVisitedOrInStack(visitedPointer, stackPointer, spisokReber[i][1]))
			{
				pushToStack(&stackPointer, spisokReber[i][1]);
			}
			if (spisokReber[i][1] == currentVertex && notVisitedOrInStack(visitedPointer, stackPointer, spisokReber[i][0]))
			{
				pushToStack(&stackPointer, spisokReber[i][0]);
			}
		}
		if (stackPointer->value != 0)
		{
			cout << "Текущий стек: ";
			stack* temp = stackPointer;
			while (temp->value != 0)
			{
				cout << temp->value << " ";
				temp = temp->previous;
			}
			cout << endl << "Перейти в вершину " << stackPointer->value << endl;
			currentVertex = stackPointer->value;
			popFromStack(&stackPointer);
		}
	}
}

void BFS(int currentVertex, int destination)
{
	stack* stackPointer = new stack;
	stackPointer->value = { 0 };
	stack* visitedPointer = new stack;
	visitedPointer->value = { 0 };
	while (currentVertex != destination)
	{
		stack* temp = new stack;
		*temp = { currentVertex, visitedPointer };
		visitedPointer = temp;
		for (int i = 0; i < 10; i++)
		{
			if (spisokReber[i][0] == currentVertex && notVisitedOrInStack(visitedPointer, stackPointer, spisokReber[i][1]))
			{
				pushToStack(&stackPointer, spisokReber[i][1]);
			}
			if (spisokReber[i][1] == currentVertex && notVisitedOrInStack(visitedPointer, stackPointer, spisokReber[i][0]))
			{
				pushToStack(&stackPointer, spisokReber[i][0]);
			}
		}
		if (stackPointer->value != 0)
		{
			cout << "Текущий стек: ";
			stack* temp = stackPointer;
			while (temp->value != 0)
			{
				cout << temp->value << " ";
				temp = temp->previous;
			}
			cout << endl << "Перейти в вершину " << stackPointer->value << endl;
			currentVertex = stackPointer->value;
			popFromStack(&stackPointer);
		}
	}
}

void main()
{
	setlocale(LC_ALL, "ru");
	addVertex(5, 1);
	addVertex(7, 2);
	addVertex(8, 2);
	addVertex(8, 3);
	addVertex(6, 4);
	addVertex(9, 4);
	addVertex(1, 5);
	addVertex(6, 5);
	addVertex(4, 6);
	addVertex(5, 6);
	addVertex(9, 6);
	addVertex(2, 7);
	addVertex(8, 7);
	addVertex(2, 8);
	addVertex(3, 8);
	addVertex(7, 8);
	addVertex(4, 9);
	addVertex(6, 9);
	addVertex(10, 9);
	addVertex(9, 10);

	DFS(1, 8);
}