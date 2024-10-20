using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projecto1
{
    public partial class Form1 : Form
    {
        // Instancia de la calculadora
        Calculadora calc = new Calculadora();

        public Form1()
        {
            InitializeComponent();
            lblPeticion.Text = "";
            lblCalculo.Text = "";
            lblResultado.Text = "";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "0";
            lblResultado.Text = "";
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "1";
            lblResultado.Text = "";
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "2";
            lblResultado.Text = "";
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "3";
            lblResultado.Text = "";
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "4";
            lblResultado.Text = "";
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "5";
            lblResultado.Text = "";
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "6";
            lblResultado.Text = "";
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "7";
            lblResultado.Text = "";
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "8";
            lblResultado.Text = "";
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "9";
            lblResultado.Text = "";
        }
        private void btnPunto_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += ".";
            lblResultado.Text = "";
        }
        private void btnAbrirParent_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "(";
            lblResultado.Text = "";
        }
        private void btnCerrarParent_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += ")";
            lblResultado.Text = "";
        }
        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "*";
            lblResultado.Text = "";
        }
        private void btnDivision_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "/";
            lblResultado.Text = "";
        }
        private void btnSuma_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "+";
            lblResultado.Text = "";
        }
        private void btnResta_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "-";
            lblResultado.Text = "";
        }
        private void btnRaiz_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "sqrt(";
            lblResultado.Text = "";
        }
        private void btnLog_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "log(";
            lblResultado.Text = "";
        }
        private void btnLn_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "ln(";
            lblResultado.Text = "";
        }
        private void btnPotencia_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "^";
            lblResultado.Text = "";
        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            lblPeticion.Text = "";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblPeticion.Text = "";
            lblCalculo.Text = "";
            lblResultado.Text = "";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            lblResultado.Text = calc.Evaluate(lblPeticion.Text).ToString();
            lblCalculo.Text = lblPeticion.Text;
            lblPeticion.Text = "";
            calc.setAns(lblResultado.Text);
        }

        private void btnAns_Click(object sender, EventArgs e)
        {
            lblPeticion.Text += "Ans";
            lblResultado.Text = "";
        }
    }
    }

