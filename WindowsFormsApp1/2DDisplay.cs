using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Display : Form
    {
        Cube c1 = new Cube();
        private string Colour = "White";
        private string Coords;
        private string[] CoordsArray;
        private int side;
        private int x;
        private int y;
        public bool simulation = false;

        public Display() // Initialises all parts of the UI so they can be displayed correctly
        {
            InitializeComponent();
            MenuButton.SendToBack();
        }

        private void EnterTile(object sender, EventArgs e)  // when mouse is hovering over a button this will run
        {
            Button b = (Button)sender;  // determines which button has called the function and creates variable b
            b.FlatAppearance.BorderSize = 3;  // increases border size of the button 
        }

        private void LeaveTile(object sender, EventArgs e)  // when mouse stops hovering over a button this will run
        {
            Button b = (Button)sender;  // determines which button has called the function and creates variable b
            b.FlatAppearance.BorderSize = 1;  // resets border size of button
        }

        private void ColourChange(object sender, EventArgs e)
        {
            Button b = (Button)sender;  // determines which paint button has called this function
            Colour = (string)b.Tag;  // sets vaiable colour to the predefined tag of the button which will be a string of a colour name
        }

        private void ChangePieceColour(object sender, EventArgs e)  // function to change color of cubies
        {
            Button b = (Button)sender;  // determines which paint button has called this function

            Coords = ((string)b.Tag);  //determines the coordinates of the button clicked
            CoordsArray = Coords.Split(',');  //splits the string so coordinates can be individually accessed

            side = int.Parse(CoordsArray[0]);  // sets the side, x and z variables to corrosponding coordinate
            x = int.Parse(CoordsArray[1]);
            y = int.Parse(CoordsArray[2]);
            

            switch (Colour)
            {
                case "White":   // if colour = white
                    b.BackColor = Color.White;  // sets button colour
                    c1.ChangeSide(side, x, y, 'w');  // updates 3d array in cube class 
                    break;
                case "Red":
                    b.BackColor = Color.Red;
                    c1.ChangeSide(side, x, y, 'r');  // updates 3d array in cube class 
                    break;
                case "Green":
                    b.BackColor = Color.Green;
                    c1.ChangeSide(side, x, y, 'g');  // updates 3d array in cube class 
                    break;
                case "Orange":
                    b.BackColor = Color.Orange;
                    c1.ChangeSide(side, x, y, 'o');  // updates 3d array in cube class 
                    break;
                case "Blue":
                    b.BackColor = Color.Blue;
                    c1.ChangeSide(side, x, y, 'b');  // updates 3d array in cube class 
                    break;
                case "Yellow":
                    b.BackColor = Color.Yellow;
                    c1.ChangeSide(side, x, y, 'y');  // updates 3d array in cube class 
                    break;
            }
            
        }

        

        private void Solve(object sender, EventArgs e)
        {
            if (c1.SolvableStep1()) // checks if there is 9 of each colour
            {
                if (c1.SolvableStep2())//checks if there is any corner or side piece with 2 of the same colour
                {
                    SolveCube Solve = new SolveCube(c1.GetCubeFaces());  //Creates new instance of Solving class to solve cube    
                    Rotations.SaveCubeToFile(c1.GetCubeFaces(), "cubesave.txt");
                    Display3D CubeDisplaySolve = new Display3D();
                    Solve.WhiteCross();
                    Solve.WhiteCorners();
                    Solve.SlotSecondLayer();  // this goes through all the steps to solve the cube and updates an array and moveset accordingly
                    Solve.MakeYellowCross();
                    Solve.MatchUpColours();
                    Solve.MoveTopCorners();
                    Solve.TwistCorners();
                    bool twisted = Solve.GetTwisted();
                    List<string> MoveList = Solve.GetMoveList();
                    Console.WriteLine("it takes " + MoveList.Count + " moves to solve");
                    CubeDisplaySolve.SetSim(false);  // simulation mode is false so solve mode is true
                    CubeDisplaySolve.SetMoves(MoveList);  //gives movelist over to new oject
                    this.Hide();
                    CubeDisplaySolve.ShowDialog();
                    MenuBox.Visible = true;
                    this.Show();

                }
            }
        }

        private void SolverButton_Click(object sender, EventArgs e)
        {
            MenuBox.Visible = false;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            HelpBox.Visible = true;
        }

        private void SimulationButton_Click(object sender, EventArgs e)
        {
            Display3D CubeDisplaySim = new Display3D();
            CubeDisplaySim.SetSim(true);    // sets simulation to true so the buttons wont appear like they would if in solve mode
            this.Hide();  // hides this form
            CubeDisplaySim.ShowDialog();  // shows 3d form
            this.Show();  // shows this form but only when form above is hidden or closed
            
        }

        private void NextHelpScreen_Click(object sender, EventArgs e)
        {
            if(NextHelpScreen.Text == "Simulation")
            {
                NextHelpScreen.Text = "Solver";
                SolverLabel.Text = "Simulation : ";
                picBox.Image = Image.FromFile("SimRules.JPG");
                picBox.Visible = true;
            }
            else
            {
                NextHelpScreen.Text = "Simulation";
                SolverLabel.Text = "Solver : ";
                picBox.Image = Image.FromFile("FaceRotations.JPG");
                picBox.Visible = true;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            HelpBox.Visible = false;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            MenuBox.Visible = true;
        }
    }
}
