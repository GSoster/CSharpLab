using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Tic_tac_toe
{
    public partial class Form1 : Form
    {

        public bool isPlayerTurn = true; // player plays as X
        public int[,,] grid = new int [3,3,3];

        public Form1()
        {
            InitializeComponent();
        }

        private bool CheckPlacement(object btn)
        {
            return ((Button)btn).Text == string.Empty;
        }

        private void UpdateUIInfo()
        {
            if (isPlayerTurn)
                lblTurn.Text = "Turn: Player X";
            else
                lblTurn.Text = "Turn: Player O";
        }

        private void DoMove(Button btnClicked)
        {
            if (CheckPlacement(btnClicked))
            {
                if (isPlayerTurn)
                    btnClicked.Text = "X";
                else
                    btnClicked.Text = "O";
                isPlayerTurn = !isPlayerTurn;
            }
            UpdateUIInfo();
        }

        private void btnTopLeft_Click(object sender, EventArgs e)
        {
            if (CheckPlacement(sender))
            {
                if (isPlayerTurn)
                    btnTopLeft.Text = "X";
                else
                    btnTopLeft.Text = "O";
                isPlayerTurn = !isPlayerTurn;
            }
            UpdateUIInfo();
        }
        

        private void btnTopCenter_Click(object sender, EventArgs e)
        {
            DoMove((Button)sender);
        }
    }
}
