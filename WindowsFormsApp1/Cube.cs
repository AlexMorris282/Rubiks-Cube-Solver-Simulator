using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Cube
    {

        private char[,,] CubeFaces = new char[6, 3, 3]
        {
            { { 'w', 'w', 'w' }, { 'w', 'w', 'w' }, { 'w', 'w', 'w' } },  // white side
            { { 'r', 'r', 'r' }, { 'r', 'r', 'r' }, { 'r', 'r', 'r' } },  // red side
            { { 'g', 'g', 'g' }, { 'g', 'g', 'g' }, { 'g', 'g', 'g' } },  // green side
            { { 'o', 'o', 'o' }, { 'o', 'o', 'o' }, { 'o', 'o', 'o' } },  // orange side
            { { 'b', 'b', 'b' }, { 'b', 'b', 'b' }, { 'b', 'b', 'b' } },  // blue side
            { { 'y', 'y', 'y' }, { 'y', 'y', 'y' }, { 'y', 'y', 'y' } }   // yellow side
        };

        public char[,,] GetCubeFaces()
        {
            return CubeFaces;
        }

        public struct ThreeSidedCorner
        {
            public char SideOne;
            public char SideTwo;
            public char SideThree;
            public string Location;
        }
        public struct TwoSidedCorner
        {
            public char Side1;
            public char Side2;
            public string Location;
        }

        TwoSidedCorner[] MiddleCorners = new TwoSidedCorner[12];

        ThreeSidedCorner[] Corners = new ThreeSidedCorner[8];

        public void ChangeSide(int side, int x, int y, char Colour)
        {
            CubeFaces[side -  1, x, y] = Colour;
        }

        public bool SolvableStep1()
        {
            int red = 0, white = 0, yellow = 0, blue = 0, green = 0, orange = 0;

            for(int i = 0; i < 6; i++)
            {
                for(int y = 0; y < 3; y++)
                {
                    for(int z = 0; z < 3; z++)
                    {
                        switch (CubeFaces[i, z, y])
                        {
                            case 'w':
                                white++;
                                break;
                            case 'r':
                                red++;
                                break;
                            case 'o':
                                orange++;
                                break;
                            case 'g':
                                green++;
                                break;
                            case 'y':
                                yellow++;
                                break;
                            case 'b':
                                blue++;
                                break;
                        }
                    }
                }
            }
            if(white == 9 && red == 9 && green == 9 && blue == 9 && orange == 9 && yellow == 9)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool SolvableStep2()
        {
            Corners = GetCorners();

            MiddleCorners = GetMiddleCorners();

            bool OppositeFaces;
            ThreeSidedCorner CurrentCorner;
            for (int i = 0; i < 8; i++)     //checks there are no corner pieces with multiple of the same colour
            {                               // if there is, returns false(unsolvable)
                if ((Corners[i].SideOne == Corners[i].SideTwo) ||
                    (Corners[i].SideOne == Corners[i].SideThree) ||
                    (Corners[i].SideTwo == Corners[i].SideThree))
                {
                    Console.WriteLine("Same colours 3 sideed corner");
                    return false;
                }

                OppositeFaces = GetOppositeFaces(i, "3SideCorner", Corners, MiddleCorners);

                if (!OppositeFaces)
                {
                    Console.WriteLine("Opposite faces 3 sideed corner");
                    return false;
                }
                CurrentCorner.SideOne = Corners[i].SideOne; CurrentCorner.SideTwo = Corners[i].SideTwo; CurrentCorner.SideThree = Corners[i].SideThree; CurrentCorner.Location = Corners[i].Location;
                for (int q = 0; q < 8; q++)
                {
                    if (q == i)
                    {
                        q++;
                    }
                    else if (MultipleSameCorners(CurrentCorner, q))
                    {
                        Console.WriteLine("Multiple Same Corners");

                        return false;
                    }
                }


            }
            TwoSidedCorner CurrentSide;
            for (int i = 0; i < 12; i++)
            {
                if (MiddleCorners[i].Side1 == MiddleCorners[i].Side2)    // checks no middle corners have 2 of the same colour
                {
                    Console.WriteLine("Same Colour");
                    return false;
                }

                OppositeFaces = GetOppositeFaces(i, "MiddleCorner", Corners, MiddleCorners);

                if (!OppositeFaces)
                {
                    Console.WriteLine("Opposite Faces");
                    return false;
                }

                CurrentSide.Side1 = MiddleCorners[i].Side1; CurrentSide.Side2 = MiddleCorners[i].Side2; CurrentSide.Location = MiddleCorners[i].Location;

                for (int q = 0; q < 12; q++)
                {
                    if (q == i)
                    {
                        q++;
                    }
                    else if (MultipleSameSide(CurrentSide, q))
                    {
                        Console.WriteLine("Multiple Same Corners");

                        return false;
                    }
                }


            }                       //if no if statements aboive are met as true then SolvableStep2 becomes true meaning
                                    //it is solvable with the current criteria
            return true;
        }

        private bool MultipleSameSide(TwoSidedCorner CurrentSide, int i)
        {
            string sides = char.ToString(CurrentSide.Side1) + char.ToString(CurrentSide.Side2);

            bool side1 = sides.Contains(MiddleCorners[i].Side1);
            bool side2 = sides.Contains(MiddleCorners[i].Side2);
            if (side1)
            {
                if (side2)
                {
                    return true;
                }
            }

            return false;

        }
        private bool MultipleSameCorners(ThreeSidedCorner CurrentCorner, int i)
        {
            string sides = char.ToString(CurrentCorner.SideOne)
                + char.ToString(CurrentCorner.SideTwo)
                + char.ToString(CurrentCorner.SideThree);

            bool side1 = sides.Contains(Corners[i].SideOne);
            bool side2 = sides.Contains(Corners[i].SideTwo);
            bool side3 = sides.Contains(Corners[i].SideThree);
            if (side1)
            {
                if (side2)
                {
                    if (side3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected TwoSidedCorner[] GetMiddleCorners()
        {
            MiddleCorners[0].Side1 = CubeFaces[0, 1, 0]; MiddleCorners[0].Side2 = CubeFaces[1, 1, 2]; MiddleCorners[0].Location = "0,1,0,1,1,2";       // defines all middle corner positions
            MiddleCorners[1].Side1 = CubeFaces[0, 0, 1]; MiddleCorners[1].Side2 = CubeFaces[4, 2, 1]; MiddleCorners[1].Location = "0,0,1,4,2,1";
            MiddleCorners[2].Side1 = CubeFaces[0, 1, 2]; MiddleCorners[2].Side2 = CubeFaces[3, 1, 0]; MiddleCorners[2].Location = "0,1,2,3,1,0";
            MiddleCorners[3].Side1 = CubeFaces[0, 2, 1]; MiddleCorners[3].Side2 = CubeFaces[2, 0, 1]; MiddleCorners[3].Location = "0,2,1,2,0,1";
            MiddleCorners[4].Side1 = CubeFaces[5, 1, 0]; MiddleCorners[4].Side2 = CubeFaces[1, 1, 0]; MiddleCorners[4].Location = "5,1,0,1,1,0";
            MiddleCorners[5].Side1 = CubeFaces[5, 0, 1]; MiddleCorners[5].Side2 = CubeFaces[2, 2, 1]; MiddleCorners[5].Location = "5,0,1,2,2,1";
            MiddleCorners[6].Side1 = CubeFaces[5, 1, 2]; MiddleCorners[6].Side2 = CubeFaces[3, 1, 2]; MiddleCorners[6].Location = "5,1,2,3,1,2";
            MiddleCorners[7].Side1 = CubeFaces[5, 2, 1]; MiddleCorners[7].Side2 = CubeFaces[4, 0, 1]; MiddleCorners[7].Location = "5,2,1,4,0,1";
            MiddleCorners[8].Side1 = CubeFaces[4, 1, 2]; MiddleCorners[8].Side2 = CubeFaces[3, 0, 1]; MiddleCorners[8].Location = "4,1,2,3,0,1";
            MiddleCorners[9].Side1 = CubeFaces[3, 2, 1]; MiddleCorners[9].Side2 = CubeFaces[2, 1, 2]; MiddleCorners[9].Location = "2,1,2,3,2,1";
            MiddleCorners[10].Side1 = CubeFaces[4, 1, 0]; MiddleCorners[10].Side2 = CubeFaces[1, 0, 1]; MiddleCorners[10].Location = "4,1,0,1,0,1";
            MiddleCorners[11].Side1 = CubeFaces[1, 2, 1]; MiddleCorners[11].Side2 = CubeFaces[2, 1, 0]; MiddleCorners[11].Location = "2,1,0,1,2,1";
            return MiddleCorners;
        }
        protected ThreeSidedCorner[] GetCorners()
        {
            Corners[0].SideOne = CubeFaces[0, 0, 0]; Corners[0].SideTwo = CubeFaces[1, 0, 2]; Corners[0].SideThree = CubeFaces[4, 2, 0]; Corners[0].Location = "0,0,0,1,0,2,4,2,0";
            Corners[1].SideOne = CubeFaces[0, 0, 2]; Corners[1].SideTwo = CubeFaces[4, 2, 2]; Corners[1].SideThree = CubeFaces[3, 0, 0]; Corners[1].Location = "0,0,2,4,2,2,3,0,0";
            Corners[2].SideOne = CubeFaces[0, 2, 2]; Corners[2].SideTwo = CubeFaces[3, 2, 0]; Corners[2].SideThree = CubeFaces[2, 0, 2]; Corners[2].Location = "0,2,2,3,2,0,2,0,2";
            Corners[3].SideOne = CubeFaces[0, 2, 0]; Corners[3].SideTwo = CubeFaces[2, 0, 0]; Corners[3].SideThree = CubeFaces[1, 2, 2]; Corners[3].Location = "0,2,0,2,0,0,1,2,2";
            Corners[4].SideOne = CubeFaces[5, 0, 0]; Corners[4].SideTwo = CubeFaces[1, 2, 0]; Corners[4].SideThree = CubeFaces[2, 2, 0]; Corners[4].Location = "5,0,0,1,2,0,2,2,0";
            Corners[5].SideOne = CubeFaces[5, 2, 0]; Corners[5].SideTwo = CubeFaces[4, 0, 0]; Corners[5].SideThree = CubeFaces[1, 0, 0]; Corners[5].Location = "5,2,0,4,0,0,1,0,0";
            Corners[6].SideOne = CubeFaces[5, 0, 2]; Corners[6].SideTwo = CubeFaces[2, 2, 2]; Corners[6].SideThree = CubeFaces[3, 2, 2]; Corners[6].Location = "5,0,2,2,2,2,3,2,2";
            Corners[7].SideOne = CubeFaces[5, 2, 2]; Corners[7].SideTwo = CubeFaces[3, 0, 2]; Corners[7].SideThree = CubeFaces[4, 0, 2]; Corners[7].Location = "5,2,2,3,0,2,4,0,2";
            return Corners;
        }

        private bool GetOppositeFaces(int x, string WhichSide, ThreeSidedCorner[] Corners, TwoSidedCorner[] MiddleCorners)
        {
            if (WhichSide == "MiddleCorner")
            {
                if (((MiddleCorners[x].Side1 == 'b') || (MiddleCorners[x].Side1 == 'g')) &&
                    ((MiddleCorners[x].Side2 == 'b') || (MiddleCorners[x].Side2 == 'g')))
                {
                    return false;
                }
                else if (((MiddleCorners[x].Side1 == 'r') || (MiddleCorners[x].Side1 == 'o')) &&
                    ((MiddleCorners[x].Side2 == 'r') || (MiddleCorners[x].Side2 == 'o')))
                {
                    return false;
                }
                else if (((MiddleCorners[x].Side1 == 'y') || (MiddleCorners[x].Side1 == 'w')) &&
                    ((MiddleCorners[x].Side2 == 'y') || (MiddleCorners[x].Side2 == 'w')))
                {
                    return false;
                }
                else if (((MiddleCorners[x].Side1 == 'o') || (MiddleCorners[x].Side1 == 'r')) &&
                    ((MiddleCorners[x].Side2 == 'o') || (MiddleCorners[x].Side2 == 'r')))
                {
                    return false;
                }
                else if (((MiddleCorners[x].Side1 == 'b') || (MiddleCorners[x].Side1 == 'g')) &&
                    ((MiddleCorners[x].Side2 == 'b') || (MiddleCorners[x].Side2 == 'g')))
                {
                    return false;
                }
            }
            else
            {

                if (((Corners[x].SideOne == 'w') || (Corners[x].SideOne == 'r') || (Corners[x].SideOne == 'b')) &&
                    ((Corners[x].SideTwo == 'w') || (Corners[x].SideTwo == 'r') || (Corners[x].SideTwo == 'b')) &&
                    ((Corners[x].SideThree == 'w') || (Corners[x].SideThree == 'r') || (Corners[x].SideThree == 'b')))
                {
                    return true;
                }
                else if (((Corners[x].SideOne == 'w') || (Corners[x].SideOne == 'o') || (Corners[x].SideOne == 'b')) &&
                    ((Corners[x].SideTwo == 'w') || (Corners[x].SideTwo == 'o') || (Corners[x].SideTwo == 'b')) &&
                    ((Corners[x].SideThree == 'w') || (Corners[x].SideThree == 'o') || (Corners[x].SideThree == 'b')))
                {
                    return true;
                }
                else if (((Corners[x].SideOne == 'w') || (Corners[x].SideOne == 'o') || (Corners[x].SideOne == 'g')) &&
                    ((Corners[x].SideTwo == 'w') || (Corners[x].SideTwo == 'o') || (Corners[x].SideTwo == 'g')) &&
                    ((Corners[x].SideThree == 'w') || (Corners[x].SideThree == 'o') || (Corners[x].SideThree == 'g')))
                {
                    return true;
                }
                else if (((Corners[x].SideOne == 'w') || (Corners[x].SideOne == 'r') || (Corners[x].SideOne == 'g')) &&
                    ((Corners[x].SideTwo == 'w') || (Corners[x].SideTwo == 'r') || (Corners[x].SideTwo == 'g')) &&
                    ((Corners[x].SideThree == 'w') || (Corners[x].SideThree == 'r') || (Corners[x].SideThree == 'g')))
                {
                    return true;
                }
                else if (((Corners[x].SideOne == 'y') || (Corners[x].SideOne == 'r') || (Corners[x].SideOne == 'g')) &&
                    ((Corners[x].SideTwo == 'y') || (Corners[x].SideTwo == 'r') || (Corners[x].SideTwo == 'g')) &&
                    ((Corners[x].SideThree == 'y') || (Corners[x].SideThree == 'r') || (Corners[x].SideThree == 'g')))
                {
                    return true;
                }
                else if (((Corners[x].SideOne == 'y') || (Corners[x].SideOne == 'r') || (Corners[x].SideOne == 'b')) &&
                    ((Corners[x].SideTwo == 'y') || (Corners[x].SideTwo == 'r') || (Corners[x].SideTwo == 'b')) &&
                    ((Corners[x].SideThree == 'y') || (Corners[x].SideThree == 'r') || (Corners[x].SideThree == 'b')))
                {
                    return true;
                }
                else if (((Corners[x].SideOne == 'y') || (Corners[x].SideOne == 'g') || (Corners[x].SideOne == 'b')) &&
                    ((Corners[x].SideTwo == 'y') || (Corners[x].SideTwo == 'g') || (Corners[x].SideTwo == 'b')) &&
                    ((Corners[x].SideThree == 'y') || (Corners[x].SideThree == 'g') || (Corners[x].SideThree == 'b')))
                {
                    return true;
                }
                else if (((Corners[x].SideOne == 'y') || (Corners[x].SideOne == 'o') || (Corners[x].SideOne == 'b')) &&
                    ((Corners[x].SideTwo == 'y') || (Corners[x].SideTwo == 'o') || (Corners[x].SideTwo == 'b')) &&
                    ((Corners[x].SideThree == 'y') || (Corners[x].SideThree == 'o') || (Corners[x].SideThree == 'b')))
                {
                    return true;
                }
            }

            return true;
        }
    }
}
