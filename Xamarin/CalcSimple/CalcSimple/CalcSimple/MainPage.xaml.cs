using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CalcSimple.Model;

namespace CalcSimple
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private Decimal _temp = 0;
        private Operation _operation = Operation.Empty;

        private void AddDigit(int digit)
        {
            if (LblResult.Text == "0")
                LblResult.Text = digit.ToString();
            else
                LblResult.Text += digit.ToString();
        }

        private void BtnC_Clicked(object sender, EventArgs e)
        {
            _temp = 0;
            _operation = Operation.Empty;
            LblResult.Text = "0";
        }

        private void BtnDiv_Clicked(object sender, EventArgs e)
        {
            _temp = Decimal.Parse(LblResult.Text);
            LblResult.Text = "0";
            _operation = Operation.Divide;
        }
        private void BtnMult_Clicked(object sender, EventArgs e)
        {
            _temp = Decimal.Parse(LblResult.Text);
            LblResult.Text = "0";
            _operation = Operation.Multiply;
        }
        private void BtnSub_Clicked(object sender, EventArgs e)
        {
            _temp = Decimal.Parse(LblResult.Text);
            LblResult.Text = "0";
            _operation = Operation.Subtract;
        }
        private void BtnSum_Clicked(object sender, EventArgs e)
        {
            _temp = Decimal.Parse(LblResult.Text);
            LblResult.Text = "0";
            _operation = Operation.Add;
        }
        private void BtnEqual_Clicked(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case Operation.Add:
                    LblResult.Text = (Convert.ToDecimal(LblResult.Text) + _temp).ToString();
                    break;
                case Operation.Subtract:
                    LblResult.Text = (Convert.ToDecimal(LblResult.Text) - _temp).ToString();
                    break;
                case Operation.Multiply:
                    LblResult.Text = (Convert.ToDecimal(LblResult.Text) * _temp).ToString();
                    break;
                case Operation.Divide:
                    LblResult.Text = (Convert.ToDecimal(LblResult.Text) / _temp).ToString();
                    break;
            }
            _temp = 0;
            _operation = Operation.Empty;
        }              

        private void BtnZero_Clicked(object sender, EventArgs e)
        {
             AddDigit(0);
        }

        private void BtnOne_Clicked(object sender, EventArgs e)
        {
             AddDigit(1);
        }

        private void BtnTwo_Clicked(object sender, EventArgs e)
        {
             AddDigit(2);
        }
        private void BtnThree_Clicked(object sender, EventArgs e)
        {
             AddDigit(3);
        }

        private void BtnFour_Clicked(object sender, EventArgs e)
        {
             AddDigit(4);
        }
        private void BtnFive_Clicked(object sender, EventArgs e)
        {
             AddDigit(5);
        }

        private void BtnSix_Clicked(object sender, EventArgs e)
        {
             AddDigit(6);
        }

        private void BtnSeven_Clicked(object sender, EventArgs e)
        {
             AddDigit(7);
        }

        private void BtnEight_Clicked(object sender, EventArgs e)
        {
             AddDigit(8);
        }
        private void BtnNine_Clicked(object sender, EventArgs e)
        {
             AddDigit(9);
        }       
    }
}
