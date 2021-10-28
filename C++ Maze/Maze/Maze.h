#pragma once
#include <iostream>
#include <fstream>
#include "Location2D.h"
#include "LinkedStack.h"
#include <queue>
#include <windows.h>
using namespace std;
static int routeCount;

class Maze {

private:
	int width; //�̷��� �ʺ�
	int height; //�̷��� ����
	int **map; //�̷� ��
	LinkedStack locStack;			//�̷�ã�⿡ ���Ǵ� ���ÿ��Ḯ��Ʈ
	queue<Location2D> locQueue;		//���� ������ ť�� �־ �ִϸ��̼����� ���
	Location2D exitLoc; //�̷��� �ⱸ

public:
	Maze() { init(0, 0); }
	~Maze() { reset(); }

	void init(int w, int h) { //map ������ �迭�� �������� �Ҵ�
		map = new int*[h];
		for (int i = 0; i < h; i++)
			map[i] = new int[w];
	}
	void reset() { //�̷� �� maze�� �������� ����
		for (int i = 0; i < height; i++) {
			delete[]map[i];
		}
		delete[]map;
	}
	void load(const char *fname) {	//�̷� ������ �о��
		ifstream fin(fname, ios::in);
		fin >> width >> height;
		init(width, height);
		int temp;

		for (int i = 0; i < height; i++) {	//�Ա��� �ⱸ ����
			for (int j = 0; j < width; j++) {
				fin >> temp;
				map[i][j] = temp;
				if (map[i][0] == 0) {
					Location2D entry(0, i);
					map[i][0] = 5;
					locStack.push(new Node(entry));
					locQueue.push(entry);
				}
				if (map[0][j] == 0) {
					Location2D entry(j, 0);
					map[0][j] = 5;
					locStack.push(new Node(entry));
					locQueue.push(entry);
				}
				if (map[i][width-1] == 0) {
					exitLoc.col = i;
					exitLoc.row = width-1;
					map[i][width - 1] = 9;
				}
				if (map[height - 1][j] == 0) {
					exitLoc.col = height-1;
					exitLoc.row = j;
					map[height - 1][j] = 9;
				}
			}
			cout << endl;
		}
		fin.close();
	}

	bool isValidLoc(int r, int c) {	//������ ������ Ȯ��
		if (r < 0 || c < 0 || r >= width || c >= height) //������ ����� �� �� ����
			return false;
		else //����ִ� ��γ� ���������� ���� true
			return (map[c][r] == 0 || map[c][r] == 9);
	}

	void print() { //���� Maze�� ȭ�鿡 ���
		cout << "\n ��ü �̷��� ũ�� = " << width << " * " << height << "\n" << endl;
		cout << " �� = �����,  �� = ������" << endl;
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				if (map[i][j] == 1) {
					cout << "��";
				}
				else if (map[i][j] == 0) {
					cout << "  ";
				}
				else if (map[i][j] == 3) {
					cout << "��";
				}
				else if (map[i][j] == 6) {
					cout << "  ";
				}
				else if (map[i][j] == 7) {
					cout << "��";
				}
				else if (map[i][j] == 5) {
					cout << "��";
				}
				else if (map[i][j] == 9) {
					cout << "��";
				}
			}
			cout << endl;
		}
		cout << endl;
	}


	void printPath() { //Maze �̵���θ� ȭ�鿡 �ִϸ��̼����� ���
		for (int i = 0; i <= routeCount; i++) {
			system("cls");						//�ܼ�â �ʱ�ȭ
			Location2D a = locQueue.front();	//���ÿ� ��� ��ü ����
			locQueue.pop();
			int r = a.row;
			int c = a.col;
			map[c][r] = 6;
			cout << "\n ���ÿ� ����Ǵ� ��� : \n" << endl;
			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					if (map[i][j] == 1) {
						cout << "��";
					}
					else if (map[i][j] == 0) {
						cout << "  ";
					}
					else if (map[i][j] == 3) {
						cout << "��";
					}
					else if (map[i][j] == 5) {
						cout << "��";
					}
					else if (map[i][j] == 6) {	//��Ʈ �ִϸ��̼ǿ� ť
						cout << "��";
					}
					else if (map[i][j] == 7) {
						cout << "  ";
					}
					else if (map[i][j] == 9) {
						cout << "��";
					}
				}
				cout << endl;
			}
			cout << endl;
			Sleep(350);		//0.35�� ������
		}
	}

	void printFile() { //Maze ��ã�� ����� ���Ͽ� ����
		cout << "��ü �̷��� ũ�� = " << width << " * " << height << endl;
		cout << " �� = �����,  �� = ������,  �� : ��,  �� : ��,  �� : ���\n" << endl;
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				if (map[i][j] == 1) {
					cout << "��";
				}
				else if (map[i][j] == 0) {
					cout << "��";
				}
				else if (map[i][j] == 3) {
					cout << "��";
				}
				else if (map[i][j] == 6) {
					cout << "��";
				}
				else if (map[i][j] == 7) {
					cout << "��";
				}
				else if (map[i][j] == 5) {
					cout << "��";
				}
				else if (map[i][j] == 9) {
					cout << "��";
				}
			}
			cout << endl;
		}
		cout << endl;
	}

	void searchExit() { //�̷θ� Ž���ϴ� �Լ�
		while (locStack.isEmpty() == false) { //������ ������� �ʴ� ����

			Location2D here = locStack.pop()->getData(); //���ÿ� ��� ��ü ����

			int r = here.row;
			int c = here.col;
			map[c][r] = 7;
			if (exitLoc.col == c && exitLoc.row == r) {
				return;
			}
			else {
				map[c][r] = 7; //������ ������ ǥ��
				if (isValidLoc(r - 1, c)) {
					locStack.push(new Node(Location2D(r - 1, c)));	//��ã�⸦ ���� ����
					locQueue.push(Location2D(r - 1, c));			//��ã���� ������ �����ֱ� ���� ť
					routeCount++;									//���� ���� ���� = ���� -> ������ -> �� -> �Ʒ�
				}													//Ž�� ���� = ���� ���� �ݴ��
				if (isValidLoc(r + 1, c)) {
					locStack.push(new Node(Location2D(r + 1, c)));
					locQueue.push(Location2D(r + 1, c));
					routeCount++;
				}
				if (isValidLoc(r, c - 1)) {
					locStack.push(new Node(Location2D(r, c - 1)));
					locQueue.push(Location2D(r, c - 1));
					routeCount++;
				}
				if (isValidLoc(r, c + 1)) {
					locStack.push(new Node(Location2D(r, c + 1)));
					locQueue.push(Location2D(r, c + 1));
					routeCount++;
				}
			}
		}
	}

	void resultPrint() {
		cout << " ���� �̵� ��� : \n" << endl;
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				if (map[i][j] == 1) {
					cout << "��";
				}
				else if (map[i][j] == 0) {
					cout << "  ";
				}
				else if (map[i][j] == 3) {
					cout << "��";
				}
				else if (map[i][j] == 6) {
					cout << "  ";
				}
				else if (map[i][j] == 7) {
					cout << "��";
				}
				else if (map[i][j] == 5) {
					cout << "��";
				}
				else if (map[i][j] == 9) {
					cout << "��";
				}
			}
			cout << endl;
		}
		cout << endl;
	}
};