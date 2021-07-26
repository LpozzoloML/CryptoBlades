using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CryptoBlades
{
    public partial class Form1 : Form
    {
        List<string> elementList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbCharMod2.Text = "-";
            cmbCharMod3.Text = "-";      
            
            elementList.Add("FIRE");
            elementList.Add("EARTH");
            elementList.Add("LIGHTNING");
            elementList.Add("WATER");
        }

        private double calcuateAVGByEnemy(double charPower, double enemyPower)
        {
            double minEnemyPwr = enemyPower * 0.9;
            double maxEnemyPwr = enemyPower * 1.1;

            double minCharPWR = charPower * 0.9;
            double maxCharPWR = charPower * 1.1;

            double cruze = maxEnemyPwr - minCharPWR;

            if (cruze < 0)
            {
                cruze = 0;
            }

            double rangoChar = maxCharPWR - minCharPWR;
            double rangoEnemy = maxEnemyPwr - minEnemyPwr;
            double prob1 = cruze / rangoEnemy;
            double prob2 = cruze / rangoChar;
            double prob3 = (prob1 * prob2) / 2;

            double temp = 1 - (prob1 * prob2);

            double probVictoria = (temp + prob3) * 100;

            return probVictoria;
        }

        private double EvaluateAttributeTotal()
        {
            string charType = cmbCharType.Text;
            string mod1Type = cmbCharMod1.Text;
            string mod2Type = cmbCharMod2.Text;
            string mod3Type = cmbCharMod3.Text;

            double evaluatedMod1, evaluatedMod2, evaluatedMod3 = 0;

            if (mod1Type != "PWR")
            {
                evaluatedMod1 = (mod1Type == charType) ? double.Parse(txtMod1.Text) * 0.002675 : double.Parse(txtMod1.Text) * 0.0025;
            }
            else
            {
                evaluatedMod1 = double.Parse(txtMod1.Text) * 0.002575;
            }

            if (mod2Type != "PWR")
            {
                evaluatedMod2 = (mod2Type == charType) ? double.Parse(txtMod2.Text) * 0.002675 : double.Parse(txtMod2.Text) * 0.0025;
            }
            else
            {
                evaluatedMod2 = double.Parse(txtMod2.Text) * 0.002575;
            }

            if (mod3Type != "PWR")
            {
                evaluatedMod3 = (mod3Type == charType) ? double.Parse(txtMod3.Text) * 0.002675 : double.Parse(txtMod3.Text) * 0.0025;
            }
            else
            {
                evaluatedMod3 = double.Parse(txtMod3.Text) * 0.002575;
            }

            return evaluatedMod1 + evaluatedMod2 + evaluatedMod3;
        }


        private bool Valdiations()
        {
            if (cmbCharType.Text == "")
            {
                lblErrorMessage.Text = "Debe indicar el tipo de tu personaje";
                return false;
            }

            if (txtCharPWR.Text == "")
            {
                lblErrorMessage.Text = "Debe indicar el poder de tu personaje";
                return false;
            }

            if (cmbWeaponType.Text == "")
            {
                lblErrorMessage.Text = "Debe indicar el elemento del arma";
                return false;
            }

            if (txtSwordBonusPWR.Text == "")
            {
                lblErrorMessage.Text = "0";
            }

            if (cmbCharMod1.Text == "")
            {
                lblErrorMessage.Text = "Debe indicar el elemento del 1er modificador";
                return false;
            }

            if (txtMod1.Text == "")
            {
                lblErrorMessage.Text = "Debe indicar el poder del 1er modificador";
                return false;
            }

            if (cmbCharMod2.Text != "-" && txtMod2.Text == "")
            {
                lblErrorMessage.Text = "Debe indicar el poder del 2do modificador";
                return false;
            }

            if (txtMod2.Text == "")
            {
                txtMod2.Text = "0";
            }

            if (txtMod3.Text == "")
            {
                txtMod3.Text = "0";
            }

            if (cmbTypeEnemy1.Text == "")
            {
                lblErrorMessage.Text = "Debe indicar al menos el elemento del 1er enemigo";
                return false;
            }

            if (txtPwrEnemy1.Text == "")
            {
                lblErrorMessage.Text = "Debe indicar al menos el poder del 1er enemigo";
                return false;
            }

            if (txtPwrEnemy2.Text == "")
            {
                txtPwrEnemy2.Text = "0";
            }

            if (txtPwrEnemy3.Text == "")
            {
                txtPwrEnemy3.Text = "0";
            }

            if (txtPwrEnemy4.Text == "")
            {
                txtPwrEnemy4.Text = "0";
            }

            if (txtSwordBonusPWR.Text == "")
            {
                txtSwordBonusPWR.Text = "0";
            }

            return true;
        }

        private void cmbTypeEnemy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeEnemy1.Text == "EARTH")
            {
                picEarth1.Visible = true;
                picFire1.Visible = false;
                picWater1.Visible = false;
                picRayo1.Visible = false;
            }

            if (cmbTypeEnemy1.Text == "WATER")
            {
                picEarth1.Visible = false;
                picFire1.Visible = false;
                picWater1.Visible = true;
                picRayo1.Visible = false;
            }

            if (cmbTypeEnemy1.Text == "FIRE")
            {
                picEarth1.Visible = false;
                picFire1.Visible = true;
                picWater1.Visible = false;
                picRayo1.Visible = false;
            }

            if (cmbTypeEnemy1.Text == "LIGHTNING")
            {
                picEarth1.Visible = false;
                picFire1.Visible = false;
                picWater1.Visible = false;
                picRayo1.Visible = true;
            }
        }

        private void cmbTypeEnemy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeEnemy2.Text == "EARTH")
            {
                picEarth2.Visible = true;
                picFire2.Visible = false;
                picWater2.Visible = false;
                picRayo2.Visible = false;
            }

            if (cmbTypeEnemy2.Text == "WATER")
            {
                picEarth2.Visible = false;
                picFire2.Visible = false;
                picWater2.Visible = true;
                picRayo2.Visible = false;
            }

            if (cmbTypeEnemy2.Text == "FIRE")
            {
                picEarth2.Visible = false;
                picFire2.Visible = true;
                picWater2.Visible = false;
                picRayo2.Visible = false;
            }

            if (cmbTypeEnemy2.Text == "LIGHTNING")
            {
                picEarth2.Visible = false;
                picFire2.Visible = false;
                picWater2.Visible = false;
                picRayo2.Visible = true;
            }
        }

        private void cmbTypeEnemy3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeEnemy3.Text == "EARTH")
            {
                picEarth3.Visible = true;
                picFire3.Visible = false;
                picWater3.Visible = false;
                picRayo3.Visible = false;
            }

            if (cmbTypeEnemy3.Text == "WATER")
            {
                picEarth3.Visible = false;
                picFire3.Visible = false;
                picWater3.Visible = true;
                picRayo3.Visible = false;
            }

            if (cmbTypeEnemy3.Text == "FIRE")
            {
                picEarth3.Visible = false;
                picFire3.Visible = true;
                picWater3.Visible = false;
                picRayo3.Visible = false;
            }

            if (cmbTypeEnemy3.Text == "LIGHTNING")
            {
                picEarth3.Visible = false;
                picFire3.Visible = false;
                picWater3.Visible = false;
                picRayo3.Visible = true;
            }
        }

        private void cmbTypeEnemy4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeEnemy4.Text == "EARTH")
            {
                picEarth4.Visible = true;
                picFire4.Visible = false;
                picWater4.Visible = false;
                picRayo4.Visible = false;
            }

            if (cmbTypeEnemy4.Text == "WATER")
            {
                picEarth4.Visible = false;
                picFire4.Visible = false;
                picWater4.Visible = true;
                picRayo4.Visible = false;
            }

            if (cmbTypeEnemy4.Text == "FIRE")
            {
                picEarth4.Visible = false;
                picFire4.Visible = true;
                picWater4.Visible = false;
                picRayo4.Visible = false;
            }

            if (cmbTypeEnemy4.Text == "LIGHTNING")
            {
                picEarth4.Visible = false;
                picFire4.Visible = false;
                picWater4.Visible = false;
                picRayo4.Visible = true;
            }
        }

        private void decorateAVG()
        {
            double dAvg1 = double.Parse(avg1.Text);
            double dAvg2 = double.Parse(avg2.Text);
            double dAvg3 = double.Parse(avg3.Text);
            double dAvg4 = double.Parse(avg4.Text);

            if (dAvg1 >= 85)
            {
                avg1.BackColor = ColorTranslator.FromHtml("#66E684");
            }
            else if (dAvg1 >= 73 && dAvg1 < 85)
            {
                avg1.BackColor = ColorTranslator.FromHtml("#F0F092");
            }
            else
            {
                avg1.BackColor = ColorTranslator.FromHtml("#EC5B44");
            }

            if (dAvg2 >= 85)
            {
                avg2.BackColor = ColorTranslator.FromHtml("#66E684");
            }
            else if (dAvg2 >= 73 && dAvg2 < 85)
            {
                avg2.BackColor = ColorTranslator.FromHtml("#F0F092");
            }
            else
            {
                avg2.BackColor = ColorTranslator.FromHtml("#EC5B44");
            }

            if (dAvg3 >= 85)
            {
                avg3.BackColor = ColorTranslator.FromHtml("#66E684");
            }
            else if (dAvg3 >= 73 && dAvg3 < 85)
            {
                avg3.BackColor = ColorTranslator.FromHtml("#F0F092");
            }
            else
            {
                avg3.BackColor = ColorTranslator.FromHtml("#EC5B44");
            }

            if (dAvg4 >= 85)
            {
                avg4.BackColor = ColorTranslator.FromHtml("#66E684");
            }
            else if (dAvg4 >= 73 && dAvg4 < 85)
            {
                avg4.BackColor = ColorTranslator.FromHtml("#F0F092");
            }
            else
            {
                avg4.BackColor = ColorTranslator.FromHtml("#EC5B44");
            }

            lblErrorMessage.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Valdiations())
            {
                return;
            }

            string characterType = cmbCharType.Text;
            int charTypeindex = elementList.FindIndex(x => x.Contains(characterType));
            int enemy1Typeindex = elementList.FindIndex(x => x.Contains(cmbTypeEnemy1.Text));
            int enemy2Typeindex = elementList.FindIndex(x => x.Contains(cmbTypeEnemy2.Text));
            int enemy3Typeindex = elementList.FindIndex(x => x.Contains(cmbTypeEnemy3.Text));
            int enemy4Typeindex = elementList.FindIndex(x => x.Contains(cmbTypeEnemy4.Text));

            double characterPWR = double.Parse(txtCharPWR.Text);
            double bonusPWR = double.Parse(txtSwordBonusPWR.Text);

            double enemy1PWR = double.Parse(txtPwrEnemy1.Text);
            double enemy2PWR = double.Parse(txtPwrEnemy2.Text);
            double enemy3PWR = double.Parse(txtPwrEnemy3.Text);
            double enemy4PWR = double.Parse(txtPwrEnemy4.Text);

            double evaluatedAttributeTotal = EvaluateAttributeTotal();

            double alignedPower = ((evaluatedAttributeTotal + 1) * characterPWR) + bonusPWR;
            double typeMatchWapon = 0;

            if ((charTypeindex - 1 == enemy1Typeindex) || (charTypeindex == 0 && enemy1Typeindex == 3))
            {
                enemy1PWR += enemy1PWR * 0.075;
            }

            if (charTypeindex - 1 == enemy2Typeindex || (charTypeindex == 0 && enemy2Typeindex == 3))
            {
                enemy2PWR += enemy2PWR * 0.075;
            }

            if (charTypeindex - 1 == enemy3Typeindex || (charTypeindex == 0 && enemy3Typeindex == 3))
            {
                enemy3PWR += enemy3PWR * 0.075;
            }

            if (charTypeindex - 1 == enemy4Typeindex || (charTypeindex == 0 && enemy4Typeindex == 3))
            {
                enemy4PWR += enemy4PWR * 0.075;
            }

            if (characterType == cmbWeaponType.Text)
            {
                typeMatchWapon = alignedPower * 0.075;
            }

            alignedPower += typeMatchWapon;

            double alignedPower1 = alignedPower;
            double alignedPower2 = alignedPower;
            double alignedPower3 = alignedPower;
            double alignedPower4 = alignedPower;

            if (charTypeindex == enemy1Typeindex - 1 || (charTypeindex == 3 && enemy1Typeindex == 0))
            {
                alignedPower1 += alignedPower1 * 0.075;
            }

            if (charTypeindex == enemy2Typeindex - 1 || (charTypeindex == 3 && enemy2Typeindex == 0))
            {
                alignedPower2 += alignedPower2 * 0.075;
            }

            if (charTypeindex == enemy3Typeindex - 1 || (charTypeindex == 3 && enemy3Typeindex == 0))
            {
                alignedPower3 += alignedPower3 * 0.075;
            }

            if (charTypeindex == enemy4Typeindex - 1 || (charTypeindex == 3 && enemy4Typeindex == 0))
            {
                alignedPower4 += alignedPower4 * 0.075;
            }

            avg1.Text = Math.Round(calcuateAVGByEnemy(alignedPower1, enemy1PWR), 2).ToString();
            avg2.Text = Math.Round(calcuateAVGByEnemy(alignedPower2, enemy2PWR), 2).ToString();
            avg3.Text = Math.Round(calcuateAVGByEnemy(alignedPower3, enemy3PWR), 2).ToString();
            avg4.Text = Math.Round(calcuateAVGByEnemy(alignedPower4, enemy4PWR), 2).ToString();

            decorateAVG();
        }
    }
}
