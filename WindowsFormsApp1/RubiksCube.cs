using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class RubiksCube : Display3D
    {
        private Point3D[] points = new Point3D[8];
        private int number;
        private int n;

        public void SetPoints(int n)
        {
            number = n;
            switch (n)
            {
                case 0:
                    points[0].x = -120; points[0].y = -120; points[0].z = -120;
                    points[1].x = -120; points[1].y = -40; points[1].z = -120;
                    points[2].x = -40; points[2].y = -40; points[2].z = -120;
                    points[3].x = -40; points[3].y = -120; points[3].z = -120;
                    points[4].x = -120; points[4].y = -120; points[4].z = -40;
                    points[5].x = -120; points[5].y = -40; points[5].z = -40;
                    points[6].x = -40; points[6].y = -40; points[6].z = -40;
                    points[7].x = -40; points[7].y = -120; points[7].z = -40;
                    break;
                case 1:
                    points[0].x = -120; points[0].y = -40; points[0].z = -120;
                    points[1].x = -120; points[1].y = 40; points[1].z = -120;
                    points[2].x = -40; points[2].y = 40; points[2].z = -120;
                    points[3].x = -40; points[3].y = -40; points[3].z = -120;
                    points[4].x = -120; points[4].y = -40; points[4].z = -40;
                    points[5].x = -120; points[5].y = 40; points[5].z = -40;
                    points[6].x = -40; points[6].y = 40; points[6].z = -40;
                    points[7].x = -40; points[7].y = -40; points[7].z = -40;
                    break;
                case 2:
                    points[0].x = -120; points[0].y = 40; points[0].z = -120;
                    points[1].x = -120; points[1].y = 120; points[1].z = -120;
                    points[2].x = -40; points[2].y = 120; points[2].z = -120;
                    points[3].x = -40; points[3].y = 40; points[3].z = -120;
                    points[4].x = -120; points[4].y = 40; points[4].z = -40;
                    points[5].x = -120; points[5].y = 120; points[5].z = -40;
                    points[6].x = -40; points[6].y = 120; points[6].z = -40;
                    points[7].x = -40; points[7].y = 40; points[7].z = -40;
                    break;
                case 3:
                    points[0].x = -40; points[0].y = -120; points[0].z = -120;
                    points[1].x = -40; points[1].y = -40; points[1].z = -120;
                    points[2].x = 40; points[2].y = -40; points[2].z = -120;
                    points[3].x = 40; points[3].y = -120; points[3].z = -120;
                    points[4].x = -40; points[4].y = -120; points[4].z = -40;
                    points[5].x = -40; points[5].y = -40; points[5].z = -40;
                    points[6].x = 40; points[6].y = -40; points[6].z = -40;
                    points[7].x = 40; points[7].y = -120; points[7].z = -40;
                    break;
                case 4:
                    points[0].x = -40; points[0].y = -40; points[0].z = -120;
                    points[1].x = -40; points[1].y = 40; points[1].z = -120;
                    points[2].x = 40; points[2].y = 40; points[2].z = -120;
                    points[3].x = 40; points[3].y = -40; points[3].z = -120;
                    points[4].x = -40; points[4].y = -40; points[4].z = -120;
                    points[5].x = -40; points[5].y = 40; points[5].z = -120;
                    points[6].x = 40; points[6].y = 40; points[6].z = -120;
                    points[7].x = 40; points[7].y = -40; points[7].z = -120;
                    break;
                case 5:
                    points[0].x = -40; points[0].y = 40; points[0].z = -120;
                    points[1].x = -40; points[1].y = 120; points[1].z = -120;
                    points[2].x = 40; points[2].y = 120; points[2].z = -120;
                    points[3].x = 40; points[3].y = 40; points[3].z = -120;
                    points[4].x = -40; points[4].y = 40; points[4].z = -40;
                    points[5].x = -40; points[5].y = 120; points[5].z = -40;
                    points[6].x = 40; points[6].y = 120; points[6].z = -40;
                    points[7].x = 40; points[7].y = 40; points[7].z = -40;
                    break;
                case 6:
                    points[0].x = 40; points[0].y = -120; points[0].z = -120;
                    points[1].x = 40; points[1].y = -40; points[1].z = -120;
                    points[2].x = 120; points[2].y = -40; points[2].z = -120;
                    points[3].x = 120; points[3].y = -120; points[3].z = -120;
                    points[4].x = 40; points[4].y = -120; points[4].z = -40;
                    points[5].x = 40; points[5].y = -40; points[5].z = -40;
                    points[6].x = 120; points[6].y = -40; points[6].z = -40;
                    points[7].x = 120; points[7].y = -120; points[7].z = -40;
                    break;
                case 7:
                    points[0].x = 40; points[0].y = -40; points[0].z = -120;
                    points[1].x = 40; points[1].y = 40; points[1].z = -120;
                    points[2].x = 120; points[2].y = 40; points[2].z = -120;
                    points[3].x = 120; points[3].y = -40; points[3].z = -120;
                    points[4].x = 40; points[4].y = -40; points[4].z = -40;
                    points[5].x = 40; points[5].y = 40; points[5].z = -40;
                    points[6].x = 120; points[6].y = 40; points[6].z = -40;
                    points[7].x = 120; points[7].y = -40; points[7].z = -40;
                    break;
                case 8:
                    points[0].x = 40; points[0].y = 40; points[0].z = -120;
                    points[1].x = 40; points[1].y = 120; points[1].z = -120;
                    points[2].x = 120; points[2].y = 120; points[2].z = -120;
                    points[3].x = 120; points[3].y = 40; points[3].z = -120;
                    points[4].x = 40; points[4].y = 40; points[4].z = -40;
                    points[5].x = 40; points[5].y = 120; points[5].z = -40;
                    points[6].x = 120; points[6].y = 120; points[6].z = -40;
                    points[7].x = 120; points[7].y = 40; points[7].z = -40;
                    break;
                case 9:
                    points[0].x = -120; points[0].y = -120; points[0].z = -40;
                    points[1].x = -120; points[1].y = -40; points[1].z = -40;
                    points[2].x = -40; points[2].y = -40; points[2].z = -40;
                    points[3].x = -40; points[3].y = -120; points[3].z = -40;
                    points[4].x = -120; points[4].y = -120; points[4].z = 40;
                    points[5].x = -120; points[5].y = -40; points[5].z = 40;
                    points[6].x = -40; points[6].y = -40; points[6].z = 40;
                    points[7].x = -40; points[7].y = -120; points[7].z = 40;
                    break;
                case 10:
                    points[0].x = -120; points[0].y = -40; points[0].z = -40;
                    points[1].x = -120; points[1].y = 40; points[1].z = -40;
                    points[2].x = -40; points[2].y = 40; points[2].z = -40;
                    points[3].x = -40; points[3].y = -40; points[3].z = -40;
                    points[4].x = -120; points[4].y = -40; points[4].z = 40;
                    points[5].x = -120; points[5].y = 40; points[5].z = 40;
                    points[6].x = -40; points[6].y = 40; points[6].z = 40;
                    points[7].x = -40; points[7].y = -40; points[7].z = 40;
                    break;
                case 11:
                    points[0].x = -120; points[0].y = 40; points[0].z = -40;
                    points[1].x = -120; points[1].y = 120; points[1].z = -40;
                    points[2].x = -40; points[2].y = 120; points[2].z = -40;
                    points[3].x = -40; points[3].y = 40; points[3].z = -40;
                    points[4].x = -120; points[4].y = 40; points[4].z = 40;
                    points[5].x = -120; points[5].y = 120; points[5].z = 40;
                    points[6].x = -40; points[6].y = 120; points[6].z = 40;
                    points[7].x = -40; points[7].y = 40; points[7].z = 40;
                    break;
                case 12:
                    points[0].x = -40; points[0].y = -120; points[0].z = -40;
                    points[1].x = -40; points[1].y = -40; points[1].z = -40;
                    points[2].x = 40; points[2].y = -40; points[2].z = -40;
                    points[3].x = 40; points[3].y = -120; points[3].z = -40;
                    points[4].x = -40; points[4].y = -120; points[4].z = 40;
                    points[5].x = -40; points[5].y = -40; points[5].z = 40;
                    points[6].x = 40; points[6].y = -40; points[6].z = 40;
                    points[7].x = 40; points[7].y = -120; points[7].z = 40;
                    break;
                case 13:
                    points[0].x = -40; points[0].y = 40; points[0].z = -40;
                    points[1].x = -40; points[1].y = 120; points[1].z = -40;
                    points[2].x = 40; points[2].y = 120; points[2].z = -40;
                    points[3].x = 40; points[3].y = 40; points[3].z = -40;
                    points[4].x = -40; points[4].y = 40; points[4].z = 40;
                    points[5].x = -40; points[5].y = 120; points[5].z = 40;
                    points[6].x = 40; points[6].y = 120; points[6].z = 40;
                    points[7].x = 40; points[7].y = 40; points[7].z = 40;
                    break;
                case 14:
                    points[0].x = 40; points[0].y = -120; points[0].z = -40;
                    points[1].x = 40; points[1].y = -40; points[1].z = -40;
                    points[2].x = 120; points[2].y = -40; points[2].z = -40;
                    points[3].x = 120; points[3].y = -120; points[3].z = -40;
                    points[4].x = 40; points[4].y = -120; points[4].z = 40;
                    points[5].x = 40; points[5].y = -40; points[5].z = 40;
                    points[6].x = 120; points[6].y = -40; points[6].z = 40;
                    points[7].x = 120; points[7].y = -120; points[7].z = 40;
                    break;
                case 15:
                    points[0].x = 40; points[0].y = -40; points[0].z = -40;
                    points[1].x = 40; points[1].y = 40; points[1].z = -40;
                    points[2].x = 120; points[2].y = 40; points[2].z = -40;
                    points[3].x = 120; points[3].y = -40; points[3].z = -40;
                    points[4].x = 40; points[4].y = -40; points[4].z = 40;
                    points[5].x = 40; points[5].y = 40; points[5].z = 40;
                    points[6].x = 120; points[6].y = 40; points[6].z = 40;
                    points[7].x = 120; points[7].y = -40; points[7].z = 40;
                    break;
                case 16:
                    points[0].x = 40; points[0].y = 40; points[0].z = -40;
                    points[1].x = 40; points[1].y = 120; points[1].z = -40;
                    points[2].x = 120; points[2].y = 120; points[2].z = -40;
                    points[3].x = 120; points[3].y = 40; points[3].z = -40;
                    points[4].x = 40; points[4].y = 40; points[4].z = 40;
                    points[5].x = 40; points[5].y = 120; points[5].z = 40;
                    points[6].x = 120; points[6].y = 120; points[6].z = 40;
                    points[7].x = 120; points[7].y = 40; points[7].z = 40;
                    break;
                case 17:
                    points[0].x = -120; points[0].y = -120; points[0].z = 40;
                    points[1].x = -120; points[1].y = -40; points[1].z = 40;
                    points[2].x = -40; points[2].y = -40; points[2].z = 40;
                    points[3].x = -40; points[3].y = -120; points[3].z = 40;
                    points[4].x = -120; points[4].y = -120; points[4].z = 120;
                    points[5].x = -120; points[5].y = -40; points[5].z = 120;
                    points[6].x = -40; points[6].y = -40; points[6].z = 120;
                    points[7].x = -40; points[7].y = -120; points[7].z = 120;
                    break;
                case 18:
                    points[0].x = -120; points[0].y = -40; points[0].z = 40;
                    points[1].x = -120; points[1].y = 40; points[1].z = 40;
                    points[2].x = -40; points[2].y = 40; points[2].z = 40;
                    points[3].x = -40; points[3].y = -40; points[3].z = 40;
                    points[4].x = -120; points[4].y = -40; points[4].z = 120;
                    points[5].x = -120; points[5].y = 40; points[5].z = 120;
                    points[6].x = -40; points[6].y = 40; points[6].z = 120;
                    points[7].x = -40; points[7].y = -40; points[7].z = 120;
                    break;
                case 19:
                    points[0].x = -120; points[0].y = 40; points[0].z = 40;
                    points[1].x = -120; points[1].y = 120; points[1].z = 40;
                    points[2].x = -40; points[2].y = 120; points[2].z = 40;
                    points[3].x = -40; points[3].y = 40; points[3].z = 40;
                    points[4].x = -120; points[4].y = 40; points[4].z = 120;
                    points[5].x = -120; points[5].y = 120; points[5].z = 120;
                    points[6].x = -40; points[6].y = 120; points[6].z = 120;
                    points[7].x = -40; points[7].y = 40; points[7].z = 120;
                    break;
                case 20:
                    points[0].x = -40; points[0].y = -120; points[0].z = 40;
                    points[1].x = -40; points[1].y = -40; points[1].z = 40;
                    points[2].x = 40; points[2].y = -40; points[2].z = 40;
                    points[3].x = 40; points[3].y = -120; points[3].z = 40;
                    points[4].x = -40; points[4].y = -120; points[4].z = 120;
                    points[5].x = -40; points[5].y = -40; points[5].z = 120;
                    points[6].x = 40; points[6].y = -40; points[6].z = 120;
                    points[7].x = 40; points[7].y = -120; points[7].z = 120;
                    break;
                case 21:
                    points[0].x = -40; points[0].y = -40; points[0].z = 40;
                    points[1].x = -40; points[1].y = 40; points[1].z = 40;
                    points[2].x = 40; points[2].y = 40; points[2].z = 40;
                    points[3].x = 40; points[3].y = -40; points[3].z = 40;
                    points[4].x = -40; points[4].y = -40; points[4].z = 120;
                    points[5].x = -40; points[5].y = 40; points[5].z = 120;
                    points[6].x = 40; points[6].y = 40; points[6].z = 120;
                    points[7].x = 40; points[7].y = -40; points[7].z = 120;
                    break;
                case 22:
                    points[0].x = -40; points[0].y = 40; points[0].z = 40;
                    points[1].x = -40; points[1].y = 120; points[1].z = 40;
                    points[2].x = 40; points[2].y = 120; points[2].z = 40;
                    points[3].x = 40; points[3].y = 40; points[3].z = 40;
                    points[4].x = -40; points[4].y = 40; points[4].z = 120;
                    points[5].x = -40; points[5].y = 120; points[5].z = 120;
                    points[6].x = 40; points[6].y = 120; points[6].z = 120;
                    points[7].x = 40; points[7].y = 40; points[7].z = 120;
                    break;
                case 23:
                    points[0].x = 40; points[0].y = -120; points[0].z = 40;
                    points[1].x = 40; points[1].y = -40; points[1].z = 40;
                    points[2].x = 120; points[2].y = -40; points[2].z = 40;
                    points[3].x = 120; points[3].y = -120; points[3].z = 40;
                    points[4].x = 40; points[4].y = -120; points[4].z = 120;
                    points[5].x = 40; points[5].y = -40; points[5].z = 120;
                    points[6].x = 120; points[6].y = -40; points[6].z = 120;
                    points[7].x = 120; points[7].y = -120; points[7].z = 120;
                    break;
                case 24:
                    points[0].x = 40; points[0].y = -40; points[0].z = 40;
                    points[1].x = 40; points[1].y = 40; points[1].z = 40;
                    points[2].x = 120; points[2].y = 40; points[2].z = 40;
                    points[3].x = 120; points[3].y = -40; points[3].z = 40;
                    points[4].x = 40; points[4].y = -40; points[4].z = 120;
                    points[5].x = 40; points[5].y = 40; points[5].z = 120;
                    points[6].x = 120; points[6].y = 40; points[6].z = 120;
                    points[7].x = 120; points[7].y = -40; points[7].z = 120;
                    break;
                case 25:
                    points[0].x = 40; points[0].y = 40; points[0].z = 40;
                    points[1].x = 40; points[1].y = 120; points[1].z = 40;
                    points[2].x = 120; points[2].y = 120; points[2].z = 40;
                    points[3].x = 120; points[3].y = 40; points[3].z = 40;
                    points[4].x = 40; points[4].y = 40; points[4].z = 120;
                    points[5].x = 40; points[5].y = 120; points[5].z = 120;
                    points[6].x = 120; points[6].y = 120; points[6].z = 120;
                    points[7].x = 120; points[7].y = 40; points[7].z = 120;
                    break;
            }
        }

        public Point3D[] GetPoints()
        {
            return points;
        }

        public int GetNumber()
        {
            if (number > 12)
            {
                n = number + 1;
            }
            else
            {
                n = number;
            }
            return n;
        }
    }
}
