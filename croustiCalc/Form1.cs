using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace croustiCalc
{
    public partial class croustiCalc : Form
    {
        Double dResultValue = 0;
        String sOperator = "";
        Boolean bOperationPressed = false;

        public croustiCalc()
        {
            InitializeComponent();
        }

        private void supBtn_Click(object sender, EventArgs e)
        {
            resultTxtBox.Text = "0";
            histoTxtBox.Text = "";
            bOperationPressed = false;
            sOperator = "";
            dResultValue = 0;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button oButtonSelected = (Button)sender;

            if ((resultTxtBox.Text == "0") || (bOperationPressed == true))
            {
                resultTxtBox.Text = "";
            }

            resultTxtBox.Text += oButtonSelected.Text;
            bOperationPressed = false;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button oButtonSelected = (Button)sender;
            String sNewOperator = "";

            sNewOperator = oButtonSelected.Text;
            dResultValue = Double.Parse(resultTxtBox.Text);

            // Inscription dans l'historique
            if (sOperator != "=")
            {
                histoTxtBox.Text += resultTxtBox.Text + " " + sNewOperator + " ";
            } else
            {
                histoTxtBox.Text += " " + sNewOperator + " ";
            }
                        
            sOperator = sNewOperator;
            bOperationPressed = true;
        }

        private void equalBtn_Click(object sender, EventArgs e)
        {
            histoTxtBox.Text += resultTxtBox.Text;

            switch (sOperator)
            {
                case "+":
                    resultTxtBox.Text = (dResultValue + Double.Parse(resultTxtBox.Text)).ToString();
                    break;

                case "-":
                    resultTxtBox.Text = (dResultValue - Double.Parse(resultTxtBox.Text)).ToString();
                    break;

                case "*":
                    resultTxtBox.Text = (dResultValue * Double.Parse(resultTxtBox.Text)).ToString();
                    break;

                case "/":
                    resultTxtBox.Text = (dResultValue / Double.Parse(resultTxtBox.Text)).ToString();
                    break;

                default:
                    break;

            } // End switch

            sOperator = "=";
            bOperationPressed = false;
            
        }
    }
}
