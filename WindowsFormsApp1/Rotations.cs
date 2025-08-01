using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class Rotations
    {

        public static void SaveCubeToFile(char[,,] c, string filename)
        {
            using (StreamWriter stream = new StreamWriter(filename))  // opens text file and disposes after it has been used as it is in using a using statement
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            stream.WriteLine(c[i, x, y]);  // writes each cube face colour to text file
                        }
                    }
                }
                stream.Close();
            }
        }
        public static char[,,] L(int Turns, char[,,] CubeFaces)
        {
            char placeholder1;
            char placeholder2;
            char placeholder3;
            for (int i = 0; i < Turns; i++)
            {
                placeholder1 = CubeFaces[0, 0, 0];
                placeholder2 = CubeFaces[0, 0, 1];
                placeholder3 = CubeFaces[0, 0, 2];

                CubeFaces[0, 0, 0] = CubeFaces[1, 0, 0];
                CubeFaces[0, 0, 1] = CubeFaces[1, 0, 1];
                CubeFaces[0, 0, 2] = CubeFaces[1, 0, 2];

                CubeFaces[1, 0, 0] = CubeFaces[5, 2, 2];
                CubeFaces[1, 0, 1] = CubeFaces[5, 2, 1];
                CubeFaces[1, 0, 2] = CubeFaces[5, 2, 0];

                CubeFaces[5, 2, 0] = CubeFaces[3, 0, 2];
                CubeFaces[5, 2, 1] = CubeFaces[3, 0, 1];
                CubeFaces[5, 2, 2] = CubeFaces[3, 0, 0];

                CubeFaces[3, 0, 0] = placeholder1;
                CubeFaces[3, 0, 1] = placeholder2;
                CubeFaces[3, 0, 2] = placeholder3;

                placeholder1 = CubeFaces[4, 0, 2];
                placeholder2 = CubeFaces[4, 0, 1];

                CubeFaces[4, 0, 1] = CubeFaces[4, 1, 2];
                CubeFaces[4, 0, 2] = CubeFaces[4, 2, 2];
                CubeFaces[4, 1, 2] = CubeFaces[4, 2, 1];

                CubeFaces[4, 2, 2] = CubeFaces[4, 2, 0];
                CubeFaces[4, 2, 1] = CubeFaces[4, 1, 0];
                CubeFaces[4, 2, 0] = CubeFaces[4, 0, 0];

                CubeFaces[4, 1, 0] = placeholder2;
                CubeFaces[4, 0, 0] = placeholder1;
            }
            return CubeFaces;

        }

        public static char[,,] R(int Turns, char[,,] CubeFaces)
        {
            char placeholder1;
            char placeholder2;
            char placeholder3;
            for (int i = 0; i < Turns; i++)
            {
                placeholder1 = CubeFaces[3, 2, 0];
                placeholder2 = CubeFaces[3, 2, 1];
                placeholder3 = CubeFaces[3, 2, 2];

                CubeFaces[3, 2, 0] = CubeFaces[5, 0, 2];
                CubeFaces[3, 2, 1] = CubeFaces[5, 0, 1];
                CubeFaces[3, 2, 2] = CubeFaces[5, 0, 0];

                CubeFaces[5, 0, 0] = CubeFaces[1, 2, 2];
                CubeFaces[5, 0, 1] = CubeFaces[1, 2, 1];
                CubeFaces[5, 0, 2] = CubeFaces[1, 2, 0];

                CubeFaces[1, 2, 0] = CubeFaces[0, 2, 0];
                CubeFaces[1, 2, 1] = CubeFaces[0, 2, 1];
                CubeFaces[1, 2, 2] = CubeFaces[0, 2, 2];

                CubeFaces[0, 2, 0] = placeholder1;
                CubeFaces[0, 2, 1] = placeholder2;
                CubeFaces[0, 2, 2] = placeholder3;

                placeholder1 = CubeFaces[2, 0, 2];
                placeholder2 = CubeFaces[2, 0, 1];

                CubeFaces[2, 0, 1] = CubeFaces[2, 1, 2];
                CubeFaces[2, 0, 2] = CubeFaces[2, 2, 2];
                CubeFaces[2, 1, 2] = CubeFaces[2, 2, 1];

                CubeFaces[2, 2, 2] = CubeFaces[2, 2, 0];
                CubeFaces[2, 2, 1] = CubeFaces[2, 1, 0];
                CubeFaces[2, 2, 0] = CubeFaces[2, 0, 0];

                CubeFaces[2, 1, 0] = placeholder2;
                CubeFaces[2, 0, 0] = placeholder1;
            }
            return CubeFaces;
        }
        public static char[,,] U(int Turns, char[,,] CubeFaces)
        {
            char placeholder1;
            char placeholder2;
            char placeholder3;
            for (int i = 0; i < Turns; i++)
            {
                placeholder1 = CubeFaces[0, 0, 0];
                placeholder2 = CubeFaces[0, 1, 0];
                placeholder3 = CubeFaces[0, 2, 0];

                CubeFaces[0, 0, 0] = CubeFaces[2, 0, 0];
                CubeFaces[0, 1, 0] = CubeFaces[2, 1, 0];
                CubeFaces[0, 2, 0] = CubeFaces[2, 2, 0];

                CubeFaces[2, 0, 0] = CubeFaces[5, 0, 0];
                CubeFaces[2, 1, 0] = CubeFaces[5, 1, 0];
                CubeFaces[2, 2, 0] = CubeFaces[5, 2, 0];

                CubeFaces[5, 0, 0] = CubeFaces[4, 0, 0];
                CubeFaces[5, 1, 0] = CubeFaces[4, 1, 0];
                CubeFaces[5, 2, 0] = CubeFaces[4, 2, 0];

                CubeFaces[4, 0, 0] = placeholder1;
                CubeFaces[4, 1, 0] = placeholder2;
                CubeFaces[4, 2, 0] = placeholder3;

                placeholder1 = CubeFaces[1, 0, 2];
                placeholder2 = CubeFaces[1, 0, 1];

                CubeFaces[1, 0, 1] = CubeFaces[1, 1, 2];
                CubeFaces[1, 0, 2] = CubeFaces[1, 2, 2];
                CubeFaces[1, 1, 2] = CubeFaces[1, 2, 1];

                CubeFaces[1, 2, 2] = CubeFaces[1, 2, 0];
                CubeFaces[1, 2, 1] = CubeFaces[1, 1, 0];
                CubeFaces[1, 2, 0] = CubeFaces[1, 0, 0];

                CubeFaces[1, 1, 0] = placeholder2;
                CubeFaces[1, 0, 0] = placeholder1;
            }
            return CubeFaces;
        }

        public static char[,,] D(int Turns, char[,,] CubeFaces)
        {
            char placeholder1;
            char placeholder2;
            char placeholder3;
            for (int i = 0; i < Turns; i++)
            {
                placeholder1 = CubeFaces[0, 0, 2];
                placeholder2 = CubeFaces[0, 1, 2];
                placeholder3 = CubeFaces[0, 2, 2];

                CubeFaces[0, 0, 2] = CubeFaces[4, 0, 2];
                CubeFaces[0, 1, 2] = CubeFaces[4, 1, 2];
                CubeFaces[0, 2, 2] = CubeFaces[4, 2, 2];

                CubeFaces[4, 0, 2] = CubeFaces[5, 0, 2];
                CubeFaces[4, 1, 2] = CubeFaces[5, 1, 2];
                CubeFaces[4, 2, 2] = CubeFaces[5, 2, 2];

                CubeFaces[5, 0, 2] = CubeFaces[2, 0, 2];
                CubeFaces[5, 1, 2] = CubeFaces[2, 1, 2];
                CubeFaces[5, 2, 2] = CubeFaces[2, 2, 2];

                CubeFaces[2, 0, 2] = placeholder1;
                CubeFaces[2, 1, 2] = placeholder2;
                CubeFaces[2, 2, 2] = placeholder3;

                placeholder1 = CubeFaces[3, 0, 2];
                placeholder2 = CubeFaces[3, 0, 1];

                CubeFaces[3, 0, 1] = CubeFaces[3, 1, 2];
                CubeFaces[3, 0, 2] = CubeFaces[3, 2, 2];
                CubeFaces[3, 1, 2] = CubeFaces[3, 2, 1];

                CubeFaces[3, 2, 2] = CubeFaces[3, 2, 0];
                CubeFaces[3, 2, 1] = CubeFaces[3, 1, 0];
                CubeFaces[3, 2, 0] = CubeFaces[3, 0, 0];

                CubeFaces[3, 1, 0] = placeholder2;
                CubeFaces[3, 0, 0] = placeholder1;
            }
            return CubeFaces;
        }

        public static char[,,] B(int Turns, char[,,] CubeFaces)
        {
            char placeholder1;
            char placeholder2;
            char placeholder3;
            for (int i = 0; i < Turns; i++)
            {
                placeholder1 = CubeFaces[1, 2, 0];
                placeholder2 = CubeFaces[1, 1, 0];
                placeholder3 = CubeFaces[1, 0, 0];

                CubeFaces[1, 2, 0] = CubeFaces[2, 2, 2];
                CubeFaces[1, 1, 0] = CubeFaces[2, 2, 1];
                CubeFaces[1, 0, 0] = CubeFaces[2, 2, 0];

                CubeFaces[2, 2, 0] = CubeFaces[3, 2, 2];
                CubeFaces[2, 2, 1] = CubeFaces[3, 1, 2];
                CubeFaces[2, 2, 2] = CubeFaces[3, 0, 2];

                CubeFaces[3, 2, 2] = CubeFaces[4, 0, 2];
                CubeFaces[3, 1, 2] = CubeFaces[4, 0, 1];
                CubeFaces[3, 0, 2] = CubeFaces[4, 0, 0];

                CubeFaces[4, 0, 0] = placeholder1;
                CubeFaces[4, 0, 1] = placeholder2;
                CubeFaces[4, 0, 2] = placeholder3;

                placeholder1 = CubeFaces[5, 0, 2];
                placeholder2 = CubeFaces[5, 0, 1];

                CubeFaces[5, 0, 1] = CubeFaces[5, 1, 2];
                CubeFaces[5, 0, 2] = CubeFaces[5, 2, 2];
                CubeFaces[5, 1, 2] = CubeFaces[5, 2, 1];

                CubeFaces[5, 2, 2] = CubeFaces[5, 2, 0];
                CubeFaces[5, 2, 1] = CubeFaces[5, 1, 0];
                CubeFaces[5, 2, 0] = CubeFaces[5, 0, 0];

                CubeFaces[5, 1, 0] = placeholder2;
                CubeFaces[5, 0, 0] = placeholder1;
            }
            return CubeFaces;
        }
        public static char[,,] F(int Turns, char[,,] CubeFaces)
        {
            char placeholder1;
            char placeholder2;
            char placeholder3;
            for (int i = 0; i < Turns; i++)
            {
                placeholder1 = CubeFaces[3, 0, 0];
                placeholder2 = CubeFaces[3, 1, 0];
                placeholder3 = CubeFaces[3, 2, 0];

                CubeFaces[3, 0, 0] = CubeFaces[2, 0, 2];
                CubeFaces[3, 1, 0] = CubeFaces[2, 0, 1];
                CubeFaces[3, 2, 0] = CubeFaces[2, 0, 0];

                CubeFaces[2, 0, 0] = CubeFaces[1, 0, 2];
                CubeFaces[2, 0, 1] = CubeFaces[1, 1, 2];
                CubeFaces[2, 0, 2] = CubeFaces[1, 2, 2];

                CubeFaces[1, 0, 2] = CubeFaces[4, 2, 2];
                CubeFaces[1, 1, 2] = CubeFaces[4, 2, 1];
                CubeFaces[1, 2, 2] = CubeFaces[4, 2, 0];

                CubeFaces[4, 2, 0] = placeholder1;
                CubeFaces[4, 2, 1] = placeholder2;
                CubeFaces[4, 2, 2] = placeholder3;

                placeholder1 = CubeFaces[0, 0, 2];
                placeholder2 = CubeFaces[0, 0, 1];

                CubeFaces[0, 0, 1] = CubeFaces[0, 1, 2];
                CubeFaces[0, 0, 2] = CubeFaces[0, 2, 2];
                CubeFaces[0, 1, 2] = CubeFaces[0, 2, 1];

                CubeFaces[0, 2, 2] = CubeFaces[0, 2, 0];
                CubeFaces[0, 2, 1] = CubeFaces[0, 1, 0];
                CubeFaces[0, 2, 0] = CubeFaces[0, 0, 0];

                CubeFaces[0, 1, 0] = placeholder2;
                CubeFaces[0, 0, 0] = placeholder1;
            }
            return CubeFaces;
        }


    }
}
