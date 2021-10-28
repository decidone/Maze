using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeWF
{
    class MazeSolBfs : Maze
    {
        Queue<Location2D> locQueue = new Queue<Location2D>(); //경로를 저장하는 스택
        Location2D exitLoc = new Location2D(0, 0); //미로의 출구
        public List<Bitmap> solPro = new List<Bitmap>();    //애니메이션을 위한 비트맵 리스트

        public void loadMap()
        {
            locQueue.Clear();
            solPro.Clear();     //전에 만든 비트맵 리스트 제거
            FileManager mgr = new FileManager();
            this.map = mgr.load("Maze.txt");
            this.width = mgr.getWidth();
            this.height = mgr.getHeight();
        }

        public bool isValidLoc(int r, int c)   //길인지 벽인지 확인
        {
            if (r < 0 || c < 0 || r >= height || c >= width) //범위를 벗어나면 갈 수 없다
                return false;
            else
                return (map[r, c] == 0 || map[r, c] == 9); //비어있는 통로나 도착지점일 때만 true
        }

        public void searchExit(int size, bool check)
        {
            this.Size = size;

            //불러온 맵에서 입구와 출구를 찾아서 지정해준다.
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    if (map[i, 0] == 0)
                    {
                        Location2D entry = new Location2D(i, 0);
                        map[i, 0] = 5;
                        locQueue.Enqueue(entry);
                    }
                    if (map[0, j] == 0)
                    {
                        Location2D entry = new Location2D(0, j);
                        map[0, j] = 5;
                        locQueue.Enqueue(entry);
                    }
                    if (map[i, width - 1] == 0)
                    {
                        exitLoc.row = i;
                        exitLoc.col = width - 1;
                        map[i, width - 1] = 9;
                    }
                    if (map[height - 1, j] == 0)
                    {
                        exitLoc.row = height - 1;
                        exitLoc.col = j;
                        map[height - 1, j] = 9;
                    }
                }
                Console.WriteLine();
            }

            //미로찾기
            while (locQueue.Count != 0)
            {
                Location2D here = locQueue.Dequeue();
                int r = here.row;
                int c = here.col;
                this.map[r, c] = 8;

                if (exitLoc.col == c && exitLoc.row == r)
                {
                    return;
                }
                else
                {
                    if (isValidLoc(r - 1, c))   //위, 아래, 왼쪽, 오른쪽 순서로 스택에 삽입
                    {                           //탐색 순서는 오른쪽, 왼쪽, 아래, 위
                        locQueue.Enqueue(new Location2D(r - 1, c));
                    }
                    if (isValidLoc(r + 1, c))
                    {
                        locQueue.Enqueue(new Location2D(r + 1, c));
                    }
                    if (isValidLoc(r, c - 1))
                    {
                        locQueue.Enqueue(new Location2D(r, c - 1));
                    }
                    if (isValidLoc(r, c + 1))
                    {
                        locQueue.Enqueue(new Location2D(r, c + 1));
                    }
                }
                //미로가 너무 크거나 애니메이션 끄기에 체크되어있는 경우는 이미지를 만들지 않는다.
                if (this.width < 55 && this.height < 55 && !check)
                {
                    solPro.Add(bitImg(width, height, Size));
                }
            }
        }
    }
}
