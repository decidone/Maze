using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeWF
{
    public partial class MazeF : Form
    {
        public int width { get; set; }
        public int height { get; set; }
        public int rectangleSize { get; set; }
        public int interval { get; set; }
        public bool check { get; set; }

        MazeGen gen = new MazeGen();
        FileManager mgr = new FileManager();
        MazeSol sol = new MazeSol();
        MazeSolBfs bfs = new MazeSolBfs();

        public MazeF()
        {
            InitializeComponent();
            rectangleSize = 10;
            this.DoubleBuffered = true;
        }

        // 미로 생성 버튼
        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                setOption();
                gen.setSize(width, height, rectangleSize, check);
                gen.makeMaze();

                mgr.save(gen.map,width, height);
                gen.GenEnd();

                new Thread(delegate ()  //리스트에 저장해 놓은 이미지로 애니메이션 구현
                {
                    for (int i = 0; i < gen.progress.Count(); i++)
                    {
                        pictureBox1.Image = gen.progress[i];
                        if (!check)
                        {
                            Thread.Sleep(interval);
                        }
                    }
                }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error 03");
            }
        }

        //미로찾기 실행 버튼 -> 파일 로드 후 미로찾기 실행
        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                setOption();
                sol.loadMap();
                sol.searchExit(rectangleSize, check);

                //가로 혹은 세로가 55를 넘어갈경우 결과출력을 위한 메서드
                sol.solPro.Add(sol.bitImg(sol.width, sol.height, rectangleSize));

                new Thread(delegate ()  //리스트에 저장해 놓은 이미지로 애니메이션 구현
                {
                    for (int i = 0; i < sol.solPro.Count(); i++)
                    {
                        pictureBox1.Image = sol.solPro[i];
                        if (!check)
                        {
                            Thread.Sleep(interval);
                        }
                    }
                }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error 04");
            }
        }

        //종료 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setOption()    //입력한 값 받아오고 이미지박스 초기화
        {
            rectangleSize = Convert.ToInt32(recSizeText.Text);
            interval = Convert.ToInt32(intervalText.Text);
            width = Convert.ToInt32(widthBox.Text);
            height = Convert.ToInt32(heightBox.Text);
            check = checkBox1.Checked;

            if (interval >= 150)
            {
                interval = 150;
            }
            pictureBox1.Refresh();
        }

        //너비우선 탐색
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                setOption();
                bfs.loadMap();
                bfs.searchExit(rectangleSize, check);

                //가로 혹은 세로가 55를 넘어갈경우 결과출력을 위한 메서드
                bfs.solPro.Add(bfs.bitImg(bfs.width, bfs.height, rectangleSize));

                new Thread(delegate ()  //리스트에 저장해 놓은 이미지로 애니메이션 구현
                {
                    for (int i = 0; i < bfs.solPro.Count(); i++)
                    {
                        pictureBox1.Image = bfs.solPro[i];
                        if (!check)
                        {
                            Thread.Sleep(interval);
                        }
                    }
                }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error 04");
            }
        }
    }
}