using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Threading;

namespace Maze
{
    public class MainApp
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(); //미로 탐색 객체 생성
            maze.load("Maze.txt");
            maze.print();
            Thread.Sleep(3000);            //3초간 미로를 보여준 후 길찾기 실행.

            maze.searchExit();
            maze.print();
            maze.printPath();       //미로를 탐색하면서 스택에 넣은 정보를 애니메이션으로 출력하는 함수.
            Console.Clear();

            maze.load("Maze.txt");  //위에서 미로 정보를 수정했으므로 새로 미로파일을 로드해온다.
            maze.searchExit();
            maze.resultPrint();		//실제 이동경로.
        }
    }
}
