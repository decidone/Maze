using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeWF
{
    class FileManager
    {
        public int width { get; set; }
        public int height { get; set; }

        public void save(int[,] map,int width, int height)  //여기에 가로세로 줘서 처리
        {
            // 생성 알고리즘 상 가로세로는 홀수여야 한다.
            if (width % 2 != 1) { width++; }
            if (height % 2 != 1) { height++; }

            string path = "Maze.txt";
            try
            {
                if (File.Exists(path))
                {
                    int length = height + 1;
                    string[] str = new string[length];
                    str[0] = width.ToString() + " " + height.ToString();
                    int z = 0;
                    for (int i = 0; i < height; i++)
                    {
                        z++;
                        for (int j = 0; j < width; j++)
                        {
                            if (map[i, j] == 7 || map[i, j] == 5 || map[i, j] == 8)
                            {
                                str[z] += "0 ";
                            }
                            else if (map[i, j] == 9)   //끝에 띄어쓰기 방지
                            {
                                str[z] += "0";
                            }
                            else if (map[i, j] == 2 && j == width - 1)   //끝에 띄어쓰기 방지
                            {
                                str[z] += "1";
                            }
                            else
                            {
                                str[z] += "1 ";
                            }
                        }
                    }
                    File.WriteAllLines(path, str);
                    MessageBox.Show(path + " 파일이 저장되었습니다.");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show(path + "경로에 파일을 생성했습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error 06");
            }
        }

        //파일에서 미로 파일을 읽어와서 맵을 만든다.
        public int[,] load(string fname)
        { 
            StreamReader objReader = new StreamReader(fname);
            string sLine = "";
            ArrayList arrTextLine = new ArrayList();
            ArrayList arrText = new ArrayList();

            while (sLine != null)
            {
                sLine = objReader.ReadLine();

                if (sLine != null)
                {
                    //불러온 텍스트 파일에서 띄어쓰기를 기준으로 구분해서 words에 넣는다.
                    string[] words = sLine.Split(' ');

                    for (int i = 0; i < words.Length; i++)
                    {
                        arrText.Add(words[i]);
                    }
                    arrTextLine.Add(sLine);
                }
            }
            objReader.Close();

            this.width = Convert.ToInt32(arrText[0]);
            this.height = Convert.ToInt32(arrText[1]);
            int[,] map = new int[height, width];


            int z = 2;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    map[i, j] = Convert.ToInt32(arrText[z]);
                    z++;
                }
            }
            return map;
        }

        public int getWidth()
        {
            return this.width;
        }
        public int getHeight()
        {
            return this.height;
        }
    }
}
