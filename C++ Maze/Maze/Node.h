#pragma once
#include <cstdio>
#include "Location2D.h"
class Node {
public:
	Node* link;
	Location2D data;	//data에 좌표정보 입력
	Node() {}
	Node(Location2D val) : data(val), link(NULL) { }
	Node* getLink() { return link; }
	Location2D getData() { return data; }
	void setLink(Node* next) { link = next; }
	void display() { printf(" <%2d>", data); }
	bool hasData(Location2D val) { return data == val; }

	void insertNext(Node *n) {
		if (n != NULL) {
			n->link = link;
			link = n;
		}
	}

	Node* removeNext() {
		Node* removed = link;
		if (removed != NULL) link = removed->link;
		return removed;
	}
};
