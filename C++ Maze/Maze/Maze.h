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
	int width; //미로의 너비
	int height; //미로의 높이
	int **map; //미로 맵
	LinkedStack locStack;			//미로찾기에 사용되는 스택연결리스트
	queue<Location2D> locQueue;		//스택 정보를 큐에 넣어서 애니메이션으로 출력
	Location2D exitLoc; //미로의 출구

public:
	Maze() { init(0, 0); }
	~Maze() { reset(); }

	void init(int w, int h) { //map 이차원 배열을 동적으로 할당
		map = new int*[h];
		for (int i = 0; i < h; i++)
			map[i] = new int[w];
	}
	void reset() { //미로 맵 maze를 동적으로 해제
		for (int i = 0; i < height; i++) {
			delete[]map[i];
		}
		delete[]map;
	}
	void load(const char *fname) {	//미로 파일을 읽어옴
		ifstream fin(fname, ios::in);
		fin >> width >> height;
		init(width, height);
		int temp;

		for (int i = 0; i < height; i++) {	//입구와 출구 설정
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

	bool isValidLoc(int r, int c) {	//길인지 벽인지 확인
		if (r < 0 || c < 0 || r >= width || c >= height) //범위를 벗어나면 갈 수 없다
			return false;
		else //비어있는 통로나 도착지점일 때만 true
			return (map[c][r] == 0 || map[c][r] == 9);
	}

	void print() { //현재 Maze를 화면에 출력
		cout << "\n 전체 미로의 크기 = " << width << " * " << height << "\n" << endl;
		cout << " ○ = 출발점,  ◎ = 도착점" << endl;
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				if (map[i][j] == 1) {
					cout << "■";
				}
				else if (map[i][j] == 0) {
					cout << "  ";
				}
				else if (map[i][j] == 3) {
					cout << "☆";
				}
				else if (map[i][j] == 6) {
					cout << "  ";
				}
				else if (map[i][j] == 7) {
					cout << "□";
				}
				else if (map[i][j] == 5) {
					cout << "○";
				}
				else if (map[i][j] == 9) {
					cout << "◎";
				}
			}
			cout << endl;
		}
		cout << endl;
	}


	void printPath() { //Maze 이동경로를 화면에 애니메이션으로 출력
		for (int i = 0; i <= routeCount; i++) {
			system("cls");						//콘솔창 초기화
			Location2D a = locQueue.front();	//스택에 상단 객체 복사
			locQueue.pop();
			int r = a.row;
			int c = a.col;
			map[c][r] = 6;
			cout << "\n 스택에 저장되는 경로 : \n" << endl;
			for (int i = 0; i < height; i++) {
				for (int j = 0; j < width; j++) {
					if (map[i][j] == 1) {
						cout << "■";
					}
					else if (map[i][j] == 0) {
						cout << "  ";
					}
					else if (map[i][j] == 3) {
						cout << "☆";
					}
					else if (map[i][j] == 5) {
						cout << "○";
					}
					else if (map[i][j] == 6) {	//루트 애니메이션용 큐
						cout << "☆";
					}
					else if (map[i][j] == 7) {
						cout << "  ";
					}
					else if (map[i][j] == 9) {
						cout << "◎";
					}
				}
				cout << endl;
			}
			cout << endl;
			Sleep(350);		//0.35초 딜레이
		}
	}

	void printFile() { //Maze 길찾기 결과를 파일에 저장
		cout << "전체 미로의 크기 = " << width << " * " << height << endl;
		cout << " ○ = 출발점,  ◎ = 도착점,  ■ : 벽,  □ : 길,  ☆ : 경로\n" << endl;
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				if (map[i][j] == 1) {
					cout << "■";
				}
				else if (map[i][j] == 0) {
					cout << "□";
				}
				else if (map[i][j] == 3) {
					cout << "☆";
				}
				else if (map[i][j] == 6) {
					cout << "☆";
				}
				else if (map[i][j] == 7) {
					cout << "☆";
				}
				else if (map[i][j] == 5) {
					cout << "○";
				}
				else if (map[i][j] == 9) {
					cout << "◎";
				}
			}
			cout << endl;
		}
		cout << endl;
	}

	void searchExit() { //미로를 탐색하는 함수
		while (locStack.isEmpty() == false) { //스택이 비어있지 않는 동안

			Location2D here = locStack.pop()->getData(); //스택에 상단 객체 복사

			int r = here.row;
			int c = here.col;
			map[c][r] = 7;
			if (exitLoc.col == c && exitLoc.row == r) {
				return;
			}
			else {
				map[c][r] = 7; //지나온 곳으로 표기
				if (isValidLoc(r - 1, c)) {
					locStack.push(new Node(Location2D(r - 1, c)));	//길찾기를 위한 스택
					locQueue.push(Location2D(r - 1, c));			//길찾기의 과정을 보여주기 위한 큐
					routeCount++;									//스택 삽입 순서 = 왼쪽 -> 오른쪽 -> 위 -> 아래
				}													//탐색 순서 = 삽입 순서 반대로
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
		cout << " 실제 이동 경로 : \n" << endl;
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				if (map[i][j] == 1) {
					cout << "■";
				}
				else if (map[i][j] == 0) {
					cout << "  ";
				}
				else if (map[i][j] == 3) {
					cout << "☆";
				}
				else if (map[i][j] == 6) {
					cout << "  ";
				}
				else if (map[i][j] == 7) {
					cout << "□";
				}
				else if (map[i][j] == 5) {
					cout << "○";
				}
				else if (map[i][j] == 9) {
					cout << "◎";
				}
			}
			cout << endl;
		}
		cout << endl;
	}
};