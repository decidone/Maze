using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeWF
{
    public class Maze
    {
        public int width { get; set; }
        public int height { get; set; }
        public int[,] map { get; set; }
        public int Size { get; set; }
        public bool Check { get; set; }

        //map배열을 이미지로
        public Bitmap bitImg(int width, int height, int size)
        {
            Bitmap b = new Bitmap(width * size + size, height * size + size);

            SolidBrush white = new SolidBrush(Color.White);
            SolidBrush black = new SolidBrush(Color.Black);
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush green = new SolidBrush(Color.Green);
            SolidBrush blue = new SolidBrush(Color.Blue);
            SolidBrush pink = new SolidBrush(Color.Pink);
            SolidBrush purple = new SolidBrush(Color.Purple);
            SolidBrush yellowgreen = new SolidBrush(Color.YellowGreen);
            
            // 생성 알고리즘 상 가로세로는 홀수여야 한다.
            if (width % 2 != 1) { width++; }
            if (height % 2 != 1) { height++; }

            using (Graphics g = Graphics.FromImage(b))
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (map[i, j] == 0)
                        {
                            g.FillRectangle(white, new Rectangle(j * size, i * size, size, size));
                        }
                        if (map[i, j] == 1)
                        {
                            g.FillRectangle(black, new Rectangle(j * size, i * size, size, size));
                        }
                        if (map[i, j] == 2)
                        {
                            g.FillRectangle(black, new Rectangle(j * size, i * size, size, size));
                        }
                        if (map[i, j] == 3)
                        {
                            g.FillRectangle(blue, new Rectangle(j * size, i * size, size, size));
                        }
                        if (map[i, j] == 5)
                        {
                            g.FillRectangle(green, new Rectangle(j * size, i * size, size, size));
                        }
                        if (map[i, j] == 7)
                        {
                            g.FillRectangle(pink, new Rectangle(j * size, i * size, size, size));
                        }
                        if (map[i, j] == 8)
                        {
                            g.FillRectangle(yellowgreen, new Rectangle(j * size, i * size, size, size));
                        }
                        if (map[i, j] == 9)
                        {
                            g.FillRectangle(red, new Rectangle(j * size, i * size, size, size));
                        }
                    }
                }
            }
            return b;
        }
    }
}
