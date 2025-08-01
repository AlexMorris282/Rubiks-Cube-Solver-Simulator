using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace WindowsFormsApp1
{
    public partial class Display3D : Form
    {
        int FOV = 45;
        bool next;
        bool last;
        Rectangle rec = new Rectangle(200, 100, 600, 600);
        Graphics G;
        int MoveNumber = -1;
        bool Down = false;
        Point coords;
        int CubeNumber = 0;
        bool n = true;
        int size = 40;
        bool simulation = false;
        List<string> MoveList = new List<string>();
        public struct Point3D
        {
            public double x;
            public double y;
            public double z;
        }
        protected int GetSize()
        {
            return size;
        }

        RubiksCube[] cube = new RubiksCube[26];
        string FrontFace;
        char[,,] CubeFaces = new char[6, 3, 3];

        private Point3D rotation;

        Point3D[] points;
        public Display3D()
        {
            rotation.x = 0; rotation.y = 0; rotation.z = 0;
            // rotation.x = 0.5; rotation.y = 0.3; rotation.z = 0; 
        }
        private void SetUpCube()
        {
            for (int i = 0; i < 26; i++)
            {
                cube[i] = new RubiksCube();
                cube[i].SetPoints(i);
            }
        }

        public void SetSim(bool sim)
        {
            simulation = sim;
            InitializeComponent(!simulation);
        }


        private void Display3D_Paint(object sender, PaintEventArgs e)
        {
            G = e.Graphics;
            if (n)   // checks if it is the first time the Display3D_Paint() function has been run
            {
                if (!simulation)
                {
                    NextMove.Text = MoveList[MoveNumber + 1];
                }
                
                SetUpCube();
                n = false;
                using (StreamReader stream = new StreamReader("cubesave.txt"))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                            {
                                CubeFaces[i, x, y] = char.Parse(stream.ReadLine());
                            }
                        }
                    }
                    stream.Close();
                }
            }
            for (int i = 0; i < 26; i++)
            {
                points = cube[i].GetPoints();
                CubeNumber = cube[i].GetNumber();
                Draw();
            }
        }

        public Point3D GetRotation()
        {
            return rotation;
        }

        public void SetMoves(List<string> x)
        {
            MoveList = x;
        }

        private string FindFrontFace()
        {
            string ff = "white";
            PlaceIn2D findfront1 = new PlaceIn2D(cube[0].GetPoints()[0], rotation, FOV);
            PlaceIn2D findfront2 = new PlaceIn2D(cube[2].GetPoints()[1], rotation, FOV);
            PlaceIn2D findfront3 = new PlaceIn2D(cube[6].GetPoints()[3], rotation, FOV);
            PlaceIn2D findfront4 = new PlaceIn2D(cube[8].GetPoints()[2], rotation, FOV);
            double whiteZ = findfront1.GetPointZ() + findfront2.GetPointZ() + findfront3.GetPointZ() + findfront4.GetPointZ();
            findfront2 = new PlaceIn2D(cube[17].GetPoints()[4], rotation, FOV);
            findfront3 = new PlaceIn2D(cube[6].GetPoints()[3], rotation, FOV);
            findfront4 = new PlaceIn2D(cube[23].GetPoints()[7], rotation, FOV);
            double redZ = findfront1.GetPointZ() + findfront2.GetPointZ() + findfront3.GetPointZ() + findfront4.GetPointZ();
            findfront2 = new PlaceIn2D(cube[2].GetPoints()[1], rotation, FOV);
            findfront3 = new PlaceIn2D(cube[19].GetPoints()[5], rotation, FOV);
            findfront4 = new PlaceIn2D(cube[17].GetPoints()[4], rotation, FOV);
            double blueZ = findfront1.GetPointZ() + findfront2.GetPointZ() + findfront3.GetPointZ() + findfront4.GetPointZ();
            findfront1 = new PlaceIn2D(cube[25].GetPoints()[6], rotation, FOV);
            findfront2 = new PlaceIn2D(cube[23].GetPoints()[7], rotation, FOV);
            findfront3 = new PlaceIn2D(cube[6].GetPoints()[3], rotation, FOV);
            findfront4 = new PlaceIn2D(cube[8].GetPoints()[2], rotation, FOV);
            double greenZ = findfront1.GetPointZ() + findfront2.GetPointZ() + findfront3.GetPointZ() + findfront4.GetPointZ();
            findfront1 = new PlaceIn2D(cube[19].GetPoints()[5], rotation, FOV);
            findfront2 = new PlaceIn2D(cube[2].GetPoints()[1], rotation, FOV);
            findfront3 = new PlaceIn2D(cube[25].GetPoints()[6], rotation, FOV);
            findfront4 = new PlaceIn2D(cube[8].GetPoints()[2], rotation, FOV);
            double orangeZ = findfront1.GetPointZ() + findfront2.GetPointZ() + findfront3.GetPointZ() + findfront4.GetPointZ();
            findfront1 = new PlaceIn2D(cube[19].GetPoints()[5], rotation, FOV);
            findfront2 = new PlaceIn2D(cube[25].GetPoints()[6], rotation, FOV);
            findfront3 = new PlaceIn2D(cube[17].GetPoints()[4], rotation, FOV);
            findfront4 = new PlaceIn2D(cube[23].GetPoints()[7], rotation, FOV);
            double yellowZ = findfront1.GetPointZ() + findfront2.GetPointZ() + findfront3.GetPointZ() + findfront4.GetPointZ();

            double[] arr = new double[6] { whiteZ, redZ, blueZ, greenZ, orangeZ, yellowZ };
            if (whiteZ == arr.Min())
            {
                ff = "white";
            }
            else if (redZ == arr.Min())
            {
                ff = "red";
            }
            else if (orangeZ == arr.Min())
            {
                ff = "orange";
            }
            else if (blueZ == arr.Min())
            {
                ff = "blue";
            }
            else if (greenZ == arr.Min())
            {
                ff = "green";
            }
            else if (yellowZ == arr.Min())
            {
                ff = "yellow";
            }
            return ff;
        }

        private void CreateLeftSide(Point[] s1, Point[] s2, Point[] s3, Point[] s5)
        {
            using (Pen p = new Pen(Color.Black, 5))
            {
                switch (FrontFace)
                {
                    case "blue":
                        CreateYellowSide(s3, p);
                        break;
                    case "yellow":
                        CreateGreenSide(s5, p);
                        break;
                    case "green":
                        CreateWhiteSide(s1, p);
                        break;
                    default:
                        CreateBlueSide(s2, p);
                        break;
                }
            }
        }
        private void CreateUpSide(Point[] s1, Point[] s3, Point[] s4)
        {
            using (Pen p = new Pen(Color.Black, 5))
            {
                switch (FrontFace)
                {
                    case "red":
                        CreateYellowSide(s3, p);
                        break;
                    case "orange":
                        CreateWhiteSide(s1, p);
                        break;
                    default:
                        CreateRedSide(s4, p);
                        break;
                }
            }
        }
        private void CreateDownSide(Point[] s1, Point[] s3, Point[] s6)
        {
            using (Pen p = new Pen(Color.Black, 5))
            {
                switch (FrontFace)
                {
                    case "orange":
                        CreateYellowSide(s3, p);
                        break;
                    case "red":
                        CreateWhiteSide(s1, p);
                        break;
                    default:
                        CreateOrangeSide(s6, p);
                        break;
                }
            }
        }
        private void CreateRightSide(Point[] s1, Point[] s2, Point[] s3, Point[] s5)
        {
            using (Pen p = new Pen(Color.Black, 5))
            {
                switch (FrontFace)
                {
                    case "blue":
                        CreateWhiteSide(s1, p);
                        break;
                    case "yellow":
                        CreateBlueSide(s2, p);
                        break;
                    case "green":
                        CreateYellowSide(s3, p);
                        break;
                    default:
                        CreateGreenSide(s5, p);
                        break;
                }
            }
        }

        private void CreateFrontSide(Point[] s1, Point[] s2, Point[] s3, Point[] s4, Point[] s5, Point[] s6)
        {
            using (Pen p = new Pen(Color.Black, 5))
            {
                switch (FrontFace)
                {
                    case "blue":
                        CreateBlueSide(s2, p);
                        break;
                    case "yellow":
                        CreateYellowSide(s3, p);
                        break;
                    case "green":
                        CreateGreenSide(s5, p);
                        break;
                    case "white":
                        CreateWhiteSide(s1, p);
                        break;
                    case "red":
                        CreateRedSide(s4, p);
                        break;
                    case "orange":
                        CreateOrangeSide(s6, p);
                        break;
                }
            }
        }

        public void Draw()
        {
            PlaceIn2D c1 = new PlaceIn2D(points[0], rotation, FOV);
            PlaceIn2D c2 = new PlaceIn2D(points[1], rotation, FOV);
            PlaceIn2D c3 = new PlaceIn2D(points[2], rotation, FOV);
            PlaceIn2D c4 = new PlaceIn2D(points[3], rotation, FOV);
            PlaceIn2D c5 = new PlaceIn2D(points[4], rotation, FOV);
            PlaceIn2D c6 = new PlaceIn2D(points[5], rotation, FOV);
            PlaceIn2D c7 = new PlaceIn2D(points[6], rotation, FOV);
            PlaceIn2D c8 = new PlaceIn2D(points[7], rotation, FOV);

            Point[] x = new Point[8]{ new Point(c1.GetPointX(), c1.GetPointY()), new Point(c2.GetPointX()
                , c2.GetPointY()), new Point(c3.GetPointX(), c3.GetPointY()), new Point(c4.GetPointX()
                , c4.GetPointY()), new Point(c5.GetPointX(), c5.GetPointY()), new Point(c6.GetPointX()
                , c6.GetPointY()), new Point(c7.GetPointX(), c7.GetPointY()), new Point(c8.GetPointX()
                , c8.GetPointY()) };
            Point[] s1 = new Point[4] { x[0], x[1], x[2], x[3] };
            Point[] s2 = new Point[4] { x[0], x[1], x[5], x[4] };
            Point[] s3 = new Point[4] { x[6], x[7], x[4], x[5] };
            Point[] s4 = new Point[4] { x[0], x[4], x[7], x[3] };
            Point[] s5 = new Point[4] { x[3], x[7], x[6], x[2] };
            Point[] s6 = new Point[4] { x[2], x[6], x[5], x[1] };
            //Rectangle s1 = new Rectangle(x[0], Size);

            if (CubeNumber == 0)
            {
                FrontFace = FindFrontFace();
            }

            using (Pen p = new Pen(Color.Black, 5))
            {
                Point3D posw;
                Point3D posr;
                Point3D poso;
                Point3D posg;
                Point3D posb;
                Point3D posy;


                Point3D position = cube[0].GetPoints()[0];
                PlaceIn2D c = new PlaceIn2D(position, rotation, FOV);
                posw.x = c.GetPointX(); posw.y = c.GetPointY(); posw.z = c.GetPointZ();
                position = cube[8].GetPoints()[2];
                c = new PlaceIn2D(position, rotation, FOV);
                posw.x = (c.GetPointX() - posw.x) / 2 + posw.x; posw.y = (c.GetPointY() - posw.y) / 2 + posw.y; posw.z = (c.GetPointZ() - posw.z) / 2 + posw.z;

                position = cube[17].GetPoints()[4];
                c = new PlaceIn2D(position, rotation, FOV);
                posb.x = c.GetPointX(); posb.y = c.GetPointY(); posb.z = c.GetPointZ();
                position = cube[2].GetPoints()[1];
                c = new PlaceIn2D(position, rotation, FOV);
                posb.x = (c.GetPointX() - posb.x) / 2 + posb.x; posb.y = (c.GetPointY() - posb.y) / 2 + posb.y; posb.z = (c.GetPointZ() - posb.z) / 2 + posb.z;

                position = cube[6].GetPoints()[3];
                c = new PlaceIn2D(position, rotation, FOV);
                posg.x = c.GetPointX(); posg.y = c.GetPointY(); posg.z = c.GetPointZ();
                position = cube[25].GetPoints()[6];
                c = new PlaceIn2D(position, rotation, FOV);
                posg.x = (c.GetPointX() - posg.x) / 2 + posg.x; posg.y = (c.GetPointY() - posg.y) / 2 + posg.y; posg.z = (c.GetPointZ() - posg.z) / 2 + posg.z;

                position = cube[2].GetPoints()[1];
                c = new PlaceIn2D(position, rotation, FOV);
                poso.x = c.GetPointX(); poso.y = c.GetPointY(); poso.z = c.GetPointZ();
                position = cube[25].GetPoints()[6];
                c = new PlaceIn2D(position, rotation, FOV);
                poso.x = (c.GetPointX() - poso.x) / 2 + poso.x; poso.y = (c.GetPointY() - poso.y) / 2 + poso.y; poso.z = (c.GetPointZ() - poso.z) / 2 + poso.z;

                position = cube[6].GetPoints()[3];
                c = new PlaceIn2D(position, rotation, FOV);
                posr.x = c.GetPointX(); posr.y = c.GetPointY(); posr.z = c.GetPointZ();
                position = cube[17].GetPoints()[4];
                c = new PlaceIn2D(position, rotation, FOV);
                posr.x = (c.GetPointX() - posr.x) / 2 + posr.x - 130; posr.y = (c.GetPointY() - posr.y) / 2 + posr.y - 130; posr.z = (c.GetPointZ() - posr.z) / 2 + posr.z;

                position = cube[23].GetPoints()[7];
                c = new PlaceIn2D(position, rotation, FOV);
                posy.x = c.GetPointX(); posy.y = c.GetPointY(); posy.z = c.GetPointZ();
                position = cube[19].GetPoints()[5];
                c = new PlaceIn2D(position, rotation, FOV);
                posy.x = (c.GetPointX() - posy.x) / 2 + posy.x; posy.y = (c.GetPointY() - posy.y) / 2 + posy.y; posy.z = (c.GetPointZ() - posy.z) / 2 + posy.z;

                List<double> findMin = new List<double> { posw.z, posb.z, posg.z, poso.z, posr.z, posy.z };
                for(int i = 0; i < 3; i++)
                {
                    double min = findMin.Min();
                    findMin.Remove(min);

                    if (min == posw.z)
                    {
                        CreateWhiteSide(s1, p);
                    }
                    else if(min == posb.z)
                    {
                        CreateBlueSide(s2, p);
                    }
                    else if (min == posr.z)
                    {
                        CreateRedSide(s4, p);
                    }
                    else if (min == poso.z)
                    {
                        CreateOrangeSide(s6, p);
                    }
                    else if (min == posg.z)
                    {
                        CreateGreenSide(s5, p);
                    }
                    else if (min == posy.z)
                    {
                        CreateYellowSide(s3, p);
                    }
                }
                


                //CreateBlueSide(s2, p);
                //CreateYellowSide(s3, p);
                //CreateGreenSide(s5, p);
                //CreateWhiteSide(s1, p);
                //CreateRedSide(s4, p);
                //CreateOrangeSide(s6, p);


                Console.WriteLine(posw.z + "white");
                Console.WriteLine(posb.z + "blue");
                Console.WriteLine(posr.z + "red");
                Console.WriteLine(poso.z + "orange");
                Console.WriteLine(posg.z + "green");
                Console.WriteLine(posy.z + "yellow");
                //CreateFrontSide(s1, s2, s3, s4, s5, s6);
                //CreateLeftSide(s1, s2, s3, s5);
                //CreateRightSide(s1, s2, s3, s5);
                //CreateUpSide(s1, s3, s4);
                //CreateDownSide(s1, s3, s6);

            }
        }

        private Color GetColour(int number, string c)
        {
            Color Colour = Color.Blue;
            char col = 'w';
            if (c == "white")
            {
                col = CubeFaces[0, number / 3, number % 3];
            }
            else if (c == "red")
            {
                int x = (number % 9) / 3;
                int y = number / 9;
                if (y == 0)
                {
                    y = 2;
                }
                else if (y == 2)
                {
                    y = 0;
                }
                col = CubeFaces[1, x, y];
            }
            else if (c == "orange")
            {
                number -= 2;
                int x = (number % 9) / 3;
                col = CubeFaces[3, x, number / 9];
            }
            else if (c == "blue")
            {
                int x = number / 9;
                if (x == 0)
                {
                    x = 2;
                }
                else if (x == 2)
                {
                    x = 0;
                }
                col = CubeFaces[4, x, number % 3];
            }
            else if (c == "green")
            {
                col = CubeFaces[2, number / 9, number % 3];
            }
            else if (c == "yellow")
            {
                number -= 18;
                int x = number / 3;
                if (x == 0)
                {
                    x = 2;
                }
                else if (x == 2)
                {
                    x = 0;
                }

                col = CubeFaces[5, x, number % 3];
            }

            switch (col)
            {
                case 'w':
                    Colour = Color.White;
                    break;
                case 'b':
                    Colour = Color.Blue;
                    break;
                case 'r':
                    Colour = Color.Red;
                    break;
                case 'g':
                    Colour = Color.Green;
                    break;
                case 'o':
                    Colour = Color.Orange;
                    break;
                case 'y':
                    Colour = Color.Yellow;
                    break;
            }
            return Colour;
        }
        Color Colour;
        private void CreateWhiteSide(Point[] s, Pen p)
        {
            if (CubeNumber / 9 == 0)
            {
                Colour = GetColour(CubeNumber, "white");
                G.DrawPolygon(p, s);
                G.FillPolygon(new SolidBrush(Colour), s);
            }

        }
        private void CreateBlueSide(Point[] s, Pen p)
        {
            if (CubeNumber == 0 || CubeNumber == 1 || CubeNumber == 2 || CubeNumber == 9 || CubeNumber == 10 || CubeNumber == 11 || CubeNumber == 18 || CubeNumber == 19 || CubeNumber == 20)
            {
                Colour = GetColour(CubeNumber, "blue");
                G.DrawPolygon(p, s);
                G.FillPolygon(new SolidBrush(Colour), s);
            }

        }
        private void CreateYellowSide(Point[] s, Pen p)
        {
            if (CubeNumber / 9 == 2)
            {
                Colour = GetColour(CubeNumber, "yellow");
                G.DrawPolygon(p, s);
                G.FillPolygon(new SolidBrush(Colour), s);
            }

        }
        private void CreateRedSide(Point[] s, Pen p)
        {
            if (CubeNumber % 3 == 0)
            {
                Colour = GetColour(CubeNumber, "red");
                G.DrawPolygon(p, s);
                G.FillPolygon(new SolidBrush(Colour), s);
            }

        }
        private void CreateGreenSide(Point[] s, Pen p)
        {
            if (CubeNumber == 6 || CubeNumber == 7 || CubeNumber == 8 || CubeNumber == 15 || CubeNumber == 16 || CubeNumber == 17 || CubeNumber == 24 || CubeNumber == 25 || CubeNumber == 26)
            {
                Colour = GetColour(CubeNumber, "green");
                G.DrawPolygon(p, s);
                G.FillPolygon(new SolidBrush(Colour), s);
            }

        }
        private void CreateOrangeSide(Point[] s, Pen p)
        {
            if (CubeNumber % 3 == 2)
            {
                Colour = GetColour(CubeNumber, "orange");
                G.DrawPolygon(p, s);
                G.FillPolygon(new SolidBrush(Colour), s);
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Down = true;
            coords = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Down = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Down)
            {
                int x = e.Location.X - coords.X;
                int y = e.Location.Y - coords.Y;
                rotation.y -= x % 0.11;
                rotation.x += y % 0.11;
                coords = e.Location;
                Invalidate(rec);
            }
        }

        private async void Shuffle()
        {
            int n;
            Random rnd = new Random();
            for(int i = 0; i < 50; i++)
            {
                n = rnd.Next(0, 5);
                switch (n)
                {
                    case 0:
                        CubeFaces = Rotations.U(1, CubeFaces);
                        break;
                    case 1:
                        CubeFaces = Rotations.F(1, CubeFaces);
                        break;
                    case 2:
                        CubeFaces = Rotations.B(1, CubeFaces);
                        break;
                    case 3:
                        CubeFaces = Rotations.D(1, CubeFaces);
                        break;
                    case 4:
                        CubeFaces = Rotations.R(1, CubeFaces);
                        break;
                    case 5:
                        CubeFaces = Rotations.L(1, CubeFaces);
                        break;
                }
                await Task.Delay(20);
                Invalidate();
            }         
        }
        private void Display3D_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'l')
            {
                CubeFaces = Rotations.L(1, CubeFaces);
                Invalidate(rec);
            }
            else if (e.KeyChar == 'r')
            {
                CubeFaces = Rotations.R(1, CubeFaces);
                Invalidate(rec);
            }
            else if (e.KeyChar == 'u')
            {
                CubeFaces = Rotations.U(1, CubeFaces);
                Invalidate(rec);
            }
            else if (e.KeyChar == 'd')
            {
                CubeFaces = Rotations.D(1, CubeFaces);
                Invalidate(rec);
            }
            else if (e.KeyChar == 'f')
            {
                CubeFaces = Rotations.F(1, CubeFaces);
                Invalidate(rec);
            }
            else if (e.KeyChar == 'b')
            {
                CubeFaces = Rotations.B(1, CubeFaces);
                Invalidate(rec);
            }
            else if(e.KeyChar == 's')
            {
                Shuffle();
            }
            else if(e.KeyChar == 'S')
            {
                Solve();
            }
            else if(e.KeyChar == 'm')
            {
                this.Hide();
            }
        }

        private async void Solve()
        {
            Rotations.SaveCubeToFile(CubeFaces, "cubesave.txt");
            SolveCube solve = new SolveCube(CubeFaces);
            while (solve.NotSolved())
            {
                solve.WhiteCross();
                solve.WhiteCorners();
                solve.SlotSecondLayer();
                solve.MakeYellowCross();
                solve.MatchUpColours();
                solve.MoveTopCorners();
                solve.TwistCorners();
            }
            MoveList = solve.GetMoveList();
            n = true;
            MoveNumber = 0;
            for (int i = 0; i <= MoveList.Count(); i++)
            {
                DisplayNextMove();
                MoveNumber = i;
                await Task.Delay(10);
            }
        }

        private void UpdateLabels()
        {
            if (MoveNumber > 0)
            {
                LastMove.Text = MoveList[MoveNumber - 1];
            }
            else
            {
                LastMove.Text = " ";
            }
            CurrentMove.Text = MoveList[MoveNumber];
            if (MoveNumber == MoveList.Count() - 1)
            {
                NextMove.Text = " ";
            }
            else
            {
                NextMove.Text = MoveList[MoveNumber + 1];
            }
        }

        private void DisplayNextMove()
        {
            try   // must be in a try as if the user tries to solve the cube when it is solved then the movenumber index will be too high
            {
                switch (MoveList[MoveNumber])
                {
                    case "L":
                        CubeFaces = Rotations.L(1, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "R":
                        CubeFaces = Rotations.R(1, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "B":
                        CubeFaces = Rotations.B(1, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "F":
                        CubeFaces = Rotations.F(1, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "D":
                        CubeFaces = Rotations.D(1, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "U":
                        CubeFaces = Rotations.U(1, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "L'":
                        CubeFaces = Rotations.L(3, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "R'":
                        CubeFaces = Rotations.R(3, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "B'":
                        CubeFaces = Rotations.B(3, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "F'":
                        CubeFaces = Rotations.F(3, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "D'":
                        CubeFaces = Rotations.D(3, CubeFaces);
                        Invalidate(rec);
                        break;
                    case "U'":
                        CubeFaces = Rotations.U(3, CubeFaces);
                        Invalidate(rec);
                        break;
                }

            }
            catch (Exception) { }
            
        }
        private void DisplayLastMove()
        {
            switch (MoveList[MoveNumber])
            {
                case "L":
                    CubeFaces = Rotations.L(3, CubeFaces);
                    Invalidate(rec);
                    break;
                case "R":
                    CubeFaces = Rotations.R(3, CubeFaces);
                    Invalidate(rec);
                    break;
                case "B":
                    CubeFaces = Rotations.B(3, CubeFaces);
                    Invalidate(rec);
                    break;
                case "F":
                    CubeFaces = Rotations.F(3, CubeFaces);
                    Invalidate(rec);
                    break;
                case "D":
                    CubeFaces = Rotations.D(3, CubeFaces);
                    Invalidate(rec);
                    break;
                case "U":
                    CubeFaces = Rotations.U(3, CubeFaces);
                    Invalidate(rec);
                    break;
                case "L'":
                    CubeFaces = Rotations.L(1, CubeFaces);
                    Invalidate(rec);
                    break;
                case "R'":
                    CubeFaces = Rotations.R(1, CubeFaces);
                    Invalidate(rec);
                    break;
                case "B'":
                    CubeFaces = Rotations.B(1, CubeFaces);
                    Invalidate(rec);
                    break;
                case "F'":
                    CubeFaces = Rotations.F(1, CubeFaces);
                    Invalidate(rec);
                    break;
                case "D'":
                    CubeFaces = Rotations.D(1, CubeFaces);
                    Invalidate(rec);
                    break;
                case "U'":
                    CubeFaces = Rotations.U(1, CubeFaces);
                    Invalidate(rec);
                    break;
            }
        }
        private void LastMove_Click(object sender, EventArgs e)
        {
            if (MoveNumber != 0)
            {
                if (next)
                {
                    next = false;
                    DisplayLastMove();
                }
                last = true;
                MoveNumber--;
                UpdateLabels();
                DisplayLastMove();
            }
            else
            {
                MessageBox.Show("You have reached the first move");
            }
        }

        private void NextMove_Click(object sender, EventArgs e)
        {
            if (MoveNumber < MoveList.Count() - 1)
            {
                if (last)
                {
                    last = false;
                    DisplayNextMove();
                }
                next = true;
                MoveNumber++;
                UpdateLabels();
                DisplayNextMove();
            }
            else
            {
                MessageBox.Show("You have reached the final move");
            }
        }

        private void FOVslider_Scroll(object sender, EventArgs e)
        {
            FOV = FOVslider.Value;
            FOVlable.Text = "FOV : " + FOV;
            Invalidate(rec);
        }

        private string GetSimplifiedMoveset()
        {
            string simpleMoveset = "";
            List<string> MoveSet = new List<string>();

            for(int i = 0; i < MoveList.Count; i++)
            {
                try
                {
                    if (MoveList[i] == MoveList[i+1] && MoveList[i + 1] == MoveList[i + 2] && MoveList[i + 2] == MoveList[i + 3])
                    {
                        i += 3;
                    }
                    else if (MoveList[i] == MoveList[i + 1])
                    {
                        MoveSet.Add(MoveList[i] + "2");
                        i++;
                    }
                    else if (MoveList[i] == MoveList[i + 1] + "'") { i++; }
                    else if(MoveList[i] + "'" == MoveList[i + 1]) { i++; }
                    else
                    {
                        MoveSet.Add(MoveList[i]);
                    }
                }
                catch (Exception) { }
                
            }
            for (int i = 0; i < MoveSet.Count; i++)
            {
                simpleMoveset += MoveSet[i] + ", ";
            }

            return simpleMoveset;
        }

        private void SaveCube(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void CloseClick(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void InputData(object sender, EventArgs e)
        {
            if(PassText.Text == RePassText.Text && FileText.Text != "" && UserText.Text != "" && PassText.Text != "")
            {
                string username = UserText.Text;
                string password = RePassText.Text;
                string filename = FileText.Text;

                DataBase db = new DataBase(username, password, filename, CubeFaces);
            }
            else
            {
                MessageBox.Show("Password and re entered password do not match or you have black fields");
            }
            
        }
        private void ShowMovesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetSimplifiedMoveset());
        }
    }
}
