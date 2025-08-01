using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SolveCube : Cube
    {
        bool twisted = false;

        char[,,] CubeFaces;

        TwoSidedCorner[] M = new TwoSidedCorner[12];
        ThreeSidedCorner[] C = new ThreeSidedCorner[8];

        List<string> MoveList = new List<string>();


        public SolveCube(char[,,] c1)
        {
            CubeFaces = c1;
            UpdateCorners();
        }

        public List<string> GetMoveList()
        {
            return MoveList;
        }

        public bool GetTwisted()
        {
            return twisted;
        }

        private void UpdateCorners()
        {
            M[0].Side1 = CubeFaces[0, 1, 0]; M[0].Side2 = CubeFaces[1, 1, 2]; M[0].Location = "0,1,0,1,1,2";       // defines all middle corner positions
            M[1].Side1 = CubeFaces[0, 0, 1]; M[1].Side2 = CubeFaces[4, 2, 1]; M[1].Location = "0,0,1,4,2,1";
            M[2].Side1 = CubeFaces[0, 1, 2]; M[2].Side2 = CubeFaces[3, 1, 0]; M[2].Location = "0,1,2,3,1,0";
            M[3].Side1 = CubeFaces[0, 2, 1]; M[3].Side2 = CubeFaces[2, 0, 1]; M[3].Location = "0,2,1,2,0,1";
            M[4].Side1 = CubeFaces[5, 1, 0]; M[4].Side2 = CubeFaces[1, 1, 0]; M[4].Location = "5,1,0,1,1,0";
            M[5].Side1 = CubeFaces[5, 0, 1]; M[5].Side2 = CubeFaces[2, 2, 1]; M[5].Location = "5,0,1,2,2,1";
            M[6].Side1 = CubeFaces[5, 1, 2]; M[6].Side2 = CubeFaces[3, 1, 2]; M[6].Location = "5,1,2,3,1,2";
            M[7].Side1 = CubeFaces[5, 2, 1]; M[7].Side2 = CubeFaces[4, 0, 1]; M[7].Location = "5,2,1,4,0,1";
            M[8].Side1 = CubeFaces[4, 1, 2]; M[8].Side2 = CubeFaces[3, 0, 1]; M[8].Location = "4,1,2,3,0,1";
            M[9].Side1 = CubeFaces[3, 2, 1]; M[9].Side2 = CubeFaces[2, 1, 2]; M[9].Location = "3,2,1,2,1,2";
            M[10].Side1 = CubeFaces[4, 1, 0]; M[10].Side2 = CubeFaces[1, 0, 1]; M[10].Location = "1,0,1,4,1,0";
            M[11].Side1 = CubeFaces[1, 2, 1]; M[11].Side2 = CubeFaces[2, 1, 0]; M[11].Location = "2,1,0,1,2,1";

            C[0].SideOne = CubeFaces[0, 0, 0]; C[0].SideTwo = CubeFaces[1, 0, 2]; C[0].SideThree = CubeFaces[4, 2, 0]; C[0].Location = "0,0,0,1,0,2,4,2,0"; //defines all 
            C[1].SideOne = CubeFaces[0, 0, 2]; C[1].SideTwo = CubeFaces[4, 2, 2]; C[1].SideThree = CubeFaces[3, 0, 0]; C[1].Location = "0,0,2,4,2,2,3,0,0"; //corner positions
            C[2].SideOne = CubeFaces[0, 2, 2]; C[2].SideTwo = CubeFaces[3, 2, 0]; C[2].SideThree = CubeFaces[2, 0, 2]; C[2].Location = "0,2,2,3,2,0,2,0,2";
            C[3].SideOne = CubeFaces[0, 2, 0]; C[3].SideTwo = CubeFaces[2, 0, 0]; C[3].SideThree = CubeFaces[1, 2, 2]; C[3].Location = "0,2,0,2,0,0,1,2,2";
            C[4].SideOne = CubeFaces[5, 0, 0]; C[4].SideTwo = CubeFaces[1, 2, 0]; C[4].SideThree = CubeFaces[2, 2, 0]; C[4].Location = "5,0,0,1,2,0,2,2,0";
            C[5].SideOne = CubeFaces[5, 2, 0]; C[5].SideTwo = CubeFaces[4, 0, 0]; C[5].SideThree = CubeFaces[1, 0, 0]; C[5].Location = "5,2,0,4,0,0,1,0,0";
            C[6].SideOne = CubeFaces[5, 0, 2]; C[6].SideTwo = CubeFaces[2, 2, 2]; C[6].SideThree = CubeFaces[3, 2, 2]; C[6].Location = "5,0,2,2,2,2,3,2,2";
            C[7].SideOne = CubeFaces[5, 2, 2]; C[7].SideTwo = CubeFaces[3, 0, 2]; C[7].SideThree = CubeFaces[4, 0, 2]; C[7].Location = "5,2,2,3,0,2,4,0,2";
        }

        private void L(int Turns)
        {
            for (int i = 0; i < Turns; i++)
            {
                CubeFaces = Rotations.L(1, CubeFaces);

                UpdateCorners();

                if (Turns != 3)
                {
                    MoveList.Add("L");
                }
            }
            if (Turns == 3)
            {
                MoveList.Add("L'");
            }
        }

        private void R(int Turns)
        {
            for (int i = 0; i < Turns; i++)
            {
                CubeFaces = Rotations.R(1, CubeFaces);

                UpdateCorners();

                if (Turns != 3)
                {
                    MoveList.Add("R");
                }
            }
            if (Turns == 3)
            {
                MoveList.Add("R'");
            }
        }

        private void F(int Turns)
        {
            for (int i = 0; i < Turns; i++)
            {
                CubeFaces = Rotations.F(1, CubeFaces);

                UpdateCorners();

                if (Turns != 3)
                {
                    MoveList.Add("F");
                }
            }
            if (Turns == 3)
            {
                MoveList.Add("F'");
            }
        }

        private void U(int Turns)
        {
            for (int i = 0; i < Turns; i++)
            {
                CubeFaces = Rotations.U(1, CubeFaces);

                UpdateCorners();

                if (Turns != 3)
                {
                    MoveList.Add("U");
                }
            }
            if (Turns == 3)
            {
                MoveList.Add("U'");
            }
        }

        private void D(int Turns)
        {
            for (int i = 0; i < Turns; i++)
            {
                CubeFaces = Rotations.D(1, CubeFaces);

                UpdateCorners();

                if (Turns != 3)
                {
                    MoveList.Add("D");
                }
            }
            if (Turns == 3)
            {
                MoveList.Add("D'");
            }
        }

        private void B(int Turns)
        {
            for (int i = 0; i < Turns; i++)
            {
                CubeFaces = Rotations.B(1, CubeFaces);

                UpdateCorners();

                if (Turns != 3)
                {
                    MoveList.Add("B");
                }
            }
            if (Turns == 3)
            {
                MoveList.Add("B'");
            }
        }

        private string FindMiddleCorner(char c1, char c2)
        {
            for (int i = 0; i < 12; i++)
            {
                if ((M[i].Side1 == c1 || M[i].Side1 == c2) &&       // searches across all middle corners and checks the colours 
                    (M[i].Side2 == c1 || M[i].Side2 == c2))         // to return the location of the corner it is looking for
                {
                    return M[i].Location;
                }
            }
            return "0,0,0,0,0,0";
        }
        private string FindCorner(char c1, char c2, char c3)
        {
            for (int i = 0; i < 8; i++)
            {
                if ((C[i].SideOne == c1 || C[i].SideOne == c2 || C[i].SideOne == c3) &&     // finds 3 sided corner and returns
                    (C[i].SideTwo == c1 || C[i].SideTwo == c2 || C[i].SideTwo == c3) &&     // location
                    (C[i].SideThree == c1 || C[i].SideThree == c2 || C[i].SideThree == c3))
                {
                    return C[i].Location;
                }
            }
            return "0,0,0,0,0,0,0,0,0";
        }

        private char GetCorrectColour(int z)
        {      //takes the integer side number and converts it into the colour corrosponding with that side
            return CubeFaces[z, 1, 1];
        }

        public bool NotSolved()
        {
            bool z = false;
            for(int side = 0; side < 6; side++)
            {
                for(int x = 0; x < 3; x++)
                {
                    for(int y = 0; y < 3; y++)
                    {
                        if (CubeFaces[side,x,y] != GetCorrectColour(side))
                        {
                            z = true;
                        }
                    }
                }
            }
            return z;

        }

        private int OppositeFace(int x)
        {
            int y = 1;
            switch (x)
            {
                case 0:
                    y = 5;
                    break;
                case 1:
                    y = 3;
                    break;
                case 2:
                    y =  4;
                    break;
                case 3:
                    y =  1;
                    break;
                case 4:
                    y =  2;
                    break;
                case 5:
                    y =  0;
                    break;
            }
            return y;
        }

        private void rotateCorrectSide(string[] c, string x)// c = currentSide    x = state
        {

            if (x == "Opposite")
            {
                if (c[3] == "1")
                {
                    while (CubeFaces[5, 1, 0] == 'w')
                    {
                        B(1);
                    }
                    U(2);
                }
                else if (c[3] == "2")
                {
                    while (CubeFaces[5, 0, 1] == 'w')
                    {
                        B(1);
                    }
                    R(2);
                }
                else if (c[3] == "3")
                {
                    while (CubeFaces[5, 1, 2] == 'w')
                    {
                        B(1);
                    }
                    D(2);
                }
                else if (c[3] == "4")
                {
                    while (CubeFaces[5, 2, 1] == 'w')
                    {
                        B(1);
                    }
                    L(2);
                }
            }
            else if (x == "TopLayerDown")
            {
                if (c[3] == "4")
                {
                    while (CubeFaces[5, 1, 2] == 'w')
                    {
                        B(1);
                    }
                    L(1);
                    D(3);
                    L(3);
                }
                else if (c[3] == "3")
                {
                    while (CubeFaces[5, 0, 1] == 'w')
                    {
                        B(1);
                    }
                    D(1);
                    R(3);
                    D(3);
                }
                else if (c[3] == "2")
                {
                    while (CubeFaces[5, 1, 0] == 'w')
                    {
                        B(1);
                    }
                    R(1);
                    U(3);
                    R(3);
                }
                else if (c[3] == "1")
                {
                    while (CubeFaces[5, 2, 1] == 'w')
                    {
                        B(1);
                    }
                    U(1);
                    L(3);
                    U(3);
                }
            }
            else if (x == "BottomLayerUp")
            {
                if (c[3] == "4")
                {
                    L(1);
                }
                else if (c[3] == "3")
                {
                    D(3);
                }
                else if (c[3] == "2")
                {
                    R(2);
                }
                else if (c[3] == "1")
                {
                    U(3);
                }
            }
            else if (x == "MiddleLeft")
            {
                if (c[0] == "4")
                {
                    while (CubeFaces[5, 1, 2] == 'w')
                    {
                        B(1);
                    }
                    D(3);
                }
                else if (c[0] == "3")
                {
                    while (CubeFaces[5, 0, 1] == 'w')
                    {
                        B(1);
                    }
                    R(3);
                }
                else if (c[0] == "2")
                {
                    while (CubeFaces[5, 1, 0] == 'w')
                    {
                        B(1);
                    }
                    U(3);
                }
                else if (c[0] == "1")
                {
                    while (CubeFaces[5, 2, 1] == 'w')
                    {
                        B(1);
                    }
                    L(1);
                }
            }
            else
            {
                if (c[0] == "4")
                {
                    while (CubeFaces[5, 2, 1] == 'w')
                    {
                        B(1);
                    }
                    L(1);
                }
                else if (c[0] == "3")
                {
                    while (CubeFaces[5, 1, 2] == 'w')
                    {
                        B(1);
                    }
                    D(1);
                }
                else if (c[0] == "2")
                {
                    while (CubeFaces[5, 0, 1] == 'w')
                    {
                        B(1);
                    }
                    R(1);
                }
                else if (c[0] == "1")
                {
                    while (CubeFaces[5, 1, 0] == 'w')
                    {
                        B(1);
                    }
                    U(1);
                }
            }

        }

        private bool YellowCross(char colour)
        {
            if (CubeFaces[5, 1, 0] == colour)
            {
                if (CubeFaces[5, 2, 1] == colour)
                {
                    if (CubeFaces[5, 0, 1] == colour)
                    {
                        if (CubeFaces[5, 1, 2] == colour)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool NotSolvedWhiteCross()
        {
            if (CubeFaces[0, 1, 0] == 'w')
            {
                if (CubeFaces[0, 2, 1] == 'w')
                {
                    if (CubeFaces[0, 0, 1] == 'w')
                    {
                        if (CubeFaces[0, 1, 2] == 'w')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private char GetCharWhiteCross(int Colour, int q)
        {
            char c1 = 'w';
            char c2 = CubeFaces[q, 1, 1];
            if (Colour == 1)
            {
                return c1;
            }
            else
            {
                return c2;
            }
        }
        private char GetCharWhiteCorners(int Colour, int q)
        {
            char c1 = 'w';
            char c2 = 'w';
            char c3 = 'w';
            switch (q)
            {
                case 0:
                    c2 = 'r';
                    c3 = 'b';
                    break;
                case 1:
                    c2 = 'b';
                    c3 = 'o';
                    break;
                case 2:
                    c2 = 'o';
                    c3 = 'g';
                    break;
                case 3:
                    c2 = 'g';
                    c3 = 'r';
                    break;
            }
            if (Colour == 1)
            {
                return c1;
            }
            else if (Colour == 2)
            {
                return c2;
            }
            else
            {
                return c3;
            }
        }
        private char GetCharSecondLayer(int Colour, int q)
        {
            char c1 = 'w';
            char c2 = 'w';
            switch (q)
            {
                case 0:
                    c2 = 'r';
                    c1 = 'b';
                    break;
                case 1:
                    c2 = 'b';
                    c1 = 'o';
                    break;
                case 2:
                    c2 = 'o';
                    c1 = 'g';
                    break;
                case 3:
                    c2 = 'g';
                    c1 = 'r';
                    break;
            }
            if (Colour == 1)
            {
                return c1;
            }
            else
            {
                return c2;
            }
        }

        private void CreateYellowCrossWhiteMiddle()
        {
            string[] c;   //current location of piece being handled
            int q = 1;
            char FirstColour;
            char SecondColour;
            while (!YellowCross('w'))  //while yellow cross is not solved
            {
                FirstColour = GetCharWhiteCross(1, q);  // gets the 2 colours of the piece currently being handled which is denoted by q
                SecondColour = GetCharWhiteCross(2, q);
                c = FindMiddleCorner(FirstColour, SecondColour).Split(','); // finds piece location

                if (int.Parse(c[0]) == 0)        //if face side of colour 1 is white
                {
                    if (CubeFaces[int.Parse(c[0]), int.Parse(c[1]), int.Parse(c[2])] == 'w')  // if colour 1 = white
                    {
                        rotateCorrectSide(c, "Opposite");       // 180 degree turn to yellow side
                    }
                    else
                    {
                        rotateCorrectSide(c, "TopLayerDown");   //moves to yellow side
                    }
                }
                else if (int.Parse(c[0]) == 5)
                {
                    if (CubeFaces[int.Parse(c[0]), int.Parse(c[1]), int.Parse(c[2])] != 'w')
                    {
                        rotateCorrectSide(c, "BottomLayerUp");  //moves to any middle corner
                        rotateCorrectSide(c, "Middle");     //moves from middle corner to yellow side
                    }
                }
                else
                {
                    if (CubeFaces[int.Parse(c[0]), int.Parse(c[1]), int.Parse(c[2])] == 'w')
                    {
                        rotateCorrectSide(c, "MiddleLeft");     //moves from middle to yellow side
                    }
                    else
                    {
                        rotateCorrectSide(c, "MiddleRight");        //moves from middle to yellow side
                    }
                }
                q++;    // increments to next piece
                if (q == 5)  // resets back to the first piece however highly unlikely for this to ever run but is possible
                {
                    q = 1;
                }
            }

        }

        private bool WhiteSideSolved()
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (CubeFaces[0, x, y] != 'w')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private char ColourToRight(string x)
        {
            char q;
            if (x == "1")
            {
                q = 'b';
            }
            else if (x == "2")
            {
                q = 'r';
            }
            else if (x == "3")
            {
                q = 'g';
            }
            else
            {
                q = 'o';
            }
            return q;
        }

        private void SlotPieceWhiteCorner(string[] pos, char fCol, char sCol, char tCol)
        {
            char TopSide;
            char LeftSide = CubeFaces[int.Parse(pos[3]), int.Parse(pos[4]), int.Parse(pos[5])];
            char RightSide;
            if (pos[0] == "0")
            {
                if (CubeFaces[int.Parse(pos[3]), 1, 1] != LeftSide)
                {
                    if (pos[6] == "1")
                    {
                        while (CubeFaces[1, 2, 0] == 'w')
                        {
                            B(1);
                        }
                        R(1);
                        B(1);
                        R(3);
                    }
                    else if (pos[6] == "2")
                    {
                        while (CubeFaces[2, 2, 2] == 'w')
                        {
                            B(1);
                        }
                        D(1);
                        B(1);
                        D(3);
                    }
                    else if (pos[6] == "3")
                    {
                        while (CubeFaces[3, 0, 2] == 'w')
                        {
                            B(1);
                        }
                        L(1);
                        B(1);
                        L(3);
                    }
                    else if (pos[6] == "4")
                    {
                        while (CubeFaces[4, 0, 0] == 'w')
                        {
                            B(1);
                        }
                        U(1);
                        B(1);
                        U(3);
                    }
                }
            }// all above is on white face (face 0)
            pos = FindCorner(fCol, sCol, tCol).Split(',');
            TopSide = CubeFaces[int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])];
            LeftSide = CubeFaces[int.Parse(pos[3]), int.Parse(pos[4]), int.Parse(pos[5])];
            RightSide = CubeFaces[int.Parse(pos[6]), int.Parse(pos[7]), int.Parse(pos[8])];
            // x will now be on the yellow side in every scenario
            if (LeftSide == 'w')
            {
                while (CubeFaces[int.Parse(pos[3]), 1, 1] != TopSide)
                {
                    B(1);
                    pos = FindCorner(fCol, sCol, tCol).Split(',');
                    TopSide = CubeFaces[int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])];
                }
                pos = FindCorner(fCol, sCol, tCol).Split(',');
                if (pos[3] == "1")
                {
                    R(3);
                    U(1);
                    R(1);
                    U(3);
                }
                else if (pos[3] == "2")
                {
                    D(3);
                    R(1);
                    D(1);
                    R(3);
                }
                else if (pos[3] == "3")
                {
                    L(3);
                    D(1);
                    L(1);
                    D(3);
                }
                else if (pos[3] == "4")
                {
                    U(3);
                    L(1);
                    U(1);
                    L(3);
                }
            }
            else if (RightSide == 'w')
            {
                // this is where thing go wrong
                while (CubeFaces[int.Parse(pos[6]), 1, 1] != TopSide)
                {
                    B(1);
                    pos = FindCorner(fCol, sCol, tCol).Split(',');
                    TopSide = CubeFaces[int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])];
                }
                pos = FindCorner(fCol, sCol, tCol).Split(',');
                if (pos[6] == "1")
                {
                    L(1);
                    U(3);
                    L(3);
                    U(1);
                }
                else if (pos[6] == "2")
                {
                    U(1);
                    R(3);
                    U(3);
                    R(1);
                }
                else if (pos[6] == "3")
                {
                    R(1);
                    D(3);
                    R(3);
                    D(1);
                }
                else if (pos[6] == "4")
                {
                    D(1);
                    L(3);
                    D(3);
                    L(1);
                }
            }
            else
            {
                while (ColourToRight(pos[3]) != RightSide)
                {
                    B(1);
                    pos = FindCorner(fCol, sCol, tCol).Split(',');
                    RightSide = CubeFaces[int.Parse(pos[6]), int.Parse(pos[7]), int.Parse(pos[8])];
                }
                pos = FindCorner(fCol, sCol, tCol).Split(',');
                if (pos[3] == "1")
                {
                    U(2);
                    L(1);
                    U(2);
                    L(3);
                    R(3);
                    U(1);
                    R(1);
                    U(3);
                }
                else if (pos[3] == "2")
                {
                    R(2);
                    U(1);
                    R(2);
                    U(3);
                    D(3);
                    R(1);
                    D(1);
                    R(3);
                }
                else if (pos[3] == "3")
                {
                    D(2);
                    R(1);
                    D(2);
                    R(3);
                    L(3);
                    D(1);
                    L(1);
                    D(3);
                }
                else if (pos[3] == "4")
                {
                    L(2);
                    D(1);
                    L(2);
                    D(3);
                    U(3);
                    L(1);
                    U(1);
                    L(3);

                }
            }
        }

        private bool MiddleCornerSlotted(char fCol, char sCol)
        {
            string Side1 = "0";
            string Side2 = "0";
            char col = fCol;
            string pos = "";
            string[] POS;
            for(int i = 0; i < 2; i++)
            {
                if(i == 1)
                {
                    col = sCol;
                }
                switch (col)
                {
                    case 'b':
                        Side1 = "4";
                        break;
                    case 'r':
                        Side1 = "1";
                        break;
                    case 'g':
                        Side1 = "2";
                        break;
                    case 'o':
                        Side1 = "3";
                        break;
                }
                if(i == 0)
                {
                    Side2 = Side1;
                }
            }
            switch (Side1 + Side2)
            {
                case "14":
                    pos = M[10].Location;
                    break;
                case "43":
                    pos = M[8].Location;
                    break;
                case "32":
                    pos = M[9].Location;
                    break;
                case "21":
                    pos = M[11].Location;
                    break;
            }
            POS = pos.Split(',');
            if(CubeFaces[int.Parse(POS[0]), 1, 1] == CubeFaces[int.Parse(POS[0]), int.Parse(POS[1]), int.Parse(POS[2])] &&
               CubeFaces[int.Parse(POS[3]), 1, 1] == CubeFaces[int.Parse(POS[3]), int.Parse(POS[4]), int.Parse(POS[5])])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MoveIntoBlueRed()
        {
            L(3);
            B(1);
            L(1);
            U(3);
            L(1);
            U(1);
            L(3);
        }
        private void MoveIntoGreenRed()
        {
            U(3);
            B(1);
            U(1);
            R(3);
            U(1);
            R(1);
            U(3);
        }
        private void MoveIntoOrangeGreen()
        {
            R(3);
            B(1);
            R(1);
            D(3);
            R(1);
            D(1);
            R(3);
        }
        private void MoveIntoBlueOrange()
        {
            D(3);
            B(1);
            D(1);
            L(3);
            D(1);
            L(1);
            D(3);
        }
        private char RightSide(string x)
        {
            char y = 'w';
            switch (x)
            {
                case "1":
                    y = 'g';
                    break;
                case "2":
                    y = 'o';
                    break;
                case "3":
                    y = 'b';
                    break;
                case "4":
                    y = 'r';
                    break;
            }
            return y;
        }

        private void SlotPieceSecondLayer(char fCol, char sCol)
        {
            char TopColour;
            char BottomColour;
            string[] pos;

            if(CubeFaces[5, 1, 0] != 'y' && CubeFaces[1, 1, 0] != 'y')
            {
                TopColour = CubeFaces[5, 1, 0];
                BottomColour = CubeFaces[1, 1, 0];
            }
            else if(CubeFaces[5, 0, 1] != 'y' && CubeFaces[2, 2, 1] != 'y')
            {
                TopColour = CubeFaces[5, 0, 1];
                BottomColour = CubeFaces[2, 2, 1];
            }
            else if (CubeFaces[5, 2, 1] != 'y' && CubeFaces[4, 0, 1] != 'y')
            {
                TopColour = CubeFaces[5, 2, 1];
                BottomColour = CubeFaces[4, 0, 1];
            }
            else if (CubeFaces[5, 1, 2] != 'y' && CubeFaces[3, 1, 2] != 'y')
            {
                TopColour = CubeFaces[5, 1, 2];
                BottomColour = CubeFaces[3, 1, 2];
            }
            else
            {
                TopColour = fCol;
                BottomColour = sCol;
                pos = FindMiddleCorner(TopColour, BottomColour).Split(',');
                if(pos[0] == "1" && pos[3] == "4")
                {
                    while(CubeFaces[5, 0, 1] != 'y' && CubeFaces[2, 2, 1] != 'y')
                    {
                        B(1);
                    }
                    MoveIntoBlueRed();
                }
                else if (pos[0] == "2" && pos[3] == "1")
                {
                    while (CubeFaces[5, 1, 2] != 'y' && CubeFaces[3, 1, 2] != 'y')
                    {
                        B(1);
                    }
                    MoveIntoGreenRed();
                }
                else if (pos[0] == "3" && pos[3] == "2")
                {
                    while (CubeFaces[5, 2, 1] != 'y' && CubeFaces[4, 0, 1] != 'y')
                    {
                        B(1);
                    }
                    MoveIntoOrangeGreen();
                }
                else if (pos[0] == "4" && pos[3] == "3")
                {
                    while (CubeFaces[5, 1, 0] != 'y' && CubeFaces[1, 1, 0] != 'y')
                    {
                        B(1);
                    }
                    MoveIntoBlueOrange();
                }
                return;
            }

            pos = FindMiddleCorner(TopColour, BottomColour).Split(',');

            while (CubeFaces[int.Parse(pos[3]), int.Parse(pos[4]), int.Parse(pos[5])] != CubeFaces[int.Parse(pos[3]), 1, 1])
            {
                B(1);
                pos = FindMiddleCorner(TopColour, BottomColour).Split(',');
            }
            if (CubeFaces[int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])] != RightSide(pos[3]))
            {
                B(3);
                pos = FindMiddleCorner(TopColour, BottomColour).Split(',');
                switch (CubeFaces[int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])])
                {
                    case 'g':
                        MoveIntoOrangeGreen();
                        break;
                    case 'o':
                        MoveIntoBlueOrange();
                        break;
                    case 'b':
                        MoveIntoBlueRed();
                        break;
                    case 'r':
                        MoveIntoGreenRed();
                        break;
                }
            }
            else
            {
                B(1);
                pos = FindMiddleCorner(TopColour, BottomColour).Split(',');
                if (CubeFaces[int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])] == 'b')
                {
                    L(1);
                    B(3);
                    L(3);
                    D(1);
                    L(3);
                    D(3);
                    L(1);
                }
                else if (CubeFaces[int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])] == 'r')
                {
                    U(1);
                    B(3);
                    U(3);
                    L(1);
                    U(3);
                    L(3);
                    U(1);
                }
                else if (CubeFaces[int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])] == 'g')
                {
                    R(1);
                    B(3);
                    R(3);
                    U(1);
                    R(3);
                    U(3);
                    R(1);
                }
                else if (CubeFaces[int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(pos[2])] == 'o')
                {
                    D(1);
                    B(3);
                    D(3);
                    R(1);
                    D(3);
                    R(3);
                    D(1);
                }
            }


        }

        private bool SecondLayerSolved()
        {
            bool solved = false;

            if(CubeFaces[1,0,1] == 'r' && CubeFaces[4,1,0] == 'b')
            {
                if(CubeFaces[4,1,2] == 'b' && CubeFaces[3,0,1] == 'o')
                {
                    if(CubeFaces[3,2,1] == 'o' && CubeFaces[2,1,2] == 'g')
                    {
                        if(CubeFaces[2,1,0] == 'g' && CubeFaces[1,2,1] == 'r')
                        {
                            solved = true;
                        }
                    }
                }
            }
            return solved;
        }

        private char GetSideColour(int i)
        {
            char x = 'r';

            switch (i)
            {
                case 1:
                    x = CubeFaces[1, 1, 0];
                    break;
                case 2:
                    x = CubeFaces[2, 2, 1];
                    break;
                case 3:
                    x = CubeFaces[3, 1, 2];
                    break;
                case 4:
                    x = CubeFaces[4, 0, 1];
                    break;
            }
            return x;
        }

        private bool ColoursNotMatched()
        {
            bool x = true;      //dont have to check for blue side becuase if all the other 3 sides are correct then blue 
            if(CubeFaces[1,1,0] == 'r' && CubeFaces[2,2,1] == 'g' && CubeFaces[3,1,2] == 'o') //must also be correct
            {
                x = false;
            }
            return x;
        }

        private int GetCorner()
        {
            string[] pos;
            int Corner = 0;
            for (int i = 4; i < 8; i++)
            {
                pos = C[i].Location.Split(',');
                if (C[i].SideOne == CubeFaces[int.Parse(pos[0]), 1, 1] ||
                    C[i].SideOne == CubeFaces[int.Parse(pos[3]), 1, 1] ||
                    C[i].SideOne == CubeFaces[int.Parse(pos[6]), 1, 1])
                {
                    if (C[i].SideTwo == CubeFaces[int.Parse(pos[0]), 1, 1] ||
                        C[i].SideTwo == CubeFaces[int.Parse(pos[3]), 1, 1] ||
                        C[i].SideTwo == CubeFaces[int.Parse(pos[6]), 1, 1])
                    {
                        if (C[i].SideThree == CubeFaces[int.Parse(pos[0]), 1, 1] ||
                            C[i].SideThree == CubeFaces[int.Parse(pos[3]), 1, 1] ||
                            C[i].SideThree == CubeFaces[int.Parse(pos[6]), 1, 1])
                        {
                            Corner = i;
                        }
                    }
                }    
            }
            return Corner;
        }

        private bool InCorrectOrientation()
        {
            int value = 0;
            string[] pos;
            for (int i = 4; i < 8; i++)
            {
                pos = C[i].Location.Split(',');
                if (C[i].SideOne == CubeFaces[int.Parse(pos[0]), 1, 1] ||
                    C[i].SideOne == CubeFaces[int.Parse(pos[3]), 1, 1] ||
                    C[i].SideOne == CubeFaces[int.Parse(pos[6]), 1, 1])
                {
                    if (C[i].SideTwo == CubeFaces[int.Parse(pos[0]), 1, 1] ||
                        C[i].SideTwo == CubeFaces[int.Parse(pos[3]), 1, 1] ||
                        C[i].SideTwo == CubeFaces[int.Parse(pos[6]), 1, 1])
                    {
                        if (C[i].SideThree == CubeFaces[int.Parse(pos[0]), 1, 1] ||
                            C[i].SideThree == CubeFaces[int.Parse(pos[3]), 1, 1] ||
                            C[i].SideThree == CubeFaces[int.Parse(pos[6]), 1, 1])
                        {
                            value++;
                        }
                    }
                }
            }
            if(value >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void WhiteCross()
        {
            char FirstColour;
            char SecondColour;
            string[] c;
            int q = 1;
            char s;
            UpdateCorners();
            if (NotSolvedWhiteCross())
            {
                if (!YellowCross('w'))
                {
                    CreateYellowCrossWhiteMiddle();
                }
            }
            
            while (NotSolvedWhiteCross())
            {
                FirstColour = GetCharWhiteCross(1, q);
                SecondColour = GetCharWhiteCross(2, q);
                c = FindMiddleCorner(FirstColour, SecondColour).Split(',');
                while (SecondColour != CubeFaces[int.Parse(c[3]), 1, 1])
                {
                    B(1);
                    c = FindMiddleCorner(FirstColour, SecondColour).Split(',');
                }
                s = CubeFaces[int.Parse(c[3]), int.Parse(c[4]), int.Parse(c[5])];
                if (s == 'r')
                {
                    U(2);
                }
                else if (s == 'g')
                {
                    R(2);
                }
                else if (s == 'o')
                {
                    D(2);
                }
                else if (s == 'b')
                {
                    L(2);
                }
                q++;
            }
            Console.WriteLine("Done white cross");
        }

        public void WhiteCorners()
        {

            string[] Current;
            char FirstColour;
            char SecondColour;
            char ThirdColour;
            int q = 0;

            while (!WhiteSideSolved())
            {
                FirstColour = GetCharWhiteCorners(1, q);
                SecondColour = GetCharWhiteCorners(2, q);
                ThirdColour = GetCharWhiteCorners(3, q);
                Current = FindCorner(FirstColour, SecondColour, ThirdColour).Split(',');

                if ((!(CubeFaces[int.Parse(Current[0]), 1, 1] ==
                    CubeFaces[int.Parse(Current[0]), int.Parse(Current[1]), int.Parse(Current[2])])) ||
                    (!(CubeFaces[int.Parse(Current[3]), 1, 1] ==
                    CubeFaces[int.Parse(Current[3]), int.Parse(Current[4]), int.Parse(Current[5])])) ||
                    (!(CubeFaces[int.Parse(Current[6]), 1, 1] ==
                        CubeFaces[int.Parse(Current[6]), int.Parse(Current[7]), int.Parse(Current[8])])))
                {
                    SlotPieceWhiteCorner(Current, FirstColour, SecondColour, ThirdColour);
                }
                q++;
                if (q == 4)
                {
                    q = 0;
                }
            }
            Console.WriteLine("Done White Corners");
        }

        public void SlotSecondLayer()
        {
            char FirstColour;
            char SecondColour;
            int q = 0;

            while (!SecondLayerSolved())
            {

                FirstColour = GetCharSecondLayer(1, q);
                SecondColour = GetCharSecondLayer(2, q);

                if(!MiddleCornerSlotted(FirstColour, SecondColour))
                {
                    SlotPieceSecondLayer(FirstColour, SecondColour);
                }

                q++;
                if (q == 4)
                {
                    q = 0;
                }

            }
            Console.WriteLine("Done second layer");
        }

        public void MakeYellowCross()
        {

            if (!YellowCross('y'))
            {

                if (CubeFaces[5, 0, 1] == 'y' && CubeFaces[5, 1, 0] == 'y')
                {
                    for (int i = 0; i < 2; i++)
                    {
                        D(1);
                        L(1);
                        B(1);
                        L(3);
                        B(3);
                        D(3);
                    }
                }
                else if (CubeFaces[5, 1, 0] == 'y' && CubeFaces[5, 2, 1] == 'y')
                {
                    for (int i = 0; i < 2; i++)
                    {
                        R(1);
                        D(1);
                        B(1);
                        D(3);
                        B(3);
                        R(3);
                    }
                }
                else if (CubeFaces[5, 2, 1] == 'y' && CubeFaces[5, 1, 2] == 'y')
                {
                    for (int i = 0; i < 2; i++)
                    {
                        U(1);
                        R(1);
                        B(1);
                        R(3);
                        B(3);
                        U(3);
                    }
                }

                else if (CubeFaces[5, 1, 2] == 'y' && CubeFaces[5, 0, 1] == 'y')
                {
                    for (int i = 0; i < 2; i++)
                    {
                        L(1);
                        U(1);
                        B(1);
                        U(3);
                        B(3);
                        L(3);
                    }        
                }
                else if(CubeFaces[5, 0, 1] == 'y' && CubeFaces[5, 2, 1] == 'y')
                {
                    D(1);
                    L(1);
                    B(1);
                    L(3);
                    B(3);
                    D(3);
                }
                else if (CubeFaces[5, 1, 0] == 'y' && CubeFaces[5, 1, 2] == 'y')
                {
                    R(1);
                    D(1);
                    B(1);
                    D(3);
                    B(3);
                    R(3);
                }
                else
                {
                    D(1);
                    L(1);
                    B(1);
                    L(3);
                    B(3);
                    D(3);
                    MakeYellowCross();
                }

            }
            Console.WriteLine("Done Yellow Cross");

        }

        public void MatchUpColours()
        {
            char x;
            int q;
            bool done;
            List<int> CorrectSides = new List<int>();
            while (ColoursNotMatched())
            {
                CorrectSides.Clear();
                done = false;
                for(int y = 1; y < 5; y++)
                {
                    B(1);
                    if (done)
                    {
                        break;
                    }
                    for (int i = 1; i < 5; i++)
                    {
                        x = GetSideColour(i);
                        if (x == CubeFaces[i, 1, 1])
                        {
                            q = i + 1; 
                            if(q == 5)
                            {
                                q = 1;
                            }
                            x = GetSideColour(q);
                            if(x == CubeFaces[q, 1, 1])
                            {
                                if (i > q)
                                {
                                    CorrectSides.Add(q);
                                    CorrectSides.Add(i);
                                }
                                else
                                {
                                    CorrectSides.Add(i);
                                    CorrectSides.Add(q);
                                }
                                done = true;
                                break;
                            }
                            q++;
                            if (q == 5)
                            {
                                q = 1;
                            }
                            x = GetSideColour(q);
                            if (x == CubeFaces[q, 1, 1])
                            {
                                if (i > q)
                                {
                                    CorrectSides.Add(q);
                                    CorrectSides.Add(i);
                                }
                                else
                                {
                                    CorrectSides.Add(i);
                                    CorrectSides.Add(q);
                                }
                                done = true;
                                break;
                            }
                        }  
                    }
                }
                if (CorrectSides.Count != 4)
                {
                    B(3);
                    switch (CorrectSides[0].ToString() + CorrectSides[1].ToString())
                    {
                        case "12":
                            U(1);
                            B(1);
                            U(3);
                            B(1);
                            U(1);
                            B(2);
                            U(3);
                            B(1);
                            break;
                        case "23":
                            R(1);
                            B(1);
                            R(3);
                            B(1);
                            R(1);
                            B(2);
                            R(3);
                            B(1);
                            break;
                        case "34":
                            D(1);
                            B(1);
                            D(3);
                            B(1);
                            D(1);
                            B(2);
                            D(3);
                            B(1);
                            break;
                        case "14":
                            L(1);
                            B(1);
                            L(3);
                            B(1);
                            L(1);
                            B(2);
                            L(3);
                            B(1);
                            break;
                        case "13":
                            D(1);
                            B(1);
                            D(3);
                            B(1);
                            D(1);
                            B(2);
                            D(3);
                            B(1);
                            break;
                        case "24":
                            R(1);
                            B(1);
                            R(3);
                            B(1);
                            R(1);
                            B(2);
                            R(3);
                            B(1);
                            break;
                    }
                }
            }
            Console.WriteLine("Matched colours");
        }

        public void MoveTopCorners()
        {

            int Corner;

            while (!InCorrectOrientation())
            {
                do
                {
                    Corner = GetCorner();
                    if (Corner == 0)
                    {
                        R(1);
                        B(3);
                        L(3);
                        B(1);
                        R(3);
                        B(3);
                        L(1);
                    }

                } while (Corner == 0);
                if (!InCorrectOrientation())
                {
                    B(1);
                    switch (Corner)
                    {
                        case 4:
                            R(1);
                            B(3);
                            L(3);
                            B(1);
                            R(3);
                            B(3);
                            L(1);
                            break;
                        case 5:
                            U(1);
                            B(3);
                            D(3);
                            B(1);
                            U(3);
                            B(3);
                            D(1);
                            break;
                        case 6:
                            D(1);
                            B(3);
                            U(3);
                            B(1);
                            D(3);
                            B(3);
                            U(1);
                            break;
                        case 7:
                            L(1);
                            B(3);
                            R(3);
                            B(1);
                            L(3);
                            B(3);
                            R(1);
                            break;
                    }

                }
            }
            
            Console.WriteLine("Done");
            

        }

        public void TwistCorners()
        {
            int x = 0;

            for(int i = 0; i < 4; i++)
            {
                while(CubeFaces[5,0,0] != 'y')
                {
                    U(1);
                    F(1);
                    U(3);
                    F(3);
                    x++;
                }
                B(1);
            }
            if (x % 6 != 0)     // if any of the corners were twisted then instead of saying this cube isnt solvable at the start 
            {                   // which it isnt, doing this will allow it to potentially be solved but if not then it will leave
                twisted = true; // 1 piece twisted which the user can then twist the piece on their cube
                for (int i = 0; i < 6 - (x % 6); i++)
                {
                    U(1);
                    F(1);
                    U(3);
                    F(3);
                }
            }
            Console.WriteLine("Solved");
        }
    }
}
