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

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int total = Int32.Parse(lblTotal.Text);
            int current = Int32.Parse(txtInput.Text);
            lblTotal.Text = Calc.Add(total, current).ToString();
            UpdateStack();
        }

        private void UpdateStack ()
        {
            string textToDisplay = "teste";
            foreach(string elem in Calc.Stack)
            {
                textToDisplay += elem;
            }
            lblStack.Text = textToDisplay;
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            int total = Int32.Parse(lblTotal.Text);
            int current = Int32.Parse(txtInput.Text);
            lblTotal.Text = Calc.Sub(total, current).ToString();
            UpdateStack();
        }

        private void btnMult_Click(object sender, EventArgs e)
        {

        }
    }
}
