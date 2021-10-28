using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeWF
{
    class MazeGen : Maze
    {
        Random ran = new Random();
        public List<Bitmap> progress = new List<Bitmap>();   //미로 이미지를 저장하기 위한 리스트
        Stack<Location2D> RecStack = new Stack<Location2D>(); //경로 저장을 위한 스택

        public void makeMaze()
        {
            progress.Clear();   //전에 만든 비트맵 리스트 제거
            GenMaze();          //미로 틀 생성
            MakePoint();        //랜덤좌표 설정
            GenRec();           //랜덤좌표에서 시작해서 미로 생성
        }
        
        //미로의 크기를 지정
        public void setSize(int width, int height, int size, bool check)
        {
            this.Size = size;
            Check = check;
            if (width % 2 == 1) { this.width = width; }  // 생성 알고리즘 상 가로세로는 홀수여야 한다.
            else { this.width = width + 1; }

            if (height % 2 == 1) { this.height = height; }
            else { this.height = height + 1; }
        }

        public void GenMaze()
        {
            //map 이차원 배열을 동적으로 할당
            map = new int[height, width];

            //일반 벽
            for (int i = 1; i < height - 1; i++)
            {
                int z = 1;
                z++;
                for (int j = 1; j < width - 1; j++)
                {
                    if (i % 2 == 0)
                    {
                        map[i, j] = 1;
                    }
                    else
                    {
                        map[i, j] = z % 2;
                        z++;
                    }
                }
            }

            //외곽 벽 -> 출력은 일반 벽과 같게하고 넘어갈 수는 없게
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = 0; j < width - 1; j++)
                {
                    map[0, 0] = 2;
                    map[i, 0] = 2;
                    map[0, j] = 2;
                    map[i, width - 1] = 2;
                    map[height - 1, j] = 2;
                    map[height - 1, width - 1] = 2;
                }
            }

            //입구 = 5, 출구 = 9
            while (true)
            {
                int ran1 = ran.Next(0, height - 1);
                int ran2 = ran.Next(0, height - 1);
                if (map[ran1, 1] == 0 && map[ran2, 1] == 0)
                {
                    map[ran1, 0] = 5;
                    map[ran2, width - 1] = 9;
                    break;
                }
            }
            //생성된 맵과 입구, 출구가 표시된 이미지를 만든다.
            progress.Add(bitImg(width, height, Size));
        }

        public void MakePoint()
        {
            //랜덤 포인트 지정
            while (true)
            {
                int ranW = ran.Next(0, width - 1);
                int ranH = ran.Next(0, height - 1);
                if (map[ranH, ranW] == 0)
                {
                    map[ranH, ranW] = 3;
                    Location2D ranPoint = new Location2D(ranH, ranW);
                    RecStack.Push(ranPoint);
                    progress.Add(bitImg(width, height, Size));
                    break;
                }
            }
        }

        //길인지 벽인지 확인
        public bool isValid(int r, int c)  //1칸 확인하고 문제없으면 2칸 뛴다.
        {
            if (r < 1 || c < 1 || c > width - 2 || r > height - 2 || map[r, c] == 2)  //범위를 벗어나면 갈 수 없다
                return false;
            else //비어있는 통로나 출발, 도착지점일 때만 true
                return true;
        }


        public bool isValidAll(int r, int c)   //전체 확인 후 stack pop을 할지 확인
        {
            if (!(isValid(r - 1, c) && map[r - 2, c] != 7 && map[r - 2, c] != 8) && !(isValid(r + 1, c) && map[r + 2, c] != 7 && map[r + 2, c] != 8) && !(isValid(r, c - 1) && map[r, c - 2] != 7 && map[r, c - 2] != 8) && !(isValid(r, c + 1) && map[r, c + 2] != 7 && map[r, c + 2] != 8))
            {
                return true;
            }
            else return false;
        }


        public void GenRec()    //recursive backtracking 방식으로 미로를 생성
        {
            try
            {
                while (RecStack.Count != 0)
                {
                    Location2D here = RecStack.Peek();
                    int r = here.row;
                    int c = here.col;
                    map[r, c] = 7;  //지나온 길

                    if (isValidAll(r, c))
                    {
                        Location2D here3 = RecStack.Pop();
                        int r3 = here.row;
                        int c3 = here.col;
                        map[r, c] = 7;

                        //미로가 너무 크거나 애니메이션 끄기에 체크되어있는 경우는 이미지를 만들지 않는다.
                        if (width < 55 && height < 55 && !Check)
                        {
                            progress.Add(bitImg(width, height, Size));
                        }
                    }


                    int ran1 = ran.Next(1, 5);  //길 생성 방향 랜덤

                    switch (ran1)
                    {
                        case 1: //위
                            if (isValid(r - 1, c) && map[r - 2, c] != 7 && map[r - 2, c] != 8)
                            {
                                map[r - 1, c] = 7;
                                RecStack.Push(new Location2D(r - 2, c));
                                
                                if (width < 55 && height < 55 && !Check)
                                {
                                    progress.Add(bitImg(width, height, Size));
                                }
                            }
                            break;

                        case 2: //아래
                            if (isValid(r + 1, c) && map[r + 2, c] != 7 && map[r + 2, c] != 8)
                            {
                                map[r + 1, c] = 7;
                                RecStack.Push(new Location2D(r + 2, c));
                                
                                if (width < 55 && height < 55 && !Check)
                                {
                                    progress.Add(bitImg(width, height, Size));
                                }
                            }
                            break;

                        case 3: //왼쪽
                            if (isValid(r, c - 1) && map[r, c - 2] != 7 && map[r, c - 2] != 8)
                            {
                                map[r, c - 1] = 7;
                                RecStack.Push(new Location2D(r, c - 2));
                                
                                if (width < 55 && height < 55 && !Check)
                                {
                                    progress.Add(bitImg(width, height, Size));
                                }
                            }
                            break;

                        case 4: //오른쪽
                            if (isValid(r, c + 1) && map[r, c + 2] != 7 && map[r, c + 2] != 8)
                            {
                                map[r, c + 1] = 7;
                                RecStack.Push(new Location2D(r, c + 2));
                                
                                if (width < 55 && height < 55 && !Check)
                                {
                                    progress.Add(bitImg(width, height, Size));
                                }
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error 02");
            }
        }


        public void GenEnd()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i, j] == 7 || map[i, j] == 5 || map[i, j] == 8)
                    {
                        map[i, j] = 0;
                    }
                    else if (map[i, j] == 9)
                    {
                        map[i, j] = 9;
                    }
                    else if (map[i, j] == 5)
                    {
                        map[i, j] = 5;
                    }
                    else
                    {
                        map[i, j] = 1;
                    }
                }
            }
            //완성된 미로를 리스트에 넣는다.
            progress.Add(bitImg(width, height, Size));
        }
    }
}
