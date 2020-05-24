using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ภาษี
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //ตัวแปร Global
        int mixpasedown,mixpasedown2, mixpasedown3, mixpasedown4, mixpasedown5, grouppu,downpase,z1,costs, group4total, group4totalver2;
                

        //ปุ่มคำนวณภาษีที่ต้องจ่าย
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1_TextChanged(sender, e);
            group2(sender, e);
            numericUpDown11_ValueChanged(sender, e);
            group5(sender, e);
            if (downpase >= 0 && downpase < 150000)
            {
                downpase = 0;
            }
            else if (downpase > 150000 && downpase <= 300000)
            {
                downpase = (downpase - 150000) * 5/100;
            }
            else if (downpase > 300000 && downpase <= 500000)
            {
                downpase = (downpase - 300000) * 10/100 + 7500;
            }
            else if (downpase > 500000 && downpase <= 750000)
            {
                downpase = (downpase - 500000) * 15/100 + 27500;
            }
            else if (downpase > 750000 && downpase <= 1000000)
            {
                downpase = (downpase - 750000) * 20/100 + 65000;
            }
            else if (downpase > 1000000 && downpase <= 2000000)
            {
                downpase = (downpase - 1000000) * 25/100 + 115000;
            }
            else if (downpase > 2000000 && downpase <= 5000000)
            {
                downpase = (downpase - 2000000) * 30/100 + 365000;
            }
            else if (downpase > 5000000)
            {
                downpase = (downpase - 5000000) * 35/100 + 1265000;
            }
            textBox6.Text = downpase.ToString();
        }

        
        //กลุ่มที่ 1
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            mixpasedown = 0;
            //สมรส//
            if (Sode.Checked)
            {
                mixpasedown += 60000;
            }
            else if(somroshaveraidai.Checked)
            {
                mixpasedown += 60000;
            }
            else if(somrosnoraidai.Checked)
            {
                mixpasedown += 120000;
            }
            else
            {
                mixpasedown += 60000;
            }
            //บิดามารดา//
            if (checkBox1.Checked)
            {
                mixpasedown += 30000;
            }
            if (checkBox2.Checked)
            {
                mixpasedown += 30000;
            }
            if (checkBox3.Checked)
            {
                mixpasedown += 30000;
            }
            if (checkBox6.Checked)
            {
                mixpasedown += 30000;
            }
            else
            {
                mixpasedown += 0;
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
            int money1 = int.Parse(textBox1.Text); //เงินเดือน
            if (textBox2.Text == "")
            {
                textBox2.Text = "0";
            }
            int bonus1 = int.Parse(textBox2.Text); //โบนัส
            if (textBox48.Text == "")
            {
                textBox48.Text = "0";
            }
            int other1 = int.Parse(textBox48.Text); //รายได้อื่นๆ
            int b61;
            int numb61 = Convert.ToInt32(born61up.Value);

            if (born61up.Value > 0)
            {
                if (born60.Value == 0)
                {
                    b61 = (numb61 - 1) * 60000 + 30000;
                }
                else
                {
                    b61 = numb61 * 60000;
                }
            }
            else
            {
                b61 = 0;
            }
            int b60 = Convert.ToInt32(born60.Value) * 30000;
            mixpasedown += b61;
            mixpasedown += b60;

            //ค่าลดหย่อนบุตร
            
            int bootdown = Convert.ToInt32(bootdown01.Value);
            mixpasedown += bootdown;
            

            //ค่าอุปการะเลี้ยงบุตร
            int konpgarn = Convert.ToInt32(konpigarn.Value)*60000;
            mixpasedown += konpgarn;


            int show1;
            z1 = money1 * 12; //รายได้ต่อปี
            show1 = z1 + bonus1 + other1;
            textBox3.Text = show1.ToString();

            //ค่าใช้จ่าย หัก 50% จากรายได้ต่อปี แต่ไม่เกิน 100000 บาท
            costs = z1 * 50 / 100;
            if (costs > 100000)
            {
                costs = 100000;
            }
            
            

            grouppu = mixpasedown + mixpasedown2 + mixpasedown3 + mixpasedown5; //ค่าลดภาษีทั้ง 4 กลุ่ม
            downpase = (z1 - costs - grouppu)-mixpasedown4; //รายได้สุทธิหลังหักค่าบริจาค
            if(downpase<= 0)
            {
                downpase = 0;
            }
            textBox4.Text = downpase.ToString();

        }

        //ปุ่มมีบุตร
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = true;
            groupBox8.Enabled = true;
        }

        //ปุ่มไม่มีบุตร
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = false;
            groupBox8.Enabled = false;
            born60.Value = 0;
            born61up.Value = 0;
        }


        //กลุ่มที่ 2
        private void group2(object sender,EventArgs e)
        {
            mixpasedown2 = 0;

            int sangkom1 = Convert.ToInt32(sangkom.Value);
            mixpasedown2 += sangkom1;

            int praganlife1 = Convert.ToInt32(praganlife.Value);
            mixpasedown2 += praganlife1;

            int soogkapap1 = Convert.ToInt32(soogkapap.Value);
            mixpasedown2 += soogkapap1;
            int pragunmix = praganlife1 + soogkapap1;
            if (pragunmix > 100000)
            {
                pragunmix = 100000;
            }

            int praganmom1 = Convert.ToInt32(praganmom.Value);
            mixpasedown2 += praganmom1;

            int pragansomronglife = Convert.ToInt32(numericUpDown9.Value);
            mixpasedown2 += pragansomronglife;
        }


        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown10.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown10.Enabled = false;
            numericUpDown10.Value = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown10.Enabled = false;
            numericUpDown10.Value = 0;
        }


        //กลุ่มที่ 3
        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            mixpasedown3 = 0;
            int homepay = Convert.ToInt32(numericUpDown11.Value);
            if (numericUpDown11.Text == "")
            {
                numericUpDown11.Text = "0";
            }
            int home58 = (Convert.ToInt32(numericUpDown12.Value)) * 4 / 100;
            int showhome58 = (Convert.ToInt32(numericUpDown12.Value)) * 20 / 100;
            if (numericUpDown12.Text == "")
            {
                numericUpDown12.Text = "0";
            }
            textBox13.Text = showhome58.ToString();
            textBox19.Text = home58.ToString();
            int home62 = (Convert.ToInt32(numericUpDown13.Value)) * 4 / 100;
            if (numericUpDown13.Text == "")
            {
                numericUpDown13.Text = "0";
            }
            textBox20.Text = home62.ToString();
            mixpasedown3 = homepay + home58 + home62;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            groupBox15.Enabled = true;
            groupBox17.Enabled = false;
            numericUpDown12.Value = 0;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            groupBox15.Enabled = false;
            groupBox17.Enabled = true;
            numericUpDown13.Value = 0;
        }


        //กลุ่มที่ 4
        private void group4_ValueChanged(object sender,EventArgs e)
        {
            mixpasedown4 = 0;
            group4total = z1 - costs - grouppu;
            int donate2time = 0;
            int donatenormal = 0;
            int donatepolitics = 0;
            int donate2time10per = group4total * 10 / 100;
            int donate2time10pershow = (group4total * 10 / 100) / 2;
            if (numericUpDown23.Text == "")
            {
                numericUpDown23.Text = "0";
            }
            donate2time = Convert.ToInt32(numericUpDown23.Text) * 2;
            if (donate2time > donate2time10per)
            {
                donate2time = donate2time10per;
                numericUpDown23.Text = donate2time10pershow.ToString();
            }
            if (numericUpDown24.Text == "")
            {
                numericUpDown24.Text = "0";
            }
            donatenormal = Convert.ToInt32(numericUpDown24.Value);
            group4totalver2 = z1 - costs - grouppu - donate2time;
            int donatenormal10per = group4totalver2 * 10 / 100;
            if (donatenormal > donatenormal10per)
            {
                donatenormal = donatenormal10per;
                numericUpDown24.Text = donatenormal10per.ToString();
            }
            if (numericUpDown14.Text == "")
            {
                numericUpDown14.Text = "0";
            }
            donatepolitics = Convert.ToInt32(numericUpDown14.Text);
            if (donatepolitics > 10000)
            {
                donatepolitics = 10000;
                numericUpDown14.Text = donatepolitics.ToString();
            }
            ///บริจาคเงินทั่วไป + บริจาครัฐบาล
            mixpasedown4 = donate2time + donatenormal + donatepolitics;
        }


        //กลุ่มที่ 5
        private void group5(object sender, EventArgs e)
        {
            mixpasedown5 = 0;
            ///ช๊อปช่วยชาติ
            int nation = Convert.ToInt32(numericUpDown15.Value);
            if (nation > 15000)
            {
                nation = 15000;
            }
            if (numericUpDown15.Text == "")
            {
                numericUpDown15.Text = "0";
            }
            ///การกีฬา
            int sport = Convert.ToInt32(numericUpDown16.Value);
            if (sport > 15000)
            {
                sport = 15000;
            }
            if (numericUpDown16.Text == "")
            {
                numericUpDown16.Text = "0";
            }
            ///หนังสือ
            int book = Convert.ToInt32(numericUpDown17.Value);
            if (book > 15000)
            {
                book = 15000;
            }
            if (numericUpDown17.Text == "")
            {
                numericUpDown17.Text = "0";
            }
            ///โอท็อป
            int otop = Convert.ToInt32(numericUpDown18.Value);
            if (otop > 15000)
            {
                otop = 15000;
            }
            if (numericUpDown18.Text == "")
            {
                numericUpDown18.Text = "0";
            }
            ///เมืองหลวง
            int maintravel = Convert.ToInt32(numericUpDown19.Value);
            if (maintravel > 15000)
            {
                maintravel = 15000;
            }
            if (numericUpDown19.Text == "")
            {
                numericUpDown19.Text = "0";
            }
            ///เมืองรอง
            int subtravel = Convert.ToInt32(numericUpDown20.Value);
            if (subtravel > 20000)
            {
                subtravel = 20000;
            }
            if (numericUpDown20.Text == "")
            {
                numericUpDown20.Text = "0";
            }
            ///รวมเมืองหลวง+รอง
            int mstravel = maintravel + subtravel;
            if (mstravel > 20000)
            {
                mstravel = 20000;
            }
            ///บ้าน
            int housebreak = Convert.ToInt32(numericUpDown21.Value);
            if (housebreak > 100000)
            {
                housebreak = 100000;
            }
            if (numericUpDown21.Text == "")
            {
                numericUpDown21.Text = "0";
            }
            ///รถ
            int carbreak = Convert.ToInt32(numericUpDown22.Value);
            if (carbreak > 30000)
            {
                carbreak = 30000;
            }
            if (numericUpDown22.Text == "")
            {
                numericUpDown22.Text = "0";
            }
            ///รวมบ้าน+รถ
            int chbreak = housebreak + carbreak;
            if (chbreak > 100000)
            {
                chbreak = 100000;
            }
            mixpasedown5 = nation + sport + book + otop + mstravel + chbreak;
        }
    }
}
