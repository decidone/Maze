using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Maze
{
    public class Maze
    {
        public static int routeCount;
        int width; //미로의 너비
        int height; //미로의 높이
        int[,] map; //미로 맵
        Stack<Location2D> locStack = new Stack<Location2D>(); //스택
        Queue<Location2D> locQueue = new Queue<Location2D>();
        Location2D exitLoc; //미로의 출구

        public Maze() { init(0, 0); }

        public void init(int w, int h)
        { //map 이차원 배열을 동적으로 할당
            map = new int[w, h];
        }

        public void load(string fname)
        { //파일에서 미로 파일을 읽어옴


            StreamReader objReader = new StreamReader(fname);
            string sLine = "";
            ArrayList arrTextLine = new ArrayList();
            ArrayList arrText = new ArrayList();

            char[] delimiterChars = { ' ' };


            while (sLine != null)
            {
                sLine = objReader.ReadLine();


                if (sLine != null)
                {
                    string[] words = sLine.Split(delimiterChars);
                    for (int i = 0; i < words.Length; i++)
                    {
                        arrText.Add(words[i]);
                    }
                    arrTextLine.Add(sLine);
                }
            }
            objReader.Close();

            width = Convert.ToInt32(arrText[0]);
            height = Convert.ToInt32(arrText[1]);
            init(height, width);


            int z = 2;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = Convert.ToInt32(arrText[z]);
                    z++;
                }
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i, 0] == 0)
                    {
                        Location2D entry = new Location2D(0, i);
                        map[i, 0] = 5;
                        locStack.Push(entry);
                        locQueue.Enqueue(entry);
                    }
                    if (map[0, j] == 0)
                    {
                        Location2D entry = new Location2D(j, 0);
                        map[0, j] = 5;
                        locStack.Push(entry);
                        locQueue.Enqueue(entry);
                    }
                    if (map[i, width - 1] == 0)
                    {
                        exitLoc.col = i;
                        exitLoc.row = width - 1;
                        map[i, width - 1] = 9;
                    }
                    if (map[height - 1, j] == 0)
                    {
                        exitLoc.col = height - 1;
                        exitLoc.row = j;
                        map[height - 1, j] = 9;
                    }
                }
                Console.WriteLine();
            }
        }

        public bool isValidLoc(int r, int c)
        {   //길인지 벽인지 확인
            if (r < 0 || c < 0 || r >= width || c >= height) //범위를 벗어나면 갈 수 없다
                return false;
            else //비어있는 통로나 도착지점일 때만 true
                return (map[c, r] == 0 || map[c, r] == 9);
        }

        public void print()
        { //현재 Maze를 화면에 출력
            Console.WriteLine($" 전체 미로의 크기 = {width} * {height}");
            Console.WriteLine(" ○ = 출발점,  ◎ = 도착점");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i, j] == 1)
                    {
                        Console.Write("■");
                    }
                    else if (map[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (map[i, j] == 3)
                    {
                        Console.Write("☆");
                    }
                    else if (map[i, j] == 5)
                    {
                        Console.Write("○");
                    }
                    else if (map[i, j] == 6)
                    {
                        Console.Write("  ");
                    }
                    else if (map[i, j] == 7)
                    {
                        Console.Write("☆");
                    }
                    else if (map[i, j] == 9)
                    {
                        Console.Write("◎");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void printPath()
        { //Maze 이동경로를 화면에 애니메이션으로 출력
            for (int x = 0; x <= routeCount; x++)
            {
                Console.Clear();                      //콘솔창 초기화
                Location2D a = new Location2D();
                a = locQueue.Dequeue();    //스택에 상단 객체 복사
                int r = a.row;
                int c = a.col;
                map[c, r] = 6;
                Console.WriteLine("\n 스택에 저장되는 경로 : \n");
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (map[i, j] == 1)
                        {
                            Console.Write("■");
                        }
                        else if (map[i, j] == 0)
                        {
                            Console.Write("  ");
                        }
                        else if (map[i, j] == 3)
                        {
                            Console.Write("☆");
                        }
                        else if (map[i, j] == 5)
                        {
                            Console.Write("○");
                        }
                        else if (map[i, j] == 6)
                        {
                            Console.Write("☆");
                        }
                        else if (map[i, j] == 7)
                        {
                            Console.Write("  ");
                        }
                        else if (map[i, j] == 9)
                        {
                            Console.Write("◎");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Thread.Sleep(350);     //0.35초 딜레이
            }
        }
        public void searchExit()
        { //미로를 탐색하는 함수

            while (locStack.Count != 0)
            { //스택이 비어있지 않는 동안
                Location2D here = locStack.Pop(); //스택에 상단 객체 복사

                int r = here.row;
                int c = here.col;
                map[c, r] = 7;

                if (exitLoc.col == c && exitLoc.row == r)
                {
                    return;
                }
                else
                {
                    if (isValidLoc(r - 1, c))
                    {
                        locStack.Push(new Location2D(r - 1, c));  //길찾기를 위한 스택
                        locQueue.Enqueue(new Location2D(r - 1, c));            //길찾기의 과정을 보여주기 위한 큐
                        routeCount++;                                   //스택 삽입 순서 = 왼쪽 -> 오른쪽 -> 위 -> 아래
                    }                                                   //탐색 순서 = 삽입 순서 반대로
                    if (isValidLoc(r + 1, c))
                    {
                        locStack.Push(new Location2D(r + 1, c));
                        locQueue.Enqueue(new Location2D(r + 1, c));
                        routeCount++;
                    }
                    if (isValidLoc(r, c - 1))
                    {
                        locStack.Push(new Location2D(r, c - 1));
                        locQueue.Enqueue(new Location2D(r, c - 1));
                        routeCount++;
                    }
                    if (isValidLoc(r, c + 1))
                    {
                        locStack.Push(new Location2D(r, c + 1));
                        locQueue.Enqueue(new Location2D(r, c + 1));
                        routeCount++;
                    }
                }
            }
        }
        public void resultPrint()
        {
            Console.WriteLine(" 실제 이동 경로 : \n");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i, j] == 1)
                    {
                        Console.Write("■");
                    }
                    else if (map[i, j] == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (map[i, j] == 3)
                    {
                        Console.Write("☆");
                    }
                    else if (map[i, j] == 5)
                    {
                        Console.Write("○");
                    }
                    else if (map[i, j] == 6)
                    {
                        Console.Write("  ");
                    }
                    else if (map[i, j] == 7)
                    {
                        Console.Write("□");
                    }
                    else if (map[i, j] == 9)
                    {
                        Console.Write("◎");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
