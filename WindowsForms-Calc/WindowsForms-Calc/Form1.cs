using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Calc
{
    public partial class Form1 : Form
    {
        public Calc Calculator;
        public double total = 0;
        public double current = 0; // current item being displeyed 

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            total = Double.Parse(lblTotal.Text);
            current = Double.Parse(txtInput.Text);
            lblTotal.Text = Calc.Add(total, current).ToString();            
            UpdateStack();
            ClearInput();
        }        

        private void btnSub_Click(object sender, EventArgs e)
        {
            total = Double.Parse(lblTotal.Text);
            current = Double.Parse(txtInput.Text);
            lblTotal.Text = Calc.Sub(total, current).ToString();
            UpdateStack();
            ClearInput();
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            total = Double.Parse(lblTotal.Text);
            current = Double.Parse(txtInput.Text);
            lblTotal.Text = Calc.Mult(total, current).ToString();
            UpdateStack();
            ClearInput();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            total = Double.Parse(lblTotal.Text);
            current = Double.Parse(txtInput.Text);
            lblTotal.Text = Calc.Divide(total, current).ToString();
            UpdateStack();
            ClearInput();
        }

        private void ClearInput ()
        {
            txtInput.Focus();
            txtInput.Clear();
        }

        private void UpdateStack()
        {
            string textToDisplay = " = ";
            foreach (string elem in Calc.Stack)
            {
                textToDisplay += elem;
            }
            lblStack.Text = textToDisplay;
        }
    }
}
