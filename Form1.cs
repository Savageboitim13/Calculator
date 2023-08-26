using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    public partial class Form1 : Form {
        private string currentCalculation = "";
        bool isANS = false;

        enum Calc {
            add,
            subtract,
            multiply,
            divide
        }

        public Form1() {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e) {
            string btnName = (sender as Button).Text;

            if (isANS == false) {
                currentCalculation += btnName;
            } else {
                currentCalculation = btnName;
                isANS = false;
            }
            
            richTextBox1.Text = currentCalculation;
        }

        private void Equals_Click(object sender, EventArgs e) {
            try {
                richTextBox1.Text = new DataTable().Compute(currentCalculation, null).ToString();
                currentCalculation = richTextBox1.Text;
                isANS = true;
            } catch (Exception) {
                richTextBox1.Text = "Error : Bzz!";
                currentCalculation = "";
            }
        }

        private void AC_Click(object sender, EventArgs e) {
            richTextBox1.Text = "";
            currentCalculation = "";
        }

        private void DEL_Click(object sender, EventArgs e) {
            if (currentCalculation.Length > 0) {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }

            richTextBox1.Text = currentCalculation;
        }
    }
}
