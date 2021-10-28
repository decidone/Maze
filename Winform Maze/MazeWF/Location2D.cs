using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeWF
{
    public class Location2D
    {
        public int row; // 현재 위치의 행 번호
        public int col; // 현재 위치의 열 번호

        public Location2D(int r = 0, int c = 0) {
            row = r;
            col = c;
        }
    }
}
