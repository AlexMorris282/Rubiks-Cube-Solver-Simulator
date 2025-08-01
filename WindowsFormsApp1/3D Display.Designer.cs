
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Display3D
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent(bool n)
        {
            this.SaveCubeButton = new System.Windows.Forms.Button();
            this.NextMoveBtn = new System.Windows.Forms.Button();
            this.LastMoveBtn = new System.Windows.Forms.Button();
            this.CurrentMove = new System.Windows.Forms.Label();
            this.NextMove = new System.Windows.Forms.Label();
            this.LastMove = new System.Windows.Forms.Label();
            this.FOVslider = new System.Windows.Forms.TrackBar();
            this.FOVlable = new System.Windows.Forms.Label();
            this.ShowMovesButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CreateSavelbl = new System.Windows.Forms.Label();
            this.Userlbl = new System.Windows.Forms.Label();
            this.Passwordlbl = new System.Windows.Forms.Label();
            this.RePasslbl = new System.Windows.Forms.Label();
            this.Filelbl = new System.Windows.Forms.Label();
            this.UserText = new System.Windows.Forms.TextBox();
            this.PassText = new System.Windows.Forms.TextBox();
            this.RePassText = new System.Windows.Forms.TextBox();
            this.FileText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FOVslider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            // SaveButton
            //
            this.SaveCubeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveCubeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCubeButton.Location = new System.Drawing.Point(1022, 600);
            this.SaveCubeButton.Name = "NextMoveBtn";
            this.SaveCubeButton.Size = new System.Drawing.Size(126, 125);
            this.SaveCubeButton.TabIndex = 8;
            this.SaveCubeButton.Text = "Save Cube";
            this.SaveCubeButton.UseVisualStyleBackColor = true;
            this.SaveCubeButton.Click += new System.EventHandler(this.SaveCube);
            // 
            // NextMoveBtn
            // 
            this.NextMoveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextMoveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextMoveBtn.Location = new System.Drawing.Point(1022, 284);
            this.NextMoveBtn.Name = "NextMoveBtn";
            this.NextMoveBtn.Size = new System.Drawing.Size(126, 125);
            this.NextMoveBtn.TabIndex = 0;
            this.NextMoveBtn.Text = "Next Move";
            this.NextMoveBtn.UseVisualStyleBackColor = true;
            this.NextMoveBtn.Click += new System.EventHandler(this.NextMove_Click);
            // 
            // LastMoveBtn
            // 
            this.LastMoveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LastMoveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastMoveBtn.Location = new System.Drawing.Point(45, 284);
            this.LastMoveBtn.Name = "LastMoveBtn";
            this.LastMoveBtn.Size = new System.Drawing.Size(126, 125);
            this.LastMoveBtn.TabIndex = 1;
            this.LastMoveBtn.Text = "Last Move";
            this.LastMoveBtn.UseVisualStyleBackColor = true;
            this.LastMoveBtn.Click += new System.EventHandler(this.LastMove_Click);
            // 
            // CurrentMove
            // 
            this.CurrentMove.AutoSize = true;
            this.CurrentMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentMove.Location = new System.Drawing.Point(568, 30);
            this.CurrentMove.Name = "CurrentMove";
            this.CurrentMove.Size = new System.Drawing.Size(46, 69);
            this.CurrentMove.TabIndex = 2;
            this.CurrentMove.Text = " ";
            // 
            // NextMove
            // 
            this.NextMove.AutoSize = true;
            this.NextMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextMove.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.NextMove.Location = new System.Drawing.Point(654, 30);
            this.NextMove.Name = "NextMove";
            this.NextMove.Size = new System.Drawing.Size(46, 69);
            this.NextMove.TabIndex = 3;
            this.NextMove.Text = " ";
            // 
            // LastMove
            // 
            this.LastMove.AutoSize = true;
            this.LastMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastMove.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.LastMove.Location = new System.Drawing.Point(465, 30);
            this.LastMove.Name = "LastMove";
            this.LastMove.Size = new System.Drawing.Size(46, 69);
            this.LastMove.TabIndex = 4;
            this.LastMove.Text = " ";
            // 
            // FOVslider
            // 
            this.FOVslider.Location = new System.Drawing.Point(332, 698);
            this.FOVslider.Maximum = 100;
            this.FOVslider.Minimum = 10;
            this.FOVslider.Name = "FOVslider";
            this.FOVslider.Size = new System.Drawing.Size(291, 56);
            this.FOVslider.TabIndex = 5;
            this.FOVslider.Value = 45;
            this.FOVslider.Scroll += new System.EventHandler(this.FOVslider_Scroll);
            // 
            // FOVlable
            // 
            this.FOVlable.AutoSize = true;
            this.FOVlable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FOVlable.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FOVlable.Location = new System.Drawing.Point(701, 698);
            this.FOVlable.Name = "FOVlable";
            this.FOVlable.Size = new System.Drawing.Size(134, 36);
            this.FOVlable.TabIndex = 6;
            this.FOVlable.Text = "FOV : 45";
            // 
            // ShowMovesButton
            // 
            this.ShowMovesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowMovesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowMovesButton.Location = new System.Drawing.Point(1061, 12);
            this.ShowMovesButton.Name = "ShowMovesButton";
            this.ShowMovesButton.Size = new System.Drawing.Size(109, 34);
            this.ShowMovesButton.TabIndex = 7;
            this.ShowMovesButton.Text = "Moveset";
            this.ShowMovesButton.UseVisualStyleBackColor = true;
            this.ShowMovesButton.Click += new System.EventHandler(this.ShowMovesButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.FileText);
            this.groupBox1.Controls.Add(this.RePassText);
            this.groupBox1.Controls.Add(this.PassText);
            this.groupBox1.Controls.Add(this.UserText);
            this.groupBox1.Controls.Add(this.Filelbl);
            this.groupBox1.Controls.Add(this.RePasslbl);
            this.groupBox1.Controls.Add(this.Passwordlbl);
            this.groupBox1.Controls.Add(this.Userlbl);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.CreateSavelbl);
            this.groupBox1.Location = new System.Drawing.Point(300, 150);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(644, 482);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Help";
            this.groupBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(602, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "CloseButton";
            this.button1.Size = new System.Drawing.Size(38, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Click += new System.EventHandler(this.CloseClick);
            // 
            // CreateSavelbl
            // 
            this.CreateSavelbl.AutoSize = true;
            this.CreateSavelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateSavelbl.Location = new System.Drawing.Point(10, 26);
            this.CreateSavelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CreateSavelbl.Name = "CreateSavelbl";
            this.CreateSavelbl.Size = new System.Drawing.Size(229, 44);
            this.CreateSavelbl.TabIndex = 1;
            this.CreateSavelbl.Text = "Create Save";
            // 
            // Userlbl
            // 
            this.Userlbl.AutoSize = true;
            this.Userlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Userlbl.Location = new System.Drawing.Point(52, 98);
            this.Userlbl.Name = "Userlbl";
            this.Userlbl.Size = new System.Drawing.Size(85, 20);
            this.Userlbl.TabIndex = 5;
            this.Userlbl.Text = "UserName";
            // 
            // Passwordlbl
            // 
            this.Passwordlbl.AutoSize = true;
            this.Passwordlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passwordlbl.Location = new System.Drawing.Point(52, 172);
            this.Passwordlbl.Name = "Passwordlbl";
            this.Passwordlbl.Size = new System.Drawing.Size(78, 20);
            this.Passwordlbl.TabIndex = 6;
            this.Passwordlbl.Text = "Password";
            // 
            // RePasslbl
            // 
            this.RePasslbl.AutoSize = true;
            this.RePasslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RePasslbl.Location = new System.Drawing.Point(49, 256);
            this.RePasslbl.Name = "RePasslbl";
            this.RePasslbl.Size = new System.Drawing.Size(147, 20);
            this.RePasslbl.TabIndex = 7;
            this.RePasslbl.Text = "Re-Enter Password";
            // 
            // Filelbl
            // 
            this.Filelbl.AutoSize = true;
            this.Filelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filelbl.Location = new System.Drawing.Point(49, 340);
            this.Filelbl.Name = "Filelbl";
            this.Filelbl.Size = new System.Drawing.Size(80, 20);
            this.Filelbl.TabIndex = 8;
            this.Filelbl.Text = "File Name";
            // 
            // UserText
            // 
            this.UserText.Location = new System.Drawing.Point(53, 136);
            this.UserText.Name = "UserText";
            this.UserText.Size = new System.Drawing.Size(231, 20);
            this.UserText.TabIndex = 9;
            // 
            // PassText
            // 
            this.PassText.Location = new System.Drawing.Point(53, 220);
            this.PassText.Name = "PassText";
            this.PassText.Size = new System.Drawing.Size(231, 20);
            this.PassText.TabIndex = 10;
            // 
            // RePassText
            // 
            this.RePassText.Location = new System.Drawing.Point(53, 295);
            this.RePassText.Name = "RePassText";
            this.RePassText.Size = new System.Drawing.Size(231, 20);
            this.RePassText.TabIndex = 11;
            // 
            // FileText
            // 
            this.FileText.Location = new System.Drawing.Point(53, 388);
            this.FileText.Name = "FileText";
            this.FileText.Size = new System.Drawing.Size(231, 20);
            this.FileText.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(486, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 48);
            this.button2.TabIndex = 13;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.InputData);
            // 
            // Display3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 753);

            if (n)
            {
                this.Controls.Add(this.ShowMovesButton);
                this.Controls.Add(this.FOVlable);
                this.Controls.Add(this.FOVslider);
                this.Controls.Add(this.LastMove);
                this.Controls.Add(this.NextMove);
                this.Controls.Add(this.CurrentMove);
                this.Controls.Add(this.LastMoveBtn);
                this.Controls.Add(this.NextMoveBtn);
                this.Controls.Add(this.SaveCubeButton);
                this.Controls.Add(this.groupBox1);
            }

            this.DoubleBuffered = true;
            this.Name = "Display3D";
            this.Text = "3D Display";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Display3D_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Display3D_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.FOVslider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion

        private System.Windows.Forms.Button SaveCubeButton;
        private System.Windows.Forms.Button NextMoveBtn;
        private System.Windows.Forms.Button LastMoveBtn;
        private System.Windows.Forms.Label CurrentMove;
        private System.Windows.Forms.Label NextMove;
        private System.Windows.Forms.Label LastMove;
        private System.Windows.Forms.TrackBar FOVslider;
        private System.Windows.Forms.Label FOVlable;
        private System.Windows.Forms.Button ShowMovesButton;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox FileText;
        private System.Windows.Forms.TextBox RePassText;
        private System.Windows.Forms.TextBox PassText;
        private System.Windows.Forms.TextBox UserText;
        private System.Windows.Forms.Label Filelbl;
        private System.Windows.Forms.Label RePasslbl;
        private System.Windows.Forms.Label Passwordlbl;
        private System.Windows.Forms.Label Userlbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CreateSavelbl;
    }
}